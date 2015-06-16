using Accessibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AmcAllscriptsScanning
{
    public partial class IEAccessible
    {

        private IAccessible accessible;
        public Boolean TabFound { get; set; }
        public IntPtr WindowHandler { get; set; }

        private const int CHILDID_SELF = 0;
        private string Name { get { return accessible.get_accName(CHILDID_SELF); } }
        private int ChildCount { get { return accessible.accChildCount; } }

        public IEAccessible(String tabTitle)
        {
            bool found = false;
            Process[] processes = Process.GetProcessesByName("iexplore");
            foreach (Process p in processes)
            {
                IAccessible iacc = AccessibleObjectFromWindow(GetDirectUIHWND(p.MainWindowHandle));
                IAccessible tabRow = FindAccessibleDescendant(iacc, "Tab Row");
                List<IAccessible> tabs = AccChildren(tabRow);
                if (tabs == null)
                    return;

                int tc = tabs.Count;
                int k = 0;

                // walk through the tabs and tick the chosen one
                foreach (IAccessible candidateTab in tabs)
                {
                    // the last tab is "New Tab", which we don't want
                    if (++k == tc)
                        continue;

                    // the URL on *this* tab
                    string localUrl = UrlOfTab(candidateTab);

                    // same? if so, tick it. This selects the given tab among all
                    // the others, if any.
                    if (tabTitle != null && localUrl.Equals(tabTitle))
                    {
                        accessible = candidateTab;
                        candidateTab.accDoDefaultAction(0);
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    
                    ShowWindow(p.MainWindowHandle, (int) WINDOW_STATE.SW_MAXIMIZE);
                    break;
                }
            }
        }

        private enum OBJID : uint
        {
            WINDOW = 0x00000000,
            SYSMENU = 0xFFFFFFFF,
            TITLEBAR = 0xFFFFFFFE,
            MENU = 0xFFFFFFFD,
            CLIENT = 0xFFFFFFFC,
            VSCROLL = 0xFFFFFFFB,
            HSCROLL = 0xFFFFFFFA,
            SIZEGRIP = 0xFFFFFFF9,
            CARET = 0xFFFFFFF8,
            CURSOR = 0xFFFFFFF7,
            ALERT = 0xFFFFFFF6,
            SOUND = 0xFFFFFFF5,
        }

        private enum WINDOW_STATE : int
        {
            SW_FORCEMINIMIZE = 11,
            SW_HIDE = 0,
            SW_MAXIMIZE = 3,
            SW_MINIMIZE = 6,
            SW_RESTORE = 9,
            SW_SHOW = 5,
            SW_SHOWDEFAULT = 10,
            SW_SHOWMAXIMIZED = 3,
            SW_SHOWMINIMIZED = 2,
            SW_SHOWMINNOACTIVE = 7,
            SW_SHOWNA = 8,
            SW_SHOWNOACTIVATE = 4,
            SW_SHOWNORMAL = 1
        }


        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("oleacc.dll")]
        internal static extern int AccessibleObjectFromWindow(IntPtr hwnd, uint id, ref Guid iid, [In, Out, MarshalAs(UnmanagedType.IUnknown)] ref object ppvObject);

        [DllImport("oleacc.dll")]
        private static extern int AccessibleChildren(IAccessible paccContainer, int iChildStart, int cChildren, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] object[] rgvarChildren, out int pcObtained);

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern bool BringWindowToTop(IntPtr hWnd);

        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int X;
            public int Y;
        }
        [DllImport("user32.dll")]
        static extern bool ScreenToClient(IntPtr hWnd, ref POINT lpPoint);

        private static IntPtr GetDirectUIHWND(IntPtr ieFrame)
        {
            IntPtr intptr = IntPtr.Zero;
            
            // Check for IE 9 (might have to see if above is supported)
            intptr = FindWindowEx(ieFrame, IntPtr.Zero, "WorkerW", null);

            // If IE 9 can't find the WorkerW class under the IE process (IE 8 or 7)
            if (intptr == IntPtr.Zero)
                intptr = FindWindowEx(ieFrame, IntPtr.Zero, "CommandBarClass", null);

            // Couldn't find the right IE window
            if (intptr == IntPtr.Zero)
                return IntPtr.Zero;

            intptr = FindWindowEx(intptr, IntPtr.Zero, "ReBarWindow32", null);
            intptr = FindWindowEx(intptr, IntPtr.Zero, "TabBandClass", null);
            intptr = FindWindowEx(intptr, IntPtr.Zero, "DirectUIHWND", null);

            return intptr;
        }

        private static IAccessible AccessibleObjectFromWindow(IntPtr hwnd)
        {
            // IAccessible GUID
            Guid guid = new Guid("{618736E0-3C3D-11CF-810C-00AA00389B71}");
            object obj = null;
            int num = AccessibleObjectFromWindow(hwnd, (uint) OBJID.WINDOW, ref guid, ref obj);
            return obj as IAccessible;
        }

        private static List<IAccessible> AccChildren(IAccessible accessible)
        {
            object[] res = GetAccessibleChildren(accessible);

            if (res == null)
                return null;

            var list = new List<IAccessible>();
            foreach (object obj in res)
            {
                IAccessible acc = obj as IAccessible;
                if (acc != null)
                    list.Add(acc);
            }
            return list;
        }

        private static IAccessible FindAccessibleDescendant(IAccessible parent, String strName)
        {
            if (parent == null)
                return null;

            int c = parent.accChildCount;
            if (c == 0)
                return null;

            foreach (IAccessible child in AccChildren(parent))
            {
                if (child == null)
                    continue;

                if (String.Compare(child.get_accName(0), strName, true) == 0)
                    return child;

                IAccessible x = FindAccessibleDescendant(child, strName);
                if (x != null)
                    return x;
            }
            return null;
        }

        private static object[] GetAccessibleChildren(IAccessible ao)
        {
            if (ao == null)
                return null;
            int childs = 0;
            object[] ret = null;
            int count = ao.accChildCount;

            if (count > 0)
            {
                ret = new object[count];
                AccessibleChildren(ao, 0, count, ret, out childs);
            }

            return ret;
        }

        private static string UrlOfTab(IAccessible tab)
        {
            try
            {
                var desc = tab.get_accDescription(0);
                if (desc != null)
                {
                    if (desc.Contains("\n"))
                        return desc.Substring(desc.IndexOf("\n")).Trim();
                    else
                        return desc;
                }
            }
            catch { }
            return "??";
        }
    }
}

using Accessibility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using WinControl.Enums;
using WinControl.Externs;

namespace WinControl
{
    public class IEAccessible : IAccessible
    {
        private const int IE_ACTIVE_TAB = 2097154;
        private const int CHILDID_SELF = 0;

        public Process foundProcess { get; private set; }
        public IAccessible accessible { get; private set; }

        public IEAccessible(String tabTitle)
        {
            if (String.IsNullOrEmpty(tabTitle))
                return;

            foreach (Process p in Process.GetProcessesByName("iexplore"))
            {
                IntPtr directUIHWND = GetIEDirectUIHWND(p.MainWindowHandle);
                if (directUIHWND == IntPtr.Zero)
                    continue;

                IAccessible iacc = OleAcc.AccessibleObjectFromWindow(directUIHWND);

                for (int i = 0; i < iacc.accChildCount; i++)
                {
                    IAccessible accessor = (IAccessible) iacc.get_accChild(i);
                    foreach (IEAccessible child in accessor.Children)
                    {
                        foreach (IEAccessible tab in child.Children)
                        {
                            if (tab.Name == tabCaptionToActivate)
                            {
                                TabFound = true;
                                WindowHandler = ieHandle;
                                tab.Activate();
                                return;
                            }
                        }
                    }
                }



                IAccessible tabRow = AccessibleUtilities.FindFirstChildByName(iacc, "Tab Row");
                List<IAccessible> tabs = AccessibleUtilities.GetChildrenIacc(tabRow);

                if (tabs == null)
                    continue;

                foreach (IAccessible candidateTab in tabs)
                {
                    string localUrl = candidateTab.get_accDescription(0);

                    if (!String.IsNullOrEmpty(localUrl))
                    {
                        if (localUrl.Contains(Environment.NewLine))
                            localUrl = localUrl.Substring(0, localUrl.IndexOf(Environment.NewLine));

                        if (localUrl.ToUpper().Contains(tabTitle.ToUpper()))
                        {
                            accessible = candidateTab;
                            foundProcess = p;
                            return;
                        }
                    }
                }
            }
        }

        public void SetIEWindowState(params WINDOW_STATE[] states)
        {
            if (foundProcess != null)
            {
                foreach(WINDOW_STATE state in states)
                    User32.ShowWindow(foundProcess.MainWindowHandle, (int)state);
            }
        }

        public void BringTabForward()
        {
            accessible.accDoDefaultAction(CHILDID_SELF);
        }

        private static IntPtr GetIEDirectUIHWND(IntPtr ieFrame)
        {
            // Check for IE 9 (might have to see if above is supported)
            IntPtr intptr = User32.FindWindowEx(ieFrame, IntPtr.Zero, "WorkerW", null);

            // If IE 9 can't find the WorkerW class under the IE process (IE 8 or 7)
            if (intptr == IntPtr.Zero)
                intptr = User32.FindWindowEx(ieFrame, IntPtr.Zero, "CommandBarClass", null);

            // Couldn't find the right IE window
            if (intptr == IntPtr.Zero)
                return IntPtr.Zero;

            intptr = User32.FindWindowEx(intptr, IntPtr.Zero, "ReBarWindow32", null);
            intptr = User32.FindWindowEx(intptr, IntPtr.Zero, "TabBandClass", null);
            intptr = User32.FindWindowEx(intptr, IntPtr.Zero, "DirectUIHWND", null);

            return intptr;
        }

        #region Interface Methods
        // Returns:
        //     An integer representing the count.
        [DispId(-5001)]
        public int accChildCount { get { return accessible.accChildCount; } }

        // Returns:
        //     If successful, returns S_OK. Otherwise, returns another standard COM error
        //     code.
        [DispId(-5011)]
        public object accFocus { get { return accessible.accFocus; } }

        // Returns:
        //     An object.
        [DispId(-5000)]
        public object accParent { get { return accessible.accParent; } }
        
        // Returns:
        //     An object.
        [DispId(-5012)]
        public object accSelection { get { return accessible.accSelection; } }

        // Parameters:
        //   varChild:
        //     This parameter is intended for internal use only.
        [DispId(-5018)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public void accDoDefaultAction(object varChild)
        {
            accessible.accDoDefaultAction(varChild);
        }
        
        // Parameters:
        //   xLeft:
        //     This parameter is intended for internal use only.
        //
        //   yTop:
        //     This parameter is intended for internal use only.
        //
        // Returns:
        //     An object.
        [DispId(-5017)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public object accHitTest(int xLeft, int yTop)
        {
            return accessible.accHitTest(xLeft, yTop);
        }
        
        // Parameters:
        //   pxLeft:
        //     This parameter is intended for internal use only.
        //
        //   pyTop:
        //     This parameter is intended for internal use only.
        //
        //   pcxWidth:
        //     This parameter is intended for internal use only.
        //
        //   pcyHeight:
        //     This parameter is intended for internal use only.
        //
        //   varChild:
        //     This parameter is intended for internal use only.
        [DispId(-5015)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public void accLocation(out int pxLeft, out int pyTop, out int pcxWidth, out int pcyHeight, object varChild)
        {
            accessible.accLocation(out pxLeft, out pyTop, out pcxWidth, out pcyHeight, varChild);
        }
        
        // Parameters:
        //   navDir:
        //     This parameter is intended for internal use only.
        //
        //   varStart:
        //     This parameter is intended for internal use only.
        //
        // Returns:
        //     If successful, returns S_OK. For other possible return values, see the documentation
        //     for IAccessible::accNavigate.
        [DispId(-5016)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public object accNavigate(int navDir, object varStart)
        {
            return accessible.accNavigate(navDir, varStart);
        }
        
        // Parameters:
        //   flagsSelect:
        //     This parameter is intended for internal use only.
        //
        //   varChild:
        //     This parameter is intended for internal use only.
        [DispId(-5014)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public void accSelect(int flagsSelect, object varChild)
        {
            accessible.accSelect(flagsSelect, varChild);
        }
        
        [DispId(-5002)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public object get_accChild(object varChild)
        {
            return accessible.get_accChild(varChild);
        }
        
        [DispId(-5013)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public string get_accDefaultAction(object varChild)
        {
            return accessible.get_accDefaultAction(varChild);
        }
        
        [DispId(-5005)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public string get_accDescription(object varChild)
        {
            return accessible.get_accDescription(varChild);
        }
        
        [DispId(-5008)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public string get_accHelp(object varChild)
        {
            return accessible.get_accHelp(varChild);
        }
        
        [DispId(-5009)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public int get_accHelpTopic(out string pszHelpFile, object varChild)
        {
            return accessible.get_accHelpTopic(out pszHelpFile, varChild);
        }
        
        [DispId(-5010)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public string get_accKeyboardShortcut(object varChild)
        {
            return accessible.get_accKeyboardShortcut(varChild);
        }
        
        [DispId(-5003)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public string get_accName(object varChild)
        {
            return accessible.get_accName(varChild);
        }
        
        [DispId(-5006)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public object get_accRole(object varChild)
        {
            return accessible.get_accRole(varChild);
        }
        
        [DispId(-5007)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public object get_accState(object varChild)
        {
            return accessible.get_accState(varChild);
        }
        
        [DispId(-5004)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public string get_accValue(object varChild)
        {
            return accessible.get_accValue(varChild);
        }
        
        [DispId(-5003)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public void set_accName(object varChild, string pszName)
        {
            accessible.set_accName(varChild, pszName);
        }
        
        [DispId(-5004)]
        [TypeLibFunc(TypeLibFuncFlags.FHidden)]
        public void set_accValue(object varChild, string pszValue)
        {
            accessible.set_accValue(varChild, pszValue);
        }
        #endregion


    }
}

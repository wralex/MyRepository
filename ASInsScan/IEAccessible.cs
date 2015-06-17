/*
 * Created by SharpDevelop.
 * User: alexanw
 * Date: 11/14/2013
 * Time: 1:50 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Accessibility;

namespace ASInsScan
{
	/// <summary>
	/// Description of IEAccessible.
	/// </summary>
	public class IEAccessible
	{
        private enum OBJID : uint {
            OBJID_WINDOW = 0x00000000,
        }

        private const int IE_ACTIVE_TAB = 2097154;
        private const int CHILDID_SELF = 0;
        private IAccessible accessible;

        public Boolean TabFound { get; set; }
        public IntPtr WindowHandler { get; set; }

        private IEAccessible[] Children {
            get {
                int num = 0;
                object[] res = GetAccessibleChildren(accessible, out num);
                if (res == null) return new IEAccessible[0];
                List<IEAccessible> list = new List<IEAccessible>(res.Length);
                foreach (object obj in res)
                {
                    IAccessible acc = obj as IAccessible;
                    if (acc != null) list.Add(new IEAccessible(acc));
                }
                return list.ToArray();
            }
        }

        private string Name { get { return accessible.get_accName(CHILDID_SELF); } }

        private int ChildCount { get { return accessible.accChildCount; } }

        public IEAccessible() { }

        public IEAccessible(IntPtr ieHandle, string tabCaptionToActivate) {
        	TabFound = false;
            IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
            foreach (IEAccessible accessor in ieDirectUIHWND.Children) {
                foreach (IEAccessible child in accessor.Children) {
                    foreach (IEAccessible tab  in child.Children) {
                        if (tab.Name == tabCaptionToActivate) {
                            TabFound = true;
                            WindowHandler = ieHandle;
                            tab.Activate();
                            return;
                        }
                    }
                }
            }
        }

        public IEAccessible(IntPtr ieHandle, int tabIndexToActivate) {
            AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
            if (accessible == null) throw new Exception();

            int index = 0;
            IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
            foreach (IEAccessible accessor in ieDirectUIHWND.Children) {
                foreach (IEAccessible child in accessor.Children) {
                    foreach (IEAccessible tab in child.Children) {
                        if (tabIndexToActivate >= child.ChildCount - 1) return;
                        if (index == tabIndexToActivate) {
                            tab.Activate();
                            return;
                        }
                        index++;
                    }
                }
            }
        }

        private IEAccessible(IntPtr ieHandle) {
            AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
            if (accessible == null) throw new Exception();
        }

        public string GetActiveTabUrl(IntPtr ieHandle) {
            AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
            if (accessible == null) throw new Exception();
            IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
            foreach (IEAccessible accessor in ieDirectUIHWND.Children) {
                foreach (IEAccessible child in accessor.Children) {
                    foreach (IEAccessible tab in child.Children) {
                        object tabIndex = tab.accessible.get_accState(CHILDID_SELF);

                        if ((int)tabIndex == IE_ACTIVE_TAB) {
                            string description = tab.accessible.get_accDescription(CHILDID_SELF);

                            if (!string.IsNullOrEmpty(description)) {
                                if (description.Contains(Environment.NewLine)) {
                                    string url = description.Substring(description.IndexOf(Environment.NewLine)).Trim();
                                    return url;
                                }
                            }
                        }
                    }
                }
            }
            return String.Empty;
        }

        public int GetActiveTabIndex(IntPtr ieHandle)
        {
            AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);

            if (accessible == null) throw new Exception();

            int index = 0;
            IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);

            foreach (IEAccessible accessor in ieDirectUIHWND.Children) {
                foreach (IEAccessible child in accessor.Children) {
                    foreach (IEAccessible tab in child.Children) {
                        object tabIndex = tab.accessible.get_accState(0);
                        if ((int)tabIndex == IE_ACTIVE_TAB) return index;
                        index++;
                    }
                }
            }
            return -1;
        }

        public string GetActiveTabCaption(IntPtr ieHandle)
        {
            AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
            if (accessible == null) throw new Exception();
            IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
            foreach (IEAccessible accessor in ieDirectUIHWND.Children) {
                foreach (IEAccessible child in accessor.Children) {
                    foreach (IEAccessible tab in child.Children) {
                        object tabIndex = tab.accessible.get_accState(0);
                        if ((int)tabIndex == IE_ACTIVE_TAB) return tab.Name;
                    }
                }
            }
            return String.Empty;
        }

        public List<string> GetTabCaptions(IntPtr ieHandle) {
            AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
            if (accessible == null) throw new Exception();
            IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
            List<string> captionList = new List<string>();
            foreach (IEAccessible accessor in ieDirectUIHWND.Children) {
                foreach (IEAccessible child in accessor.Children)
                    foreach (IEAccessible tab in child.Children) captionList.Add(tab.Name);
            }
            if (captionList.Count > 0) captionList.RemoveAt(captionList.Count - 1);
            return captionList;
        }

        public int GetTabCount(IntPtr ieHandle) {
            AccessibleObjectFromWindow(GetDirectUIHWND(ieHandle), OBJID.OBJID_WINDOW, ref accessible);
            if (accessible == null) return 0; // throw new Exception();
            IEAccessible ieDirectUIHWND = new IEAccessible(ieHandle);
            foreach (IEAccessible accessor in ieDirectUIHWND.Children) {
                foreach (IEAccessible child in accessor.Children) {
                    foreach (IEAccessible tab in child.Children) return child.ChildCount - 1;
                }
            }
            return 0;
        }

        private IntPtr GetDirectUIHWND(IntPtr ieFrame) {
            IntPtr directUI = FindWindowEx(ieFrame, IntPtr.Zero, "WorkerW", null);
            directUI = FindWindowEx(directUI, IntPtr.Zero, "ReBarWindow32", null);
            directUI = FindWindowEx(directUI, IntPtr.Zero, "TabBandClass", null);
            directUI = FindWindowEx(directUI, IntPtr.Zero, "DirectUIHWND", null);

            return directUI;
        }

        private IEAccessible(IAccessible acc)
        {
            if (acc == null) throw new Exception();
            accessible = acc;
        }

        private void Activate() { accessible.accDoDefaultAction(CHILDID_SELF); }

        private static object[] GetAccessibleChildren(IAccessible ao, out int childs) {
            childs = 0;
            object[] ret = null;
            int count = ao.accChildCount;

            if (count > 0) {
                ret = new object[count];
                AccessibleChildren(ao, 0, count, ret, out childs);
            }

            return ret;
        }

        #region Interop
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        private static int AccessibleObjectFromWindow(IntPtr hwnd, OBJID idObject, ref IAccessible acc) {
            Guid guid = new Guid("{618736e0-3c3d-11cf-810c-00aa00389b71}");
            Object obj = null;
            int num = AccessibleObjectFromWindow(hwnd, (uint)idObject, ref guid, ref obj);
            acc = (IAccessible)obj;
            return acc.accChildCount;
        }

        [DllImport("oleacc.dll")]
        private static extern int AccessibleObjectFromWindow(IntPtr hwnd, uint id, ref Guid iid, [In, Out, MarshalAs(UnmanagedType.IUnknown)] ref object ppvObject);

        [DllImport("oleacc.dll")]
        private static extern int AccessibleChildren(IAccessible paccContainer, int iChildStart, int cChildren, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] object[] rgvarChildren, out int pcObtained);
        #endregion
    }
}

using Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace WinControl.Externs
{
    public static class OleAcc
    {
        [DllImport("oleacc.dll")]
        internal static extern int AccessibleObjectFromWindow(IntPtr hwnd, uint id, ref Guid iid, [In, Out, MarshalAs(UnmanagedType.IUnknown)] ref object ppvObject);

        internal static IAccessible AccessibleObjectFromWindow(IntPtr hwnd)
        {
            // IAccessible GUID
            Guid guid = new Guid("{618736E0-3C3D-11CF-810C-00AA00389B71}");
            object obj = null;
            int num = Externs.OleAcc.AccessibleObjectFromWindow(hwnd, (uint)Enums.OBJID.WINDOW, ref guid, ref obj);
            return obj as IAccessible;
        }

        [DllImport("oleacc.dll")]
        public static extern uint AccessibleChildren(IAccessible paccContainer, int iChildStart, int cChildren, [Out] object[] rgvarChildren, out int pcObtained);
    }
}

using Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinControl.Externs;

namespace WinControl
{
    public class AccessibleUtilities
    {
        internal static IAccessible FindFirstChildByName(IAccessible oParent, String strName)
        {
            List<IAccessible> avKids = GetChildrenIacc(oParent);

            if (avKids == null || avKids.Count == 0)
                return null;

            IAccessible result = null;
            foreach (IAccessible o in avKids)
            {
                if (o == null)
                    continue;
                if (String.Compare(o.accName, strName) == 0)
                    result = o;
                else
                    result = FindFirstChildByName(o, strName);

                if (result != null)
                    return result;
            }
            return null;
        }

        internal static object[] GetChildrenObjects(IAccessible oParent)
        {
            int lHowMany = oParent.accChildCount;
            
            if (lHowMany == 0)
                return null;

            object[] avKids = new object[lHowMany];
            int lGotHowMany = 0;

            if (OleAcc.AccessibleChildren(oParent, 0, lHowMany, avKids, out lGotHowMany) != 0)
                return null;
            return avKids;
        }

        internal static List<IAccessible> GetChildrenIacc(IAccessible oParent)
        {
            object[] objs = GetChildrenObjects(oParent);
            if (objs == null)
                return null;

            List<IAccessible> result = new List<IAccessible>();
            foreach (Object o in objs)
                if (o != null)
                    result.Add((IAccessible)o);
            return result;
        }
    }
}

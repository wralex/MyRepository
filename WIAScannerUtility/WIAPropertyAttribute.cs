using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WIAUtility
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class WIAPropertyAttribute : Attribute
    {
        public int Id { get; private set; }
        public WIAPropertyAttribute(int id)
		{
            this.Id = id;
		}
    }
}

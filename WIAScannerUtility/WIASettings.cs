using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;

namespace WIAUtility
{
    public abstract class WIASettings
    {
        private Dictionary<int, IProperty> Properties { get; set; }

        public WIASettings(IProperties properties)
		{
            Properties = new Dictionary<int, IProperty>();
			foreach (IProperty property in properties)
                Properties.Add(property.PropertyID, property);
		}

		protected void SetPropertyValue(int index, object value)
		{
			IProperty property;
            Properties.TryGetValue(index, out property);

            if (property == null)
				throw new NotSupportedException("Property not supported.");
			else
				property.set_Value(ref value);
		}

		protected T GetPropertyValue<T>(int index)
		{
			IProperty property;
			Properties.TryGetValue(index,out property);
			if (property==null)
                throw new NotSupportedException("Property not supported.");
			else
				return (T)property.get_Value();
		}
    }
}

using System;

namespace WIAUtility
{
	[Flags]
	[WIAProperty(4102)]
	public enum AccessRights /*WIA_IPA_ACCESS_RIGHTS*/
	{
		/// <summary>This WIA item can be deleted.</summary>
		CanBeDeleted=0x80,
		/// <summary>Access to the item is read-only.</summary>
		Read=0x01,
		/// <summary>Access to the item is read/write.</summary>
		Write=0x02,
		/// <summary>AccessRights.Read | AccessRights.CanBeDeleted</summary>
		RD=(Read|CanBeDeleted),
		/// <summary>AccessRights.Read | AccessRights.Write | AccessRights.CanBeDeleted</summary>
		RWD=(Read|Write|CanBeDeleted)
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinControl.Enums
{
    public enum OBJID : uint
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
}

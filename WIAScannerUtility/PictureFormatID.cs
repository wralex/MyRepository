using System;
using System.ComponentModel;

namespace WIAUtility
{
    public enum PictureFormatID
    {
        [Description("{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}")]
        wiaFormatBMP,
        [Description("{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}")]
        wiaFormatGIF,
        [Description("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}")]
        wiaFormatJPEG,
        [Description("{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}")]
        wiaFormatPNG,
        [Description("{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}")]
        wiaFormatTIFF
    }
}

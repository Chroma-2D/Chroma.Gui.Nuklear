﻿using System.Runtime.InteropServices;

namespace NuklearC.Native.Types
{
    [StructLayout(LayoutKind.Sequential)]
    public struct nk_command_circle_filled
    {
        public nk_command header;
        public short x;
        public short y;
        public ushort w;
        public ushort h;
        public nk_color color;
    }
}
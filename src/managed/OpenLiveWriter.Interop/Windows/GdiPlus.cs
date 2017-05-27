// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for details.

using System;
using System.Runtime.InteropServices;

namespace OpenLiveWriter.Interop.Windows
{
    /// <summary>
    /// Summary description for GdiPlus.
    /// </summary>
    public class GdiPlus
    {
        [DllImport("gdiplus.dll", CharSet = CharSet.Auto)]
        public static extern int GdipCreateBitmapFromGdiDib(IntPtr bminfo,
                                                                IntPtr pixdat,
                                                                ref IntPtr image);

        [DllImport("gdiplus.dll", CharSet = CharSet.Auto)]
        public static extern int GdipSaveImageToFile(IntPtr image,
                                                        string filename,
                                                        [In] ref Guid clsid,
                                                        IntPtr encparams);

        [DllImport("gdiplus.dll", CharSet = CharSet.Auto)]
        public static extern int GdipDisposeImage(IntPtr image);        
    }

    // Structures for saving JPEG with compression support using GdipSaveImageToFile encparams
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct gdipEncoderParameter
    {
        public Guid GUID;
        public int NumberOfValues;
        public System.Drawing.Imaging.EncoderParameterValueType type;
        public IntPtr value;
    }

    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct gdipEncoderParameters
    {
        public int count;
        public gdipEncoderParameter Parameter;
    }
}

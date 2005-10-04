//
// System.Drawing.gdipStructs.cs
//
// Author: 
// Alexandre Pigolkine (pigolkine@gmx.de)
// Jordi Mas (jordi@ximian.com)
//

//
// Copyright (C) 2004 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;

namespace System.Drawing 
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct GdiplusStartupInput
	{
                uint 		GdiplusVersion;
                IntPtr 		DebugEventCallback;
                int             SuppressBackgroundThread;
                int 		SuppressExternalCodecs;
    
	    	internal static GdiplusStartupInput MakeGdiplusStartupInput ()
	    	{
	    		GdiplusStartupInput result = new GdiplusStartupInput ();
	        	result.GdiplusVersion = 1;
	        	result.DebugEventCallback = IntPtr.Zero;
	        	result.SuppressBackgroundThread = 0;
	        	result.SuppressExternalCodecs = 0;
	        	return result;
	    	}    	
       	}
    
	[StructLayout(LayoutKind.Sequential)]
	internal struct GdiplusStartupOutput
	{
                internal IntPtr 	NotificationHook;
                internal IntPtr		NotificationUnhook;
                
	    	internal static GdiplusStartupOutput MakeGdiplusStartupOutput ()
	    	{
	    		GdiplusStartupOutput result = new GdiplusStartupOutput ();
	    		result.NotificationHook = result.NotificationUnhook = IntPtr.Zero;
	        	return result;
	    	}
	}
	
		
	[StructLayout(LayoutKind.Sequential)]
	internal struct GdiColorPalette
	{
   		internal int Flags;             // Palette flags
    		internal int Count;             // Number of color entries    				
    	}
    	
    	[StructLayout(LayoutKind.Sequential)]
    	internal struct  GdiColorMap 
    	{
    		internal int from;
    		internal int to;
	}

	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Ansi)]
	internal  struct LOGFONTA  
	{
		internal int    lfHeight;
		internal uint   lfWidth;
		internal uint   lfEscapement;
		internal uint   lfOrientation;
		internal uint   lfWeight;
		internal byte   lfItalic;
		internal byte   lfUnderline;
		internal byte   lfStrikeOut;
		internal byte   lfCharSet;
		internal byte   lfOutPrecision;
		internal byte   lfClipPrecision;
		internal byte   lfQuality;
		internal byte   lfPitchAndFamily;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
		internal string lfFaceName;
	}  
	
	[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
	internal struct GdipImageCodecInfo	/*Size 76 bytes*/
	{
    		internal Guid Clsid;    		
    		internal Guid  FormatID;    		
    		internal IntPtr CodecName;
    		internal IntPtr DllName;
    		internal IntPtr FormatDescription;
    		internal IntPtr FilenameExtension;
    		internal IntPtr MimeType;
		internal ImageCodecFlags Flags;
		internal int Version;
		internal int SigCount;
		internal int SigSize;
    		IntPtr SigPattern;
    		IntPtr SigMask;
    		
		internal static void MarshalTo (GdipImageCodecInfo gdipcodec, ImageCodecInfo codec)
		{	
			codec.CodecName = Marshal.PtrToStringUni (gdipcodec.CodecName);  			    			
			codec.DllName = Marshal.PtrToStringUni (gdipcodec.DllName);
			codec.FormatDescription = Marshal.PtrToStringUni (gdipcodec.FormatDescription);
			codec.FilenameExtension = Marshal.PtrToStringUni (gdipcodec.FilenameExtension);
			codec.MimeType = Marshal.PtrToStringUni (gdipcodec.MimeType);
			codec.Clsid = gdipcodec.Clsid;
			codec.FormatID = gdipcodec.FormatID;			
			codec.Flags = gdipcodec.Flags;
			codec.Version  = gdipcodec.Version;					
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GdipEncoderParameter {
		internal Guid guid;
		internal uint numberOfValues;
		internal EncoderParameterValueType type;
		internal IntPtr value;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct GdipPropertyItem
	{
		internal int id;
		internal int len;
		internal short type;
		internal IntPtr value;

		internal static void MarshalTo (GdipPropertyItem gdipProp, PropertyItem prop)
		{	
			prop.Id = gdipProp.id;
			prop.Len = gdipProp.len;
			prop.Type = gdipProp.type;
			prop.Value = new byte [gdipProp.len];			
			Marshal.Copy (gdipProp.value, prop.Value, 0, gdipProp.len);
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct IconInfo
	{
		int fIcon;
		public int xHotspot;
		public int yHotspot;
		IntPtr hbmMask;
		IntPtr hbmColor;

		public bool IsIcon {
			get {
				return fIcon == 1;
			}
		}
	}
}


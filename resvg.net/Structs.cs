using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace resvg.net;

[StructLayout(LayoutKind.Sequential)]
[DebuggerDisplay("{Width},{Height}")]
public struct ResvgSize
{
    public float Width;
    public float Height;
    public static explicit operator Size(ResvgSize size) => Size.Round(size);
    public static implicit operator SizeF(ResvgSize size) => new(size.Width, size.Height);
}

[StructLayout(LayoutKind.Sequential)]
[DebuggerDisplay("{X},{Y}, {Width},{Height}")]
public struct ResvgRect
{
    public float X;
    public float Y;
    public float Width;
    public float Height;
    public static explicit operator Rectangle(ResvgRect rect) => Rectangle.Round(rect);
    public static implicit operator RectangleF(ResvgRect rect) => new(rect.X, rect.Y, rect.Width, rect.Height);
}

[StructLayout(LayoutKind.Sequential)]
[DebuggerDisplay("{M11},{M12}, {M21},{M22}, {OffsetX},{OffsetY}")]
public struct ResvgTransform
{
    public static readonly ResvgTransform Identity = new() { M11 = 1, M22 = 1 };

    public float M11;
    public float M12;
    public float M21;
    public float M22;
    public float OffsetX;
    public float OffsetY;
}
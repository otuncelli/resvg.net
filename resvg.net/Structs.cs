using System.Drawing;
using System.Runtime.InteropServices;

namespace resvg.net
{
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ResvgSize
    {
        public float Width;
        public float Height;
        public static explicit operator Size(ResvgSize size) => Size.Round(size);
        public static implicit operator SizeF(ResvgSize size) => new SizeF(size.Width, size.Height);
    }

    [StructLayout(LayoutKind.Sequential)]
    public ref struct ResvgRect
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;
        public static explicit operator Rectangle(ResvgRect rect) => Rectangle.Round(rect);
        public static implicit operator RectangleF(ResvgRect rect) => new RectangleF(rect.X, rect.Y, rect.Width, rect.Height);
    }

    [StructLayout(LayoutKind.Sequential)]
    public ref struct ResvgTransform
    {
        public float a;
        public float b;
        public float c;
        public float d;
        public float e;
        public float f;
    }
}

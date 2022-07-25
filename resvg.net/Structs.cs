using System.Drawing;
using System.Runtime.InteropServices;

namespace resvg.net
{
    [StructLayout(LayoutKind.Sequential)]
    public struct resvg_size
    {
        public double Width;
        public double Height;

        public Size ToSize() => new Size((int)Width, (int)Height);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct resvg_rect
    {
        public double X;
        public double Y;
        public double Width;
        public double Height;

        public Rectangle ToRectangle() => new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct resvg_transform
    {
        public double a;
        public double b;
        public double c;
        public double d;
        public double e;
        public double f;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct resvg_fit_to
    {
        public FitToType type;
        public float value;
    }
}

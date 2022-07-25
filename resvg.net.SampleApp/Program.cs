using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace resvg.net.SampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ReSvgOptions options = new ReSvgOptions())
            {
                options.LoadSystemFonts();
                string svgdata = File.ReadAllText(@"..\..\..\Assets\Mahuri.svg", Encoding.UTF8);
                using (ReSvg resvg = ReSvg.FromData(svgdata, options))
                {
                    Size size = resvg.Size.ToSize();
                    using (Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppPArgb))
                    {
                        Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
                        BitmapData data = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
                        resvg.Render(data.Scan0, size.Width, size.Height, FitToType.Original);
                        ConvertFromRgba(data);
                        bitmap.UnlockBits(data);
                        bitmap.Save("output.png");
                    }
                }
            }
        }

        private static unsafe void ConvertFromRgba(BitmapData data)
        {
            for (int y = 0; y < data.Height; y++)
            {
                ColorStruct* pix = (ColorStruct*)((byte*)(void*)data.Scan0 + y * data.Stride);
                for(int x = data.Width - 1; x >= 0; x--)
                {
                    (pix->B, pix->R) = (pix->R, pix->B);
                    pix++;
                }
            }
        }

        struct ColorStruct
        {
            public byte R;
            public byte G;
            public byte B;
            public byte A;
        }
    }
}

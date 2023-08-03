# resvg.net

.NET Core wrapper for [resvg](https://github.com/RazrFalcon/resvg); an [SVG](https://en.wikipedia.org/wiki/Scalable_Vector_Graphics) rendering library.

# Usage

```csharp
using resvg.net;
...
string svgdata = File.ReadAllText(@"C:\Path\To\Svg\File.svg", Encoding.UTF8);
using Resvg resvg = Resvg.FromData(svgdata, loadSystemFonts: true);
Size size = resvg.Size.ToSize();
using Bitmap bitmap = new Bitmap(size.Width, size.Height, PixelFormat.Format32bppPArgb);
Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
BitmapData data = bitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppPArgb);
resvg.Render(data.Scan0, size.Width, size.Height);
Resvg.ConvertRgbaToBgra(data.Scan0, size.Width, size.Height);
bitmap.UnlockBits(data);
bitmap.Save("output.png");
```

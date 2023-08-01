using System;
using System.Runtime.InteropServices;

namespace resvg.net
{
    public sealed class ReSvgOptions : IDisposable
    {
        private IntPtr opt;
        private bool disposed;

        internal IntPtr Handle => opt;

        public ReSvgOptions()
        {
            opt = NativeMethods.resvg_options_create();
        }

        public void SetResourcesDir(string path)
            => NativeMethods.resvg_options_set_resources_dir(opt, path);

        public void SetDpi(float dpi)
            => NativeMethods.resvg_options_set_dpi(opt, dpi);

        public void SetFontFamily(string family)
            => NativeMethods.resvg_options_set_font_family(opt, family);

        public void SetFontSize(float size)
            => NativeMethods.resvg_options_set_font_size(opt, size);

        public void SetSerifFamily(string family)
            => NativeMethods.resvg_options_set_serif_family(opt, family);

        public void SetSansSerifFamily(string family)
            => NativeMethods.resvg_options_set_sans_serif_family(opt, family);

        public void CursiveFamily(string family)
            => NativeMethods.resvg_options_set_cursive_family(opt, family);

        public void SetFantasyFamily(string family)
            => NativeMethods.resvg_options_set_fantasy_family(opt, family);

        public void SetMonospaceFamily(string family)
            => NativeMethods.resvg_options_set_monospace_family(opt, family);

        public void SetLanguages(string languages)
            => NativeMethods.resvg_options_set_languages(opt, languages);

        public void SetShapeRenderingMode(ShapeRenderingMode mode)
            => NativeMethods.resvg_options_set_shape_rendering_mode(opt, mode);

        public void SetTextRenderingMode(TextRenderingMode mode)
            => NativeMethods.resvg_options_set_text_rendering_mode(opt, mode);

        public void SetImageRenderingMode(ImageRenderingMode mode)
            => NativeMethods.resvg_options_set_image_rendering_mode(opt, mode);

        public void Dispose()
        {
            if (!disposed)
            {
                NativeMethods.resvg_options_destroy(opt);
                opt = IntPtr.Zero;
                disposed = true;
            }
        }

        public void LoadFontData(byte[] data)
        {
            GCHandle gch = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                NativeMethods.resvg_options_load_font_data(opt, gch.AddrOfPinnedObject(), (UIntPtr)data.Length);
            }
            finally
            {
                gch.Free();
            }
        }

        public void LoadFontFile(string filePath)
        {
            NativeMethods.resvg_options_load_font_file(opt, filePath);
        }

        public void LoadSystemFonts()
        {
            NativeMethods.resvg_options_load_system_fonts(opt);
        }
    }
}

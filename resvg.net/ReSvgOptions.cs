using System;
using System.Runtime.InteropServices;

namespace resvg.net
{
    public sealed class ReSvgOptions : IDisposable
    {
        internal IntPtr opt;
        private bool disposed;

        public ReSvgOptions()
        {
            opt = Native.resvg_options_create();
        }

        public void SetResourcesDir(string path)
            => Native.resvg_options_set_resources_dir(opt, path);

        public void SetDpi(double dpi)
            => Native.resvg_options_set_dpi(opt, dpi);

        public void SetFontFamily(string family)
            => Native.resvg_options_set_font_family(opt, family);

        public void SetFontSize(double size)
            => Native.resvg_options_set_font_size(opt, size);

        public void SetSerifFamily(string family)
            => Native.resvg_options_set_serif_family(opt, family);

        public void SetSansSerifFamily(string family)
            => Native.resvg_options_set_sans_serif_family(opt, family);

        public void CursiveFamily(string family)
            => Native.resvg_options_set_cursive_family(opt, family);

        public void SetFantasyFamily(string family)
            => Native.resvg_options_set_fantasy_family(opt, family);

        public void SetMonospaceFamily(string family)
            => Native.resvg_options_set_monospace_family(opt, family);

        public void SetLanguages(string languages)
            => Native.resvg_options_set_languages(opt, languages);

        public void SetShapeRenderingMode(ShapeRenderingMode mode)
            => Native.resvg_options_set_shape_rendering_mode(opt, mode);

        public void SetTextRenderingMode(TextRenderingMode mode)
            => Native.resvg_options_set_text_rendering_mode(opt, mode);

        public void SetImageRenderingMode(ImageRenderingMode mode)
            => Native.resvg_options_set_image_rendering_mode(opt, mode);

        public void SetKeepNamedGroups(bool keep)
            => Native.resvg_options_set_keep_named_groups(opt, keep);

        public void Dispose()
        {
            if (!disposed)
            {
                Native.resvg_options_destroy(opt);
                disposed = true;
            }
        }

        public void LoadFontData(byte[] data)
        {
            GCHandle gch = GCHandle.Alloc(data, GCHandleType.Pinned);
            try
            {
                Native.resvg_options_load_font_data(opt, gch.AddrOfPinnedObject(), (UIntPtr)data.Length);
            }
            finally
            {
                gch.Free();
            }
        }

        public void LoadFontFile(string filePath)
        {
            Native.resvg_options_load_font_file(opt, filePath);
        }

        public void LoadSystemFonts()
        {
            Native.resvg_options_load_system_fonts(opt);
        }
    }
}

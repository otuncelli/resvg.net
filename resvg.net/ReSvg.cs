using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace resvg.net
{
    public class ReSvg : IDisposable
    {
        private bool disposed;
        private IntPtr tree;
        private static bool logging;

        public SizeF Size { get; private set; }
        public RectangleF Viewbox { get; private set; }
        public RectangleF? Bbox { get; private set; }

        private ReSvg()
        {
        }

        private void Init()
        {
            Size = NativeMethods.resvg_get_image_size(tree);
            Viewbox = NativeMethods.resvg_get_image_viewbox(tree);
            if (NativeMethods.resvg_get_image_bbox(tree, out ResvgRect bbox))
            {
                Bbox = bbox;
            }
        }

        public bool IsEmpty
            => NativeMethods.resvg_is_image_empty(tree);

        public bool NodeExists(string id)
            => NativeMethods.resvg_node_exists(tree, id);

        public bool TryGetNodeTransform(string id, out ResvgTransform transform)
            => NativeMethods.resvg_get_node_transform(tree, id, out transform);

        public bool TryGetNodeBbox(string id, out ResvgRect bbox)
            => NativeMethods.resvg_get_node_bbox(tree, id, out bbox);

        private static void Check(ReSvgError error)
        {
            if (error == ReSvgError.OK) { return; }
            throw new ReSvgException(error);
        }

        public void Render(IntPtr pixmap, int rasterWidth, int rasterHeight)
        {
            ResvgTransform transform = NativeMethods.resvg_transform_identity();
            NativeMethods.resvg_render(tree, transform, (uint)rasterWidth, (uint)rasterHeight, pixmap);
        }

        public static ReSvg FromFile(string path, ReSvgOptions options)
        {
            ReSvg resvg = new ReSvg();
            try
            {
                Check(NativeMethods.resvg_parse_tree_from_file(path, options.Handle, out resvg.tree));
                resvg.Init();
            }
            catch (Exception)
            {
                resvg.Dispose();
                throw;
            }
            return resvg;
        }

        public static ReSvg FromFile(string path, bool loadSystemFonts = true)
        {
            using (ReSvgOptions options = new ReSvgOptions())
            {
                if (loadSystemFonts)
                {
                    options.LoadSystemFonts();
                }
                return FromFile(path, options);
            }
        }

        public static ReSvg FromData(string data, ReSvgOptions options)
        {
            ReSvg resvg = new ReSvg();
            try
            {
                Check(NativeMethods.resvg_parse_tree_from_data(data, (UIntPtr)Encoding.UTF8.GetByteCount(data), options.Handle, out resvg.tree));
                resvg.Init();
            }
            catch (Exception)
            {
                resvg.Dispose();
                throw;
            }
            return resvg;
        }

        public static ReSvg FromData(string data, bool loadSystemFonts = true)
        {
            using (ReSvgOptions options = new ReSvgOptions())
            {
                if (loadSystemFonts)
                {
                    options.LoadSystemFonts();
                }
                return FromData(data, options);
            }
        }

        public static ReSvg FromStream(Stream stream, ReSvgOptions options)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                return FromData(reader.ReadToEnd(), options);
            }
        }

        public static ReSvg FromStream(Stream stream, bool loadSystemFonts = true)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                return FromData(reader.ReadToEnd(), loadSystemFonts);
            }
        }

        public static void InitLog()
        {
            if (!logging)
            {
                NativeMethods.resvg_init_log();
                logging = true;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                NativeMethods.resvg_tree_destroy(tree);
                tree = IntPtr.Zero;
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

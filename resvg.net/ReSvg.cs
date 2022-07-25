using System;
using System.IO;
using System.Text;

namespace resvg.net
{
    public class ReSvg : IDisposable
    {
        private bool disposed;
        private IntPtr tree;
        private static bool logging;

        public resvg_size Size { get; private set; }
        public resvg_rect Viewbox { get; private set; }
        public resvg_rect? Bbox { get; private set; }

        private ReSvg()
        {
        }

        private void Init()
        {
            Size = Native.resvg_get_image_size(tree);
            Viewbox = Native.resvg_get_image_viewbox(tree);
            if (Native.resvg_get_image_bbox(tree, out resvg_rect bbox))
            {
                Bbox = bbox;
            }
        }

        public bool IsEmpty
            => Native.resvg_is_image_empty(tree);

        public bool NodeExists(string id)
            => Native.resvg_node_exists(tree, id);

        public bool TryGetNodeTransform(string id, out resvg_transform transform)
            => Native.resvg_get_node_transform(tree, id, out transform);

        public bool TryGetNodeBbox(string id, out resvg_rect bbox)
            => Native.resvg_get_node_bbox(tree, id, out bbox);

        private static void Check(ReSvgError error)
        {
            if (error == ReSvgError.OK) { return; }
            throw new ReSvgException(error);
        }

        public void Render(IntPtr pixmap, int rasterWidth, int rasterHeight, FitToType fitToType)
        {
            resvg_transform transform = Native.resvg_transform_identity();
            resvg_fit_to fitto = new resvg_fit_to { type = fitToType };
            Native.resvg_render(tree, fitto, transform, (uint)rasterWidth, (uint)rasterHeight, pixmap);
        }

        public static ReSvg FromFile(string path, ReSvgOptions options)
        {
            ReSvg resvg = new ReSvg();
            try
            {
                Check(Native.resvg_parse_tree_from_file(path, options.opt, out resvg.tree));
                resvg.Init();
            }
            catch (Exception)
            {
                resvg.Dispose();
                throw;
            }
            return resvg;
        }

        public static ReSvg FromFile(string path)
        {
            using ReSvgOptions options = new ReSvgOptions();
            return FromFile(path, options);
        }

        public static ReSvg FromData(string data, ReSvgOptions options)
        {
            ReSvg resvg = new ReSvg();
            try
            {
                Check(Native.resvg_parse_tree_from_data(data, (UIntPtr)Encoding.UTF8.GetByteCount(data), options.opt, out resvg.tree));
                resvg.Init();
            }
            catch (Exception)
            {
                resvg.Dispose();
                throw;
            }
            return resvg;
        }

        public static ReSvg FromData(string data)
        {
            using ReSvgOptions options = new ReSvgOptions();
            return FromData(data, options);
        }

        public static ReSvg FromStream(Stream stream, ReSvgOptions options)
        {
            using StreamReader reader = new StreamReader(stream);
            return FromData(reader.ReadToEnd(), options);
        }

        public static ReSvg FromStream(Stream stream)
        {
            using StreamReader reader = new StreamReader(stream);
            return FromData(reader.ReadToEnd());
        }

        public static void InitLog()
        {
            if (!logging)
            {
                Native.resvg_init_log();
                logging = true;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                Native.resvg_tree_destroy(tree);
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

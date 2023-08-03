using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace resvg.net
{
    /// <summary>
    /// Parsed SVG object.
    /// </summary>
    public class Resvg : IDisposable
    {
        #region Fields

        private bool disposed;
        private IntPtr tree;
        private static bool logging;

        #endregion

        #region Properties

        /// <summary>
        /// Image's bounding box.
        /// Can be smaller or bigger than a `viewbox`.
        /// `null` if an image has no elements.
        /// </summary>
        public RectangleF? Bbox { get; private set; }

        /// <summary>
        /// Checks that tree has any nodes.
        /// `true` if tree has no nodes.
        /// </summary>
        public bool IsEmpty => NativeMethods.resvg_is_image_empty(tree);

        /// <summary>
        /// The size of a canvas that required to render this SVG.
        /// </summary>
        public SizeF Size { get; private set; }

        /// <summary>
        /// The `viewBox` attribute in SVG.
        /// </summary>
        public RectangleF Viewbox { get; private set; }

        #endregion

        #region Private Constructor

        private Resvg()
        {
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns `true` if a renderable node with such an ID exists.
        /// </summary>
        /// <param name="id">Node's ID.</param>
        /// <returns>`true` if a node exists.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool NodeExists(string id)
        {
            if (id is null) { throw new ArgumentNullException(nameof(id)); }
            return NativeMethods.resvg_node_exists(tree, id);
        }

        /// <summary>
        ///  Returns node's transform by ID.
        /// </summary>
        /// <param name="id">Node's ID.</param>
        /// <param name="transform">Node's transform.</param>
        /// <returns>`true` if a node with such an ID exists.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool TryGetNodeTransform(string id, out ResvgTransform transform)
        {
            if (id is null) { throw new ArgumentNullException(nameof(id)); }
            return NativeMethods.resvg_get_node_transform(tree, id, out transform);
        }

        /// <summary>
        /// Returns node's bounding box by ID.
        /// </summary>
        /// <param name="id">Node's ID.</param>
        /// <param name="bbox">Node's bounding box.</param>
        /// <returns>`true` if a node with such an ID exists.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool TryGetNodeBbox(string id, out ResvgRect bbox)
        {
            if (id is null) { throw new ArgumentNullException(nameof(id)); }
            return NativeMethods.resvg_get_node_bbox(tree, id, out bbox);
        }

        /// <inheritdoc cref="Render(IntPtr, ResvgTransform, int, int)"/>
        public void Render(IntPtr pixmap, int width, int height)
            => Render(pixmap, NativeMethods.resvg_transform_identity(), width, height);

        /// <summary>
        /// Renders onto the pixmap.
        /// </summary>
        /// <param name="pixmap">Pixmap data. Should have width*height*4 size and contain premultiplied RGBA8888 pixels.</param>
        /// <param name="transform">A root SVG transform. Can be used to position SVG inside the `pixmap`.</param>
        /// <param name="width">Pixmap width.</param>
        /// <param name="height">Pixmap height.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Render(IntPtr pixmap, ResvgTransform transform, int width, int height)
        {
            if (width < 1) { throw new ArgumentOutOfRangeException(nameof(width)); }
            if (height < 1) { throw new ArgumentOutOfRangeException(nameof(height)); }

            NativeMethods.resvg_render(tree, transform, (uint)width, (uint)height, pixmap);
        }

        /// <inheritdoc cref="RenderNode(IntPtr, string, ResvgTransform, int, int)"/>
        public bool RenderNode(IntPtr pixmap, string id, int width, int height)
            => TryGetNodeTransform(id, out ResvgTransform transform) && RenderNode(pixmap, id, transform, width, height);

        /// <summary>
        /// Renders a Node by ID onto the image.
        /// </summary>
        /// <param name="pixmap">Pixmap data. Should have width*height*4 size and contain premultiplied RGBA8888 pixels.</param>
        /// <param name="id">Node's ID.</param>
        /// <param name="transform">A root SVG transform. Can be used to position SVG inside the `pixmap`.</param>
        /// <param name="width">Pixmap width.</param>
        /// <param name="height">Pixmap height.</param>
        /// <returns>`true` on success.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public bool RenderNode(IntPtr pixmap, string id, ResvgTransform transform, int width, int height)
        {
            if (id is null) { throw new ArgumentNullException(nameof(id)); }
            if (width < 1) { throw new ArgumentOutOfRangeException(nameof(width)); }
            if (height < 1) { throw new ArgumentOutOfRangeException(nameof(height)); }

            return NativeMethods.resvg_render_node(tree, id, transform, (uint)width, (uint)height, pixmap);
        }

        #region IDisposable

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

        #endregion

        private void Init()
        {
            Size = NativeMethods.resvg_get_image_size(tree);
            Viewbox = NativeMethods.resvg_get_image_viewbox(tree);
            if (NativeMethods.resvg_get_image_bbox(tree, out ResvgRect bbox))
            {
                Bbox = bbox;
            }
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Creates and returns a Resvg object from file.
        /// .svg and .svgz files are supported.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="options">Rendering options.</param>
        /// <returns>Resvg object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Resvg FromFile(string path, ResvgOptions options)
        {
            if (path is null) { throw new ArgumentNullException(nameof(path)); }
            if (options is null) { throw new ArgumentNullException(nameof(options)); }

            Resvg resvg = new Resvg();
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

        /// <summary>
        /// Creates and returns a Resvg object from file.
        /// .svg and .svgz files are supported.
        /// </summary>
        /// <param name="path">Path to the file.</param>
        /// <param name="loadSystemFonts">Load system fonts.</param>
        /// <returns>Resvg object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Resvg FromFile(string path, bool loadSystemFonts = true)
        {
            if (path is null) { throw new ArgumentNullException(nameof(path)); }

            using ResvgOptions options = new ResvgOptions();
            if (loadSystemFonts)
            {
                options.LoadSystemFonts();
            }
            return FromFile(path, options);
        }

        /// <summary>
        /// Creates and returns a Resvg object from data.
        /// </summary>
        /// <param name="data">SVG string data.</param>
        /// <param name="options">Rendering options.</param>
        /// <returns>Resvg object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Resvg FromData(string data, ResvgOptions options)
        {
            if (data is null) { throw new ArgumentNullException(nameof(data)); }
            if (options is null) { throw new ArgumentNullException(nameof(options)); }

            Resvg resvg = new Resvg();
            try
            {
                UIntPtr length = (UIntPtr)Encoding.UTF8.GetByteCount(data);
                Check(NativeMethods.resvg_parse_tree_from_data(data, length, options.Handle, out resvg.tree));
                resvg.Init();
            }
            catch (Exception)
            {
                resvg.Dispose();
                throw;
            }
            return resvg;
        }

        /// <summary>
        /// Creates and returns a Resvg object from data.
        /// </summary>
        /// <param name="data">SVG string data.</param>
        /// <param name="loadSystemFonts">Load system fonts.</param>
        /// <returns>Resvg object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Resvg FromData(string data, bool loadSystemFonts = true)
        {
            if (data is null) { throw new ArgumentNullException(nameof(data)); }

            using ResvgOptions options = new ResvgOptions();
            if (loadSystemFonts)
            {
                options.LoadSystemFonts();
            }
            return FromData(data, options);
        }

        /// <summary>
        /// Creates and returns a Resvg object from stream.
        /// </summary>
        /// <param name="stream">Input stream.</param>
        /// <param name="options">Rendering options.</param>
        /// <returns>Resvg object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Resvg FromStream(Stream stream, ResvgOptions options)
        {
            if (stream is null) { throw new ArgumentNullException(nameof(stream)); }
            if (options is null) { throw new ArgumentNullException(nameof(options)); }

            using StreamReader reader = new StreamReader(stream, leaveOpen: true);
            return FromData(reader.ReadToEnd(), options);
        }

        /// <summary>
        /// Creates and returns a Resvg object from stream.
        /// </summary>
        /// <param name="stream">Input stream.</param>
        /// <param name="loadSystemFonts">Load system fonts.</param>
        /// <returns>Resvg object.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Resvg FromStream(Stream stream, bool loadSystemFonts = true)
        {
            if (stream is null) { throw new ArgumentNullException(nameof(stream)); }

            using StreamReader reader = new StreamReader(stream, leaveOpen: true);
            return FromData(reader.ReadToEnd(), loadSystemFonts);
        }

        /// <summary>
        /// Initializes the library log.
        /// </summary>
        /// <remarks>
        /// Use it if you want to see any warnings.
        /// Must be called only once.
        /// All warnings will be printed to the `stderr`.
        /// </remarks>
        public static void InitLog()
        {
            if (!logging)
            {
                NativeMethods.resvg_init_log();
                logging = true;
            }
        }

        /// <summary>
        /// RGBA -> BGRA
        /// </summary>
        /// <param name="pixmap"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static unsafe void ConvertRgbaToBgra(IntPtr pixmap, int width, int height)
        {
            byte* src = (byte*)(void*)pixmap;
            for (int i = 0; i < width * height * 4; i += 4)
            {
                (src[i], src[i + 2]) = (src[i + 2], src[i]);
            }
        }

        internal static void Check(ResvgError error)
        {
            if (error == ResvgError.OK) { return; }
            throw new ResvgException(error);
        }

        #endregion
    }
}

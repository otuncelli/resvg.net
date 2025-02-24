using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace resvg.net;

/// <summary>
/// Parsed SVG object.
/// </summary>
public class Resvg : IDisposable
{
    #region Fields

    private nint tree;
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
        ArgumentNullException.ThrowIfNull(id);

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
        ArgumentNullException.ThrowIfNull(id);

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
        ArgumentNullException.ThrowIfNull(id);

        return NativeMethods.resvg_get_node_bbox(tree, id, out bbox);
    }

    /// <inheritdoc cref="Render(nint, ResvgTransform, int, int, PixelOpFlags)"/>
    public void Render(nint pixmap, int width, int height, PixelOpFlags flags = PixelOpFlags.None)
    {
        Render(pixmap, ResvgTransform.Identity, width, height, flags);
    }

    /// <summary>
    /// Renders onto the pixmap.
    /// </summary>
    /// <param name="pixmap">Pixmap data. Should have width*height*4 size and contain premultiplied RGBA8888 pixels.</param>
    /// <param name="transform">A root SVG transform. Can be used to position SVG inside the `pixmap`.</param>
    /// <param name="width">Pixmap width.</param>
    /// <param name="height">Pixmap height.</param>
    /// <param name="flags">Pixel operations to be performed on the pixmap.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Render(nint pixmap, ResvgTransform transform, int width, int height, PixelOpFlags flags = PixelOpFlags.None)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(width, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(height, 1);

        NativeMethods.resvg_render(tree, transform, (uint)width, (uint)height, pixmap);
        PixelOperations.Apply(pixmap, width * height, flags);
    }

    /// <inheritdoc cref="RenderNode(nint, string, ResvgTransform, int, int, PixelOpFlags)"/>
    public bool RenderNode(nint pixmap, string id, int width, int height, PixelOpFlags flags = PixelOpFlags.None)
    {
        return TryGetNodeTransform(id, out ResvgTransform transform) && RenderNode(pixmap, id, transform, width, height, flags);
    }

    /// <summary>
    /// Renders a Node by ID onto the image.
    /// </summary>
    /// <param name="pixmap">Pixmap data. Should have width*height*4 size and contain premultiplied RGBA8888 pixels.</param>
    /// <param name="id">Node's ID.</param>
    /// <param name="transform">A root SVG transform. Can be used to position SVG inside the `pixmap`.</param>
    /// <param name="width">Pixmap width.</param>
    /// <param name="height">Pixmap height.</param>
    /// <param name="flags">Pixel operations to be performed on the pixmap.</param>
    /// <returns>`true` on success.</returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public bool RenderNode(nint pixmap, string id, ResvgTransform transform, int width, int height, PixelOpFlags flags = PixelOpFlags.None)
    {
        ArgumentNullException.ThrowIfNull(id);
        ArgumentOutOfRangeException.ThrowIfLessThan(width, 1);
        ArgumentOutOfRangeException.ThrowIfLessThan(height, 1);

        if (!NativeMethods.resvg_render_node(tree, id, transform, (uint)width, (uint)height, pixmap))
            return false;
        PixelOperations.Apply(pixmap, width * height, flags);
        return true;
    }

    #region IDisposable

    protected virtual void Dispose(bool disposing)
    {
        if (tree != nint.Zero)
        {
            NativeMethods.resvg_tree_destroy(tree);
            tree = nint.Zero;
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
        if (NativeMethods.resvg_get_object_bbox(tree, out ResvgRect bbox))
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
        ArgumentException.ThrowIfNullOrWhiteSpace(path);
        ArgumentNullException.ThrowIfNull(options);

        Resvg resvg = new();
        try
        {
            NativeMethods.resvg_parse_tree_from_file(path, options.Handle, out resvg.tree).Check();
            resvg.Init();
        }
        catch
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
        ArgumentException.ThrowIfNullOrWhiteSpace(path);

        using ResvgOptions options = new();
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
        ArgumentException.ThrowIfNullOrWhiteSpace(data);
        ArgumentNullException.ThrowIfNull(options);

        Resvg resvg = new();
        nuint length = (nuint)Encoding.UTF8.GetByteCount(data);
        try
        {
            NativeMethods.resvg_parse_tree_from_data(data, length, options.Handle, out resvg.tree).Check();
            resvg.Init();
        }
        catch
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
        ArgumentNullException.ThrowIfNull(data);

        using ResvgOptions options = new();
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
        ArgumentNullException.ThrowIfNull(stream);
        ArgumentNullException.ThrowIfNull(options);

        using StreamReader reader = new(stream, leaveOpen: true);
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
        ArgumentNullException.ThrowIfNull(stream);

        using ResvgOptions options = new();
        if (loadSystemFonts)
        {
            options.LoadSystemFonts();
        }
        return FromStream(stream, options);
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

    #endregion
}
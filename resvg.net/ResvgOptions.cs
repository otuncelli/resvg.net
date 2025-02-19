using System;
using System.Runtime.InteropServices;

namespace resvg.net;

/// <summary>
/// SVG parsing and rendering options.
/// </summary>
public sealed class ResvgOptions : IDisposable
{
    internal nint Handle;

    /// <inheritdoc cref="ResvgOptions" />
    public ResvgOptions()
    {
        Handle = NativeMethods.resvg_options_create();
    }

    /// <summary>
    /// Sets a directory that will be used during relative paths resolving.
    /// </summary>
    /// <remarks>
    /// Expected to be the same as the directory that contains the SVG file, but can be set to any.
    /// </remarks>
    /// <param name="path"></param>
    public void SetResourcesDir(string? path)
    {
        NativeMethods.resvg_options_set_resources_dir(Handle, path);
    }

    /// <summary>
    /// Sets the target DPI.
    /// Impact units conversion.
    /// Default: 96
    /// </summary>
    /// <param name="dpi"></param>
    public void SetDpi(float dpi)
    {
        NativeMethods.resvg_options_set_dpi(Handle, dpi);
    }

    /// <summary>
    /// Provides the content of a stylesheet that will be used when resolving CSS attributes.
    /// </summary>
    /// <param name="css"></param>
    public void SetStylesheet(string? css)
    {
        NativeMethods.resvg_options_set_stylesheet(Handle, css);
    }

    /// <summary>
    /// Sets the default font family.
    /// Will be used when no `font-family` attribute is set in the SVG.
    /// Default: Times New Roman
    /// </summary>
    /// <param name="family"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetFontFamily(string family)
    {
        ArgumentNullException.ThrowIfNull(family);

        NativeMethods.resvg_options_set_font_family(Handle, family);
    }

    /// <summary>
    /// Sets the default font size.
    /// Will be used when no `font-size` attribute is set in the SVG.
    /// Default: 12
    /// </summary>
    /// <param name="size"></param>
    public void SetFontSize(float size)
    {
        NativeMethods.resvg_options_set_font_size(Handle, size);
    }

    /// <summary>
    /// Sets the `serif` font family.
    /// Has no effect when the `text` feature is not enabled.
    /// Default: Times New Roman
    /// </summary>
    /// <param name="family"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetSerifFamily(string family)
    {
        ArgumentNullException.ThrowIfNull(family);

        NativeMethods.resvg_options_set_serif_family(Handle, family);
    }

    /// <summary>
    /// Sets the `sans-serif` font family.
    /// Has no effect when the `text` feature is not enabled.
    /// Default: Arial
    /// </summary>
    /// <param name="family"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetSansSerifFamily(string family)
    {
        ArgumentNullException.ThrowIfNull(family);

        NativeMethods.resvg_options_set_sans_serif_family(Handle, family);
    }

    /// <summary>
    /// Sets the `cursive` font family.
    /// Has no effect when the `text` feature is not enabled.
    /// Default: Comic Sans MS
    /// </summary>
    /// <param name="family"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetCursiveFamily(string family)
    {
        ArgumentNullException.ThrowIfNull(family);

        NativeMethods.resvg_options_set_cursive_family(Handle, family);
    }

    /// <summary>
    /// Sets the `fantasy` font family.
    /// Has no effect when the `text` feature is not enabled.
    /// Default: Papyrus on macOS, Impact on other OS'es
    /// </summary>
    /// <param name="family"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetFantasyFamily(string family)
    {
        ArgumentNullException.ThrowIfNull(family);

        NativeMethods.resvg_options_set_fantasy_family(Handle, family);
    }

    /// <summary>
    /// Sets the `monospace` font family.
    /// Has no effect when the `text` feature is not enabled.
    /// Default: Courier New
    /// </summary>
    /// <param name="family"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void SetMonospaceFamily(string family)
    {
        ArgumentNullException.ThrowIfNull(family);

        NativeMethods.resvg_options_set_monospace_family(Handle, family);
    }

    /// <summary>
    /// Sets a comma-separated list of languages.
    /// Will be used to resolve a `systemLanguage` conditional attribute.
    /// Example: en,en-US.
    /// Default: en
    /// </summary>
    /// <param name="languages"></param>
    public void SetLanguages(string? languages)
    {
        NativeMethods.resvg_options_set_languages(Handle, languages);
    }

    /// <summary>
    /// Sets the default shape rendering method.
    /// Will be used when an SVG element's `shape-rendering` property is set to `auto`.
    /// Default: `GeometricPrecision`
    /// </summary>
    /// <param name="mode"></param>
    public void SetShapeRenderingMode(ShapeRenderingMode mode)
    {
        NativeMethods.resvg_options_set_shape_rendering_mode(Handle, mode);
    }

    /// <summary>
    /// Sets the default text rendering method.
    /// Will be used when an SVG element's `text-rendering` property is set to `auto`.
    /// Default: `OptimizeLegibility`
    /// </summary>
    /// <param name="mode"></param>
    public void SetTextRenderingMode(TextRenderingMode mode)
    {
        NativeMethods.resvg_options_set_text_rendering_mode(Handle, mode);
    }

    /// <summary>
    /// Sets the default image rendering method.
    /// Will be used when an SVG element's `image-rendering` property is set to `auto`.
    /// Default: `OptimizeQuality`
    /// </summary>
    /// <param name="mode"></param>
    public void SetImageRenderingMode(ImageRenderingMode mode)
    {
        NativeMethods.resvg_options_set_image_rendering_mode(Handle, mode);
    }

    /// <summary>
    /// Loads a font data into the internal fonts database.
    /// Prints a warning into the log when the data is not a valid TrueType font.
    /// Has no effect when the `text` feature is not enabled.
    /// </summary>
    /// <param name="data"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void LoadFontData(byte[] data)
    {
        ArgumentNullException.ThrowIfNull(data);

        GCHandle gch = GCHandle.Alloc(data, GCHandleType.Pinned);
        try
        {
            NativeMethods.resvg_options_load_font_data(Handle, gch.AddrOfPinnedObject(), (UIntPtr)data.Length);
        }
        finally
        {
            gch.Free();
        }
    }

    /// <summary>
    /// Loads a font file into the internal fonts database.
    /// Prints a warning into the log when the data is not a valid TrueType font.
    /// Has no effect when the `text` feature is not enabled.
    /// </summary>
    /// <param name="filePath"></param>
    /// <exception cref="ArgumentNullException"></exception>
    public void LoadFontFile(string filePath)
    {
        ArgumentNullException.ThrowIfNull(filePath);

        NativeMethods.resvg_options_load_font_file(Handle, filePath).Check();
    }

    /// <summary>
    /// Loads system fonts into the internal fonts database.
    /// </summary>
    /// <remarks>
    /// This method is very IO intensive.
    /// This method should be executed only once per instance.
    /// The system scanning is not perfect, so some fonts may be omitted.
    /// Please send a bug report in this case.
    /// Prints warnings into the log.
    /// Has no effect when the `text` feature is not enabled.
    /// </remarks>
    public void LoadSystemFonts()
    {
        NativeMethods.resvg_options_load_system_fonts(Handle);
    }

    #region IDisposable

    public void Dispose()
    {
        if (Handle != nint.Zero)
        {
            NativeMethods.resvg_options_destroy(Handle);
            Handle = nint.Zero;
        }
    }

    #endregion
}
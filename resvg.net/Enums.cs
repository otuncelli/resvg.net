﻿namespace resvg.net
{
    internal enum ReSvgError
    {
        /// <summary>
        /// Everything is ok.
        /// </summary>
        OK = 0,
        /// <summary>
        /// Only UTF-8 content are supported.
        /// </summary>
        NOT_AN_UTF8_STR,
        /// <summary>
        /// Failed to open the provided file.
        /// </summary>
        FILE_OPEN_FAILED,
        /// <summary>
        /// Compressed SVG must use the GZip algorithm.
        /// </summary>
        MALFORMED_GZIP,
        /// <summary>
        /// We do not allow SVG with more than 1_000_000 elements for security reasons.
        /// </summary>
        ELEMENTS_LIMIT_REACHED,
        /// <summary>
        /// SVG doesn't have a valid size.
        /// Occurs when width and/or height are <= 0.
        /// Also occurs if width, height and viewBox are not set.
        /// </summary>
        INVALID_SIZE,
        /// <summary>
        /// Failed to parse an SVG data.
        /// </summary>
        PARSING_FAILED,
    }

    /// <summary>
    /// "fit to" type.
    /// </summary>
    /// <remarks>
    /// All types produce proportional scaling.
    /// </remarks>
    public enum FitToType
    {
        /// <summary>
        /// Use an original image size.
        /// </summary>
        Original,
        /// <summary>
        /// Fit an image to a specified width.
        /// </summary>
        Width,
        /// <summary>
        /// Fit an image to a specified height.
        /// </summary>
        Height,
        /// <summary>
        /// Zoom an image using scaling factor.
        /// </summary>
        Zoom,
    }

    /// <summary>
    /// Image rendering method.
    /// </summary>
    public enum ImageRenderingMode
    {
        OptimizeQuality,
        OptimizeSpeed
    }

    /// <summary>
    /// Shape rendering method.
    /// </summary>
    public enum ShapeRenderingMode
    {
        OptimizeSpeed,
        CrispEdges,
        GeometricPrecision
    }

    /// <summary>
    /// Text rendering method.
    /// </summary>
    public enum TextRenderingMode
    {
        OptimizeSpeed,
        OptimizeLegibility,
        GeometricPrecision
    }
}

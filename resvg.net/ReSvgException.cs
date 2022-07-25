using System;

namespace resvg.net
{
    public sealed class ReSvgException : Exception
    {
        internal ReSvgException(ReSvgError error) : base(GetMessage(error))
        {
        }

        private static string GetMessage(ReSvgError error)
        {
            switch (error)
            {
                case ReSvgError.OK:
                    return "Everything is ok.";
                case ReSvgError.NOT_AN_UTF8_STR:
                    return "Only UTF-8 content are supported.";
                case ReSvgError.FILE_OPEN_FAILED:
                    return "Failed to open the provided file.";
                case ReSvgError.MALFORMED_GZIP:
                    return "Compressed SVG must use the GZip algorithm.";
                case ReSvgError.ELEMENTS_LIMIT_REACHED:
                    return "We do not allow SVG with more than 1_000_000 elements for security reasons.";
                case ReSvgError.INVALID_SIZE:
                    return @"SVG doesn't have a valid size.
Occurs when width and/or height are <= 0.
Also occurs if width, height and viewBox are not set.";
                case ReSvgError.PARSING_FAILED:
                    return "Failed to parse an SVG data.";
                default:
                    return "Unknown error";
            }
        }
    }
}
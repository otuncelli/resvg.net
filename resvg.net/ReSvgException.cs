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
            return error switch
            {
                ReSvgError.OK => "Everything is ok.",
                ReSvgError.NOT_AN_UTF8_STR => "Only UTF-8 content are supported.",
                ReSvgError.FILE_OPEN_FAILED => "Failed to open the provided file.",
                ReSvgError.MALFORMED_GZIP => "Compressed SVG must use the GZip algorithm.",
                ReSvgError.ELEMENTS_LIMIT_REACHED => "We do not allow SVG with more than 1_000_000 elements for security reasons.",
                ReSvgError.INVALID_SIZE => "SVG doesn't have a valid size. " +
                "Occurs when width and/or height are <= 0. " +
                "Also occurs if width, height and viewBox are not set.",
                ReSvgError.PARSING_FAILED => "Failed to parse an SVG data.",
                _ => "Unknown error",
            };
        }
    }
}
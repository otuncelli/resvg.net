using System;

namespace resvg.net
{
    public sealed class ResvgException : Exception
    {
        internal ResvgException(ResvgError error) : base(GetMessage(error))
        {
        }

        private static string GetMessage(ResvgError error)
        {
            return error switch
            {
                ResvgError.OK => "Everything is ok.",
                ResvgError.NOT_AN_UTF8_STR => "Only UTF-8 content are supported.",
                ResvgError.FILE_OPEN_FAILED => "Failed to open the provided file.",
                ResvgError.MALFORMED_GZIP => "Compressed SVG must use the GZip algorithm.",
                ResvgError.ELEMENTS_LIMIT_REACHED => "We do not allow SVG with more than 1_000_000 elements for security reasons.",
                ResvgError.INVALID_SIZE => "SVG doesn't have a valid size. " +
                "Occurs when width and/or height are <= 0. " +
                "Also occurs if width, height and viewBox are not set.",
                ResvgError.PARSING_FAILED => "Failed to parse an SVG data.",
                _ => "Unknown error",
            };
        }
    }
}
namespace resvg.net;

internal static class Extensions
{
    public static void Check(this ResvgError error)
    {
        if (error != ResvgError.OK)
            throw new ResvgException(error);
    }
}
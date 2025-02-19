using System;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace resvg.net;

internal static unsafe class PixelOperations
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static void ApplyPixelOperation(nint pixmap, int pixcnt, PixelOpFlags flags)
    {
        if (flags.HasFlag(PixelOpFlags.RgbaToBgra))
        {
            ConvertRgbaToBgra(pixmap, pixcnt);
        }
        if (flags.HasFlag(PixelOpFlags.UnPremultiplyAlpha))
        {
            UnPremultiplyAlpha(pixmap, pixcnt);
        }
    }

    private static void ConvertRgbaToBgra(nint pixmap, int pixcnt)
    {
        byte* ptr = (byte*)pixmap;

        if (Avx2.IsSupported && pixcnt >= Vector256<uint>.Count)
        {
            Vector256<byte> vmask = GetMask256([2, 1, 0, 3], sizeof(uint));
            do
            {
                Vector256<byte> v = Avx.LoadVector256(ptr);
                v = Avx2.Shuffle(v, vmask);
                Avx.Store(ptr, v);
                ptr += Vector256<byte>.Count;
                pixcnt -= Vector256<uint>.Count;
            } while (pixcnt >= Vector256<uint>.Count);
        }

        if (Ssse3.IsSupported && pixcnt >= Vector128<uint>.Count)
        {
            Vector128<byte> vmask = GetMask128([2, 1, 0, 3], sizeof(uint));
            do
            {
                Vector128<byte> v = Sse2.LoadVector128(ptr);
                v = Ssse3.Shuffle(v, vmask);
                Sse2.Store(ptr, v);
                ptr += Vector128<byte>.Count;
                pixcnt -= Vector128<uint>.Count;
            } while (pixcnt >= Vector128<uint>.Count);
        }

        while (pixcnt > 0)
        {
            (ptr[0], ptr[2]) = (ptr[2], ptr[0]);
            ptr += sizeof(uint);
            pixcnt--;
        }
    }

    private static void UnPremultiplyAlpha(nint pixmap, int pixcnt)
    {
        // Adapted from:
        // https://github.com/ermig1979/Simd/issues/194
        // https://gist.github.com/saucecontrol/77efe86bc8ab96d70b9045e71db7447e

        byte* ptr = (byte*)pixmap;

        if (Avx2.IsSupported && pixcnt >= Vector256<uint>.Count)
        {
            var vmask0 = Vector256.Create(0x000000ff).AsByte();
            var vmask1 = Vector256.Create(0x80808001, 0x80808005, 0x80808009, 0x8080800d, 0x80808001, 0x80808005, 0x80808009, 0x8080800d).AsByte();
            var vmask2 = Vector256.Create(0x80808002, 0x80808006, 0x8080800a, 0x8080800e, 0x80808002, 0x80808006, 0x8080800a, 0x8080800e).AsByte();
            var vmask3 = Vector256.Create(0x80808003, 0x80808007, 0x8080800b, 0x8080800f, 0x80808003, 0x80808007, 0x8080800b, 0x8080800f).AsByte();
            var vmaskf128 = GetMask128([0, 4, 8, 12], 1);
            var vmaskf = Vector256.Create(vmaskf128, vmaskf128).AsByte();
            var vscale = Vector256.Create((float)0xff00ff);

            do
            {
                var vi = Avx.LoadVector256(ptr);
                var vi3 = Avx2.Shuffle(vi, vmask3).AsInt32();
                var vim = Avx.ConvertToVector256Int32WithTruncation(Avx.Divide(vscale, Avx.ConvertToVector256Single(vi3)));
                vim = Avx2.AndNot(Avx2.CompareEqual(vi3, Vector256<int>.Zero), vim);

                var vi2 = Avx2.Shuffle(vi, vmask2).AsInt32();
                var vi1 = Avx2.Shuffle(vi, vmask1).AsInt32();
                var vi0 = Avx2.And(vi, vmask0).AsInt32();

                vi0 = Avx2.MultiplyLow(vi0, vim);
                vi1 = Avx2.MultiplyLow(vi1, vim);
                vi2 = Avx2.MultiplyLow(vi2, vim);

                vi0 = Avx2.ShiftRightLogical(vi0, 16);
                vi1 = Avx2.ShiftRightLogical(vi1, 16);
                vi2 = Avx2.ShiftRightLogical(vi2, 16);

                var vil = Avx2.PackSignedSaturate(vi0, vi1);
                var vih = Avx2.PackSignedSaturate(vi2, vi3);
                vi = Avx2.PackUnsignedSaturate(vil, vih);

                Avx.Store(ptr, Avx2.Shuffle(vi, vmaskf));
                ptr += Vector256<byte>.Count;
                pixcnt -= Vector256<uint>.Count;
            }
            while (pixcnt >= Vector256<uint>.Count);
        }

        if (Sse41.IsSupported && pixcnt >= Vector128<uint>.Count)
        {
            var vmask0 = Vector128.Create(0x000000ff).AsByte();
            var vmask1 = Vector128.Create(0x80808001, 0x80808005, 0x80808009, 0x8080800d).AsByte();
            var vmask2 = Vector128.Create(0x80808002, 0x80808006, 0x8080800a, 0x8080800e).AsByte();
            var vmask3 = Vector128.Create(0x80808003, 0x80808007, 0x8080800b, 0x8080800f).AsByte();
            var vmaskf = GetMask128([0, 4, 8, 12], 1);
            var vscale = Vector128.Create((float)0xff00ff);

            do
            {
                var vi = Sse2.LoadVector128(ptr);
                var vi3 = Ssse3.Shuffle(vi, vmask3).AsInt32();
                var vim = Sse2.ConvertToVector128Int32WithTruncation(Sse.Divide(vscale, Sse2.ConvertToVector128Single(vi3)));
                vim = Sse2.AndNot(Sse2.CompareEqual(vi3, Vector128<int>.Zero), vim);

                var vi2 = Ssse3.Shuffle(vi, vmask2).AsInt32();
                var vi1 = Ssse3.Shuffle(vi, vmask1).AsInt32();
                var vi0 = Sse2.And(vi, vmask0).AsInt32();

                vi0 = Sse41.MultiplyLow(vi0, vim);
                vi1 = Sse41.MultiplyLow(vi1, vim);
                vi2 = Sse41.MultiplyLow(vi2, vim);

                vi0 = Sse2.ShiftRightLogical(vi0, 16);
                vi1 = Sse2.ShiftRightLogical(vi1, 16);
                vi2 = Sse2.ShiftRightLogical(vi2, 16);

                var vil = Sse2.PackSignedSaturate(vi0, vi1);
                var vih = Sse2.PackSignedSaturate(vi2, vi3);
                vi = Sse2.PackUnsignedSaturate(vil, vih);

                Sse2.Store(ptr, Ssse3.Shuffle(vi, vmaskf));
                ptr += Vector128<byte>.Count;
                pixcnt -= Vector128<uint>.Count;
            }
            while (pixcnt >= Vector128<uint>.Count);
        }

        while (pixcnt > 0)
        {
            uint a = ptr[3];
            if (a == 0)
            {
                *(uint*)ptr = 0;
            }
            else
            {
                uint ai = 0xff00ff / a;
                UnPremultiply(ref ptr[0], ai);
                UnPremultiply(ref ptr[1], ai);
                UnPremultiply(ref ptr[2], ai);
            }
            ptr += sizeof(uint);
            pixcnt--;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static void UnPremultiply(ref byte color, uint alpha)
    {
        color = (byte)Math.Min(color * alpha >> 16, byte.MaxValue);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector256<byte> GetMask256(ReadOnlySpan<byte> fourBytesOrder, int increment)
    {
        Span<byte> mask = stackalloc byte[Vector256<byte>.Count];
        for (int i = 0; i < Vector256<byte>.Count; i++)
        {
            (int quo, int rem) = Math.DivRem(i, sizeof(uint));
            mask[i] = (byte)(fourBytesOrder[rem] + quo * increment);
        }
        return Vector256.Create<byte>(mask);
    }

    [SkipLocalsInit]
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Vector128<byte> GetMask128(ReadOnlySpan<byte> fourBytesOrder, int increment)
    {
        Span<byte> mask = stackalloc byte[Vector128<byte>.Count];
        for (int i = 0; i < Vector128<byte>.Count; i++)
        {
            (int quo, int rem) = Math.DivRem(i, sizeof(uint));
            mask[i] = (byte)(fourBytesOrder[rem] + quo * increment);
        }
        return Vector128.Create<byte>(mask);
    }
}
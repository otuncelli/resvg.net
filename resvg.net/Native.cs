using System;
using System.Runtime.InteropServices;

namespace resvg.net
{
    internal static partial class Native
    {
        #region resvg_transform_identity

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_transform_identity")]
            public static extern resvg_transform resvg_transform_identity_X86();
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_transform_identity")]
            public static extern resvg_transform resvg_transform_identity_X64();
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_transform_identity")]
            public static extern resvg_transform resvg_transform_identity_Arm64();
        }

        public static resvg_transform resvg_transform_identity()
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_transform_identity_X86();
                case Architecture.X64:
                    return PlatformInvoke.resvg_transform_identity_X64();
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_transform_identity_Arm64();
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_init_log

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_init_log")]
            public static extern void resvg_init_log_X86();
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_init_log")]
            public static extern void resvg_init_log_X64();
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_init_log")]
            public static extern void resvg_init_log_Arm64();
        }

        public static void resvg_init_log()
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_init_log_X86();
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_init_log_X64();
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_init_log_Arm64();
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_create

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_create")]
            public static extern IntPtr resvg_options_create_X86();
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_create")]
            public static extern IntPtr resvg_options_create_X64();
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_create")]
            public static extern IntPtr resvg_options_create_Arm64();
        }

        public static IntPtr resvg_options_create()
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_options_create_X86();
                case Architecture.X64:
                    return PlatformInvoke.resvg_options_create_X64();
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_options_create_Arm64();
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_resources_dir

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_resources_dir")]
            public static extern void resvg_options_set_resources_dir_X86(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string path);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_resources_dir")]
            public static extern void resvg_options_set_resources_dir_X64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string path);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_resources_dir")]
            public static extern void resvg_options_set_resources_dir_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string path);
        }

        public static void resvg_options_set_resources_dir(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string path)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_resources_dir_X86(opt, path);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_resources_dir_X64(opt, path);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_resources_dir_Arm64(opt, path);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_dpi

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_dpi")]
            public static extern void resvg_options_set_dpi_X86(IntPtr opt, double dpi);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_dpi")]
            public static extern void resvg_options_set_dpi_X64(IntPtr opt, double dpi);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_dpi")]
            public static extern void resvg_options_set_dpi_Arm64(IntPtr opt, double dpi);
        }

        public static void resvg_options_set_dpi(IntPtr opt, double dpi)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_dpi_X86(opt, dpi);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_dpi_X64(opt, dpi);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_dpi_Arm64(opt, dpi);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_font_family

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_font_family")]
            public static extern void resvg_options_set_font_family_X86(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_font_family")]
            public static extern void resvg_options_set_font_family_X64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_font_family")]
            public static extern void resvg_options_set_font_family_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
        }

        public static void resvg_options_set_font_family(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_font_family_X86(opt, family);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_font_family_X64(opt, family);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_font_family_Arm64(opt, family);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_font_size

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_font_size")]
            public static extern void resvg_options_set_font_size_X86(IntPtr opt, double size);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_font_size")]
            public static extern void resvg_options_set_font_size_X64(IntPtr opt, double size);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_font_size")]
            public static extern void resvg_options_set_font_size_Arm64(IntPtr opt, double size);
        }

        public static void resvg_options_set_font_size(IntPtr opt, double size)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_font_size_X86(opt, size);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_font_size_X64(opt, size);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_font_size_Arm64(opt, size);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_serif_family

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_serif_family")]
            public static extern void resvg_options_set_serif_family_X86(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_serif_family")]
            public static extern void resvg_options_set_serif_family_X64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_serif_family")]
            public static extern void resvg_options_set_serif_family_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
        }

        public static void resvg_options_set_serif_family(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_serif_family_X86(opt, family);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_serif_family_X64(opt, family);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_serif_family_Arm64(opt, family);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_sans_serif_family

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_sans_serif_family")]
            public static extern void resvg_options_set_sans_serif_family_X86(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_sans_serif_family")]
            public static extern void resvg_options_set_sans_serif_family_X64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_sans_serif_family")]
            public static extern void resvg_options_set_sans_serif_family_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
        }

        public static void resvg_options_set_sans_serif_family(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_sans_serif_family_X86(opt, family);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_sans_serif_family_X64(opt, family);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_sans_serif_family_Arm64(opt, family);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_cursive_family

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_cursive_family")]
            public static extern void resvg_options_set_cursive_family_X86(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_cursive_family")]
            public static extern void resvg_options_set_cursive_family_X64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_cursive_family")]
            public static extern void resvg_options_set_cursive_family_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
        }

        public static void resvg_options_set_cursive_family(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_cursive_family_X86(opt, family);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_cursive_family_X64(opt, family);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_cursive_family_Arm64(opt, family);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_fantasy_family

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_fantasy_family")]
            public static extern void resvg_options_set_fantasy_family_X86(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_fantasy_family")]
            public static extern void resvg_options_set_fantasy_family_X64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_fantasy_family")]
            public static extern void resvg_options_set_fantasy_family_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
        }

        public static void resvg_options_set_fantasy_family(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_fantasy_family_X86(opt, family);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_fantasy_family_X64(opt, family);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_fantasy_family_Arm64(opt, family);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_monospace_family

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_monospace_family")]
            public static extern void resvg_options_set_monospace_family_X86(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_monospace_family")]
            public static extern void resvg_options_set_monospace_family_X64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_monospace_family")]
            public static extern void resvg_options_set_monospace_family_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family);
        }

        public static void resvg_options_set_monospace_family(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string family)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_monospace_family_X86(opt, family);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_monospace_family_X64(opt, family);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_monospace_family_Arm64(opt, family);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_languages

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_languages")]
            public static extern void resvg_options_set_languages_X86(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string languages);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_languages")]
            public static extern void resvg_options_set_languages_X64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string languages);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_languages")]
            public static extern void resvg_options_set_languages_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string languages);
        }

        public static void resvg_options_set_languages(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string languages)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_languages_X86(opt, languages);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_languages_X64(opt, languages);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_languages_Arm64(opt, languages);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_shape_rendering_mode

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_shape_rendering_mode")]
            public static extern void resvg_options_set_shape_rendering_mode_X86(IntPtr opt, ShapeRenderingMode mode);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_shape_rendering_mode")]
            public static extern void resvg_options_set_shape_rendering_mode_X64(IntPtr opt, ShapeRenderingMode mode);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_shape_rendering_mode")]
            public static extern void resvg_options_set_shape_rendering_mode_Arm64(IntPtr opt, ShapeRenderingMode mode);
        }

        public static void resvg_options_set_shape_rendering_mode(IntPtr opt, ShapeRenderingMode mode)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_shape_rendering_mode_X86(opt, mode);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_shape_rendering_mode_X64(opt, mode);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_shape_rendering_mode_Arm64(opt, mode);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_text_rendering_mode

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_text_rendering_mode")]
            public static extern void resvg_options_set_text_rendering_mode_X86(IntPtr opt, TextRenderingMode mode);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_text_rendering_mode")]
            public static extern void resvg_options_set_text_rendering_mode_X64(IntPtr opt, TextRenderingMode mode);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_text_rendering_mode")]
            public static extern void resvg_options_set_text_rendering_mode_Arm64(IntPtr opt, TextRenderingMode mode);
        }

        public static void resvg_options_set_text_rendering_mode(IntPtr opt, TextRenderingMode mode)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_text_rendering_mode_X86(opt, mode);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_text_rendering_mode_X64(opt, mode);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_text_rendering_mode_Arm64(opt, mode);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_image_rendering_mode

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_image_rendering_mode")]
            public static extern void resvg_options_set_image_rendering_mode_X86(IntPtr opt, ImageRenderingMode mode);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_image_rendering_mode")]
            public static extern void resvg_options_set_image_rendering_mode_X64(IntPtr opt, ImageRenderingMode mode);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_image_rendering_mode")]
            public static extern void resvg_options_set_image_rendering_mode_Arm64(IntPtr opt, ImageRenderingMode mode);
        }

        public static void resvg_options_set_image_rendering_mode(IntPtr opt, ImageRenderingMode mode)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_image_rendering_mode_X86(opt, mode);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_image_rendering_mode_X64(opt, mode);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_image_rendering_mode_Arm64(opt, mode);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_set_keep_named_groups

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_keep_named_groups")]
            public static extern void resvg_options_set_keep_named_groups_X86(IntPtr opt, [MarshalAs(UnmanagedType.Bool)] bool keep);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_keep_named_groups")]
            public static extern void resvg_options_set_keep_named_groups_X64(IntPtr opt, [MarshalAs(UnmanagedType.Bool)] bool keep);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_set_keep_named_groups")]
            public static extern void resvg_options_set_keep_named_groups_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.Bool)] bool keep);
        }

        public static void resvg_options_set_keep_named_groups(IntPtr opt, [MarshalAs(UnmanagedType.Bool)] bool keep)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_set_keep_named_groups_X86(opt, keep);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_set_keep_named_groups_X64(opt, keep);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_set_keep_named_groups_Arm64(opt, keep);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_load_font_data

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_load_font_data")]
            public static extern void resvg_options_load_font_data_X86(IntPtr opt, IntPtr data, UIntPtr length);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_load_font_data")]
            public static extern void resvg_options_load_font_data_X64(IntPtr opt, IntPtr data, UIntPtr length);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_load_font_data")]
            public static extern void resvg_options_load_font_data_Arm64(IntPtr opt, IntPtr data, UIntPtr length);
        }

        public static void resvg_options_load_font_data(IntPtr opt, IntPtr data, UIntPtr length)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_load_font_data_X86(opt, data, length);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_load_font_data_X64(opt, data, length);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_load_font_data_Arm64(opt, data, length);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_load_font_file

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_load_font_file")]
            public static extern void resvg_options_load_font_file_X86(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string file_path);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_load_font_file")]
            public static extern void resvg_options_load_font_file_X64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string file_path);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_load_font_file")]
            public static extern void resvg_options_load_font_file_Arm64(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string file_path);
        }

        public static void resvg_options_load_font_file(IntPtr opt, [MarshalAs(UnmanagedType.LPUTF8Str)] string file_path)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_load_font_file_X86(opt, file_path);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_load_font_file_X64(opt, file_path);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_load_font_file_Arm64(opt, file_path);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_load_system_fonts

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_load_system_fonts")]
            public static extern void resvg_options_load_system_fonts_X86(IntPtr opt);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_load_system_fonts")]
            public static extern void resvg_options_load_system_fonts_X64(IntPtr opt);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_load_system_fonts")]
            public static extern void resvg_options_load_system_fonts_Arm64(IntPtr opt);
        }

        public static void resvg_options_load_system_fonts(IntPtr opt)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_load_system_fonts_X86(opt);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_load_system_fonts_X64(opt);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_load_system_fonts_Arm64(opt);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_options_destroy

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_destroy")]
            public static extern void resvg_options_destroy_X86(IntPtr opt);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_destroy")]
            public static extern void resvg_options_destroy_X64(IntPtr opt);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_options_destroy")]
            public static extern void resvg_options_destroy_Arm64(IntPtr opt);
        }

        public static void resvg_options_destroy(IntPtr opt)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_options_destroy_X86(opt);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_options_destroy_X64(opt);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_options_destroy_Arm64(opt);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_parse_tree_from_file

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_parse_tree_from_file")]
            public static extern ReSvgError resvg_parse_tree_from_file_X86([MarshalAs(UnmanagedType.LPUTF8Str)] string file_path, IntPtr opt, out IntPtr tree);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_parse_tree_from_file")]
            public static extern ReSvgError resvg_parse_tree_from_file_X64([MarshalAs(UnmanagedType.LPUTF8Str)] string file_path, IntPtr opt, out IntPtr tree);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_parse_tree_from_file")]
            public static extern ReSvgError resvg_parse_tree_from_file_Arm64([MarshalAs(UnmanagedType.LPUTF8Str)] string file_path, IntPtr opt, out IntPtr tree);
        }

        public static ReSvgError resvg_parse_tree_from_file([MarshalAs(UnmanagedType.LPUTF8Str)] string file_path, IntPtr opt, out IntPtr tree)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_parse_tree_from_file_X86(file_path, opt, out tree);
                case Architecture.X64:
                    return PlatformInvoke.resvg_parse_tree_from_file_X64(file_path, opt, out tree);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_parse_tree_from_file_Arm64(file_path, opt, out tree);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_parse_tree_from_data

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_parse_tree_from_data")]
            public static extern ReSvgError resvg_parse_tree_from_data_X86([MarshalAs(UnmanagedType.LPUTF8Str)] string data, UIntPtr length, IntPtr opt, out IntPtr tree);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_parse_tree_from_data")]
            public static extern ReSvgError resvg_parse_tree_from_data_X64([MarshalAs(UnmanagedType.LPUTF8Str)] string data, UIntPtr length, IntPtr opt, out IntPtr tree);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_parse_tree_from_data")]
            public static extern ReSvgError resvg_parse_tree_from_data_Arm64([MarshalAs(UnmanagedType.LPUTF8Str)] string data, UIntPtr length, IntPtr opt, out IntPtr tree);
        }

        public static ReSvgError resvg_parse_tree_from_data([MarshalAs(UnmanagedType.LPUTF8Str)] string data, UIntPtr length, IntPtr opt, out IntPtr tree)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_parse_tree_from_data_X86(data, length, opt, out tree);
                case Architecture.X64:
                    return PlatformInvoke.resvg_parse_tree_from_data_X64(data, length, opt, out tree);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_parse_tree_from_data_Arm64(data, length, opt, out tree);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_is_image_empty

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_is_image_empty")]
            public static extern bool resvg_is_image_empty_X86(IntPtr tree);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_is_image_empty")]
            public static extern bool resvg_is_image_empty_X64(IntPtr tree);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_is_image_empty")]
            public static extern bool resvg_is_image_empty_Arm64(IntPtr tree);
        }

        public static bool resvg_is_image_empty(IntPtr tree)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_is_image_empty_X86(tree);
                case Architecture.X64:
                    return PlatformInvoke.resvg_is_image_empty_X64(tree);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_is_image_empty_Arm64(tree);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_get_image_size

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_image_size")]
            public static extern resvg_size resvg_get_image_size_X86(IntPtr tree);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_image_size")]
            public static extern resvg_size resvg_get_image_size_X64(IntPtr tree);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_image_size")]
            public static extern resvg_size resvg_get_image_size_Arm64(IntPtr tree);
        }

        public static resvg_size resvg_get_image_size(IntPtr tree)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_get_image_size_X86(tree);
                case Architecture.X64:
                    return PlatformInvoke.resvg_get_image_size_X64(tree);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_get_image_size_Arm64(tree);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_get_image_viewbox

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_image_viewbox")]
            public static extern resvg_rect resvg_get_image_viewbox_X86(IntPtr tree);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_image_viewbox")]
            public static extern resvg_rect resvg_get_image_viewbox_X64(IntPtr tree);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_image_viewbox")]
            public static extern resvg_rect resvg_get_image_viewbox_Arm64(IntPtr tree);
        }

        public static resvg_rect resvg_get_image_viewbox(IntPtr tree)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_get_image_viewbox_X86(tree);
                case Architecture.X64:
                    return PlatformInvoke.resvg_get_image_viewbox_X64(tree);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_get_image_viewbox_Arm64(tree);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_get_image_bbox

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_image_bbox")]
            public static extern bool resvg_get_image_bbox_X86(IntPtr tree, out resvg_rect bbox);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_image_bbox")]
            public static extern bool resvg_get_image_bbox_X64(IntPtr tree, out resvg_rect bbox);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_image_bbox")]
            public static extern bool resvg_get_image_bbox_Arm64(IntPtr tree, out resvg_rect bbox);
        }

        public static bool resvg_get_image_bbox(IntPtr tree, out resvg_rect bbox)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_get_image_bbox_X86(tree, out bbox);
                case Architecture.X64:
                    return PlatformInvoke.resvg_get_image_bbox_X64(tree, out bbox);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_get_image_bbox_Arm64(tree, out bbox);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_node_exists

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_node_exists")]
            public static extern bool resvg_node_exists_X86(IntPtr tree, string id);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_node_exists")]
            public static extern bool resvg_node_exists_X64(IntPtr tree, string id);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_node_exists")]
            public static extern bool resvg_node_exists_Arm64(IntPtr tree, string id);
        }

        public static bool resvg_node_exists(IntPtr tree, string id)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_node_exists_X86(tree, id);
                case Architecture.X64:
                    return PlatformInvoke.resvg_node_exists_X64(tree, id);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_node_exists_Arm64(tree, id);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_get_node_transform

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_node_transform")]
            public static extern bool resvg_get_node_transform_X86(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, out resvg_transform transform);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_node_transform")]
            public static extern bool resvg_get_node_transform_X64(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, out resvg_transform transform);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_node_transform")]
            public static extern bool resvg_get_node_transform_Arm64(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, out resvg_transform transform);
        }

        public static bool resvg_get_node_transform(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, out resvg_transform transform)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_get_node_transform_X86(tree, id, out transform);
                case Architecture.X64:
                    return PlatformInvoke.resvg_get_node_transform_X64(tree, id, out transform);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_get_node_transform_Arm64(tree, id, out transform);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_get_node_bbox

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_node_bbox")]
            public static extern bool resvg_get_node_bbox_X86(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, out resvg_rect bbox);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_node_bbox")]
            public static extern bool resvg_get_node_bbox_X64(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, out resvg_rect bbox);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_get_node_bbox")]
            public static extern bool resvg_get_node_bbox_Arm64(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, out resvg_rect bbox);
        }

        public static bool resvg_get_node_bbox(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, out resvg_rect bbox)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_get_node_bbox_X86(tree, id, out bbox);
                case Architecture.X64:
                    return PlatformInvoke.resvg_get_node_bbox_X64(tree, id, out bbox);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_get_node_bbox_Arm64(tree, id, out bbox);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_tree_destroy

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_tree_destroy")]
            public static extern bool resvg_tree_destroy_X86(IntPtr tree);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_tree_destroy")]
            public static extern bool resvg_tree_destroy_X64(IntPtr tree);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_tree_destroy")]
            public static extern bool resvg_tree_destroy_Arm64(IntPtr tree);
        }

        public static bool resvg_tree_destroy(IntPtr tree)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    return PlatformInvoke.resvg_tree_destroy_X86(tree);
                case Architecture.X64:
                    return PlatformInvoke.resvg_tree_destroy_X64(tree);
                case Architecture.Arm64:
                    return PlatformInvoke.resvg_tree_destroy_Arm64(tree);
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_render

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_render")]
            public static extern void resvg_render_X86(IntPtr tree, resvg_fit_to fit_to, resvg_transform transform, uint width, uint height, IntPtr pixmap);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_render")]
            public static extern void resvg_render_X64(IntPtr tree, resvg_fit_to fit_to, resvg_transform transform, uint width, uint height, IntPtr pixmap);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_render")]
            public static extern void resvg_render_Arm64(IntPtr tree, resvg_fit_to fit_to, resvg_transform transform, uint width, uint height, IntPtr pixmap);
        }

        public static void resvg_render(IntPtr tree, resvg_fit_to fit_to, resvg_transform transform, uint width, uint height, IntPtr pixmap)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_render_X86(tree, fit_to, transform, width, height, pixmap);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_render_X64(tree, fit_to, transform, width, height, pixmap);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_render_Arm64(tree, fit_to, transform, width, height, pixmap);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

        #region resvg_render_node

        private static partial class PlatformInvoke
        {
            [DllImport("resvg_X86", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_render_node")]
            public static extern void resvg_render_node_X86(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, resvg_fit_to fit_to, resvg_transform transform, uint width, uint height, IntPtr pixmap);
            [DllImport("resvg_X64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_render_node")]
            public static extern void resvg_render_node_X64(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, resvg_fit_to fit_to, resvg_transform transform, uint width, uint height, IntPtr pixmap);
            [DllImport("resvg_Arm64", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "resvg_render_node")]
            public static extern void resvg_render_node_Arm64(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, resvg_fit_to fit_to, resvg_transform transform, uint width, uint height, IntPtr pixmap);
        }

        public static void resvg_render_node(IntPtr tree, [MarshalAs(UnmanagedType.LPUTF8Str)] string id, resvg_fit_to fit_to, resvg_transform transform, uint width, uint height, IntPtr pixmap)
        {
            switch (RuntimeInformation.ProcessArchitecture)
            {
                case Architecture.X86:
                    PlatformInvoke.resvg_render_node_X86(tree, id, fit_to, transform, width, height, pixmap);
                    break;
                case Architecture.X64:
                    PlatformInvoke.resvg_render_node_X64(tree, id, fit_to, transform, width, height, pixmap);
                    break;
                case Architecture.Arm64:
                    PlatformInvoke.resvg_render_node_Arm64(tree, id, fit_to, transform, width, height, pixmap);
                    break;
                default:
                    throw new PlatformNotSupportedException();
            }
        }

        #endregion

    }
}


#if USE_DELEGATES
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace resvg.net
{
    internal static partial class NativeMethods
    {
        private static readonly string Extension = GetExtension();

        private static readonly ConcurrentDictionary<string, IntPtr> LoadedLibraries = new ConcurrentDictionary<string, IntPtr>();

        private static string GetExtension()
        {
            if (PlatformConfiguration.IsWindows) return ".dll";
            if (PlatformConfiguration.IsMac) return ".dylib";
            return ".so";
        }

        public static void FreeLibraries()
        {
            ICollection<string> keys = LoadedLibraries.Keys;
            foreach (string key in keys)
            {
                if (LoadedLibraries.TryRemove(key, out IntPtr lib))
                {
                    NativeLibrary.Free(lib);
                }
            }
        }

        private static TDelegate GetDelegateForFunction<TDelegate>(string libraryName, string procName) where TDelegate : Delegate
        {
            IntPtr lib = LoadedLibraries.GetOrAdd(libraryName, GetLibrary);
            IntPtr fptr = NativeLibrary.GetExport(lib, procName);
            return Marshal.GetDelegateForFunctionPointer<TDelegate>(fptr);
        }

        private static IntPtr GetLibrary(string libraryName)
        {
            string libraryPath = GetLibraryPath(libraryName);
            IntPtr handle = NativeLibrary.Load(libraryPath);
            if (handle == IntPtr.Zero)
            {
                throw new DllNotFoundException($"Unable to load library '{libraryName}'.");
            }
            return handle;
        }

        private static string GetLibraryPath(string libraryName)
        {
            string arch = PlatformConfiguration.Is64Bit
                ? PlatformConfiguration.IsArm ? "arm64" : "x64"
                : PlatformConfiguration.IsArm ? "arm" : "x86";

            string libWithExt = libraryName;
            if (!libraryName.EndsWith(Extension, StringComparison.OrdinalIgnoreCase))
                libWithExt += Extension;

            // 1. try alongside managed assembly
            string path = Assembly.GetExecutingAssembly().Location;
            if (!string.IsNullOrEmpty(path))
            {
                path = Path.GetDirectoryName(path);
                if (CheckLibraryPath(path, arch, libWithExt, out string localLib))
                    return localLib;
            }

            // 2. try current directory
            if (CheckLibraryPath(Directory.GetCurrentDirectory(), arch, libWithExt, out string lib))
                return lib;

            // 3. try app domain
            try
            {
                if (AppDomain.CurrentDomain is AppDomain domain)
                {
                    // 3.1 RelativeSearchPath
                    if (CheckLibraryPath(domain.RelativeSearchPath, arch, libWithExt, out lib))
                        return lib;

                    // 3.2 BaseDirectory
                    if (CheckLibraryPath(domain.BaseDirectory, arch, libWithExt, out lib))
                        return lib;
                }
            }
            catch
            {
                // no-op as there may not be any domain or path
            }

            // 4. use PATH or default loading mechanism
            return libWithExt;
        }

        private static bool CheckLibraryPath(string root, string arch, string libWithExt, out string foundPath)
        {
            if (!string.IsNullOrEmpty(root))
            {
                // a. in specific platform sub dir
                if (!string.IsNullOrEmpty(PlatformConfiguration.LinuxFlavor))
                {
                    var muslLib = Path.Combine(root, PlatformConfiguration.LinuxFlavor + "-" + arch, libWithExt);
                    if (File.Exists(muslLib))
                    {
                        foundPath = muslLib;
                        return true;
                    }
                }

                // b. in generic platform sub dir
                string searchLib = Path.Combine(root, arch, libWithExt);
                if (File.Exists(searchLib))
                {
                    foundPath = searchLib;
                    return true;
                }

                searchLib = Path.Combine(root, Path.GetFileNameWithoutExtension(libWithExt) + "_" + arch + Extension);
                if (File.Exists(searchLib))
                {
                    foundPath = searchLib;
                    return true;
                }

                // c. in root
                searchLib = Path.Combine(root, libWithExt);
                if (File.Exists(searchLib))
                {
                    foundPath = searchLib;
                    return true;
                }
            }

            // d. nothing
            foundPath = null;
            return false;
        }

        private static class PlatformConfiguration
        {
            public static bool IsUnix { get; }

            public static bool IsWindows { get; }

            public static bool IsMac { get; }

            public static bool IsLinux { get; }

            public static bool IsArm { get; }

            public static bool Is64Bit { get; }

            static PlatformConfiguration()
            {
                IsMac = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
                IsLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
                IsUnix = IsMac || IsLinux;
                IsWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
                Architecture arch = RuntimeInformation.ProcessArchitecture;
                IsArm = arch == Architecture.Arm || arch == Architecture.Arm64;
                Is64Bit = Environment.Is64BitProcess;
            }

            private static string linuxFlavor;

            public static string LinuxFlavor
            {
                get
                {
                    if (!IsLinux)
                        return null;

                    if (!string.IsNullOrEmpty(linuxFlavor))
                        return linuxFlavor;

                    // we only check for musl/glibc right now
                    if (!IsGlibc)
                        return "musl";

                    return null;
                }
                set => linuxFlavor = value;
            }

            private static readonly Lazy<bool> isGlibcLazy = new Lazy<bool>(IsGlibcImplementation);

            public static bool IsGlibc => IsLinux && isGlibcLazy.Value;

            private static bool IsGlibcImplementation()
            {
                try
                {
                    gnu_get_libc_version();
                    return true;
                }
                catch (TypeLoadException)
                {
                    return false;
                }
            }

            [DllImport("c", ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
            private static extern IntPtr gnu_get_libc_version();
        }
    }
}
#endif
﻿using System;
using System.IO;
using System.Reflection;

namespace Chroma.Plutonium.Boot
{
    public class ModuleInitializer
    {
        public static void Initialize()
        {
            var appDir = AppContext.BaseDirectory;
            string resourcePath;
            string targetFile;

            if (OperatingSystem.IsWindows())
            {
                targetFile = "nuklear.dll";
                resourcePath = $"Chroma.Plutonium.Binaries.windows_64.{targetFile}";
            }
            else if (OperatingSystem.IsLinux())
            {
                targetFile = "libnuklear.so";
                resourcePath = $"Chroma.Plutonium.Binaries.linux_64.{targetFile}";
            }
            else
            {
                throw new NotSupportedException("Your platform is not supported by Nuklear GUI for Chroma.");
            }

            using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcePath);
            using var ms = new MemoryStream();

            stream.CopyTo(ms);

            File.WriteAllBytes(
                Path.Combine(appDir, targetFile),
                ms.ToArray()
            );
        }
    }
}
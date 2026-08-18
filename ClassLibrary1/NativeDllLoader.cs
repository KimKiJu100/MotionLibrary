using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class NativeDllLoader
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool SetDllDirectory(string lpPathName);

        public static void Initialize()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string nativeDir = Environment.Is64BitProcess
                ? Path.Combine(baseDir, "x64")
                : Path.Combine(baseDir, "x86");

            if (!SetDllDirectory(nativeDir))
            {
                throw new InvalidOperationException(
                    $"Native DLL 경로 설정 실패: {nativeDir}");
            }
        }
    }
}

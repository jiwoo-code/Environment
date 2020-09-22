using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EnvironmentTest.Common
{
    public static class Define
    {
        public readonly static string DefaultDirPath = $@"{AppDomain.CurrentDomain.BaseDirectory}";
        public readonly static string ConfDirPath = Path.Combine(DefaultDirPath, "Conf");
        public readonly static string LogsDirPath = Path.Combine(DefaultDirPath, "Logs");
        public readonly static string DownloadDirPath = Path.Combine(DefaultDirPath, "Downloads");

    }
}

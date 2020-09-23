using Library.Common.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Library.Common.Utilities
{
    public static class DirectoryUtilities
    {
        public static string CreateDirectory(string directoryPath)
        {
            if (!Path.IsPathRooted(directoryPath))
            {
                throw new ArgumentException(@$"[{directoryPath}] {Resources.ERROR_MSG_IS_NOT_PATH_ROOTED}");
            }

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            return directoryPath;
        }
    }
}

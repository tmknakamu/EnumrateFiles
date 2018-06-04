using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EnumrateFilesLibs
{
    public class FileEnumerator
    {
        public IEnumerable<FileInfo> Enumerate( string folderPath )
        {
            return Directory
               .EnumerateFiles(folderPath, "*", SearchOption.AllDirectories)
               .Select(p => new FileInfo(p))
               .Distinct(new FileInfoComparer());
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace EnumrateFilesLibs
{
    class FileInfoComparer : EqualityComparer<FileInfo>
    {
        public override bool Equals(FileInfo p1, FileInfo p2)
        {
            if (Object.Equals(p1, p2))
            {
                return true;
            }

            if (p1 == null || p2 == null)
            {
                return false;
            }

            if (p1.Name != p2.Name)
            {
                return false;
            }

            if (p1.Length != p2.Length)
            {
                return false;
            }

            return p1.GetMD5().SequenceEqual(p2.GetMD5());
        } 

        public override int GetHashCode(FileInfo p)
        {
            return p.Name.GetHashCode();
        }
    }

    static class FileInfoHelper
    {
        public static byte[] GetMD5(this FileInfo self)
        {
            // 対象ファイルを開い、ComputeHashメソッドを呼び出してMD5計算を行う
            using (FileStream fs = System.IO.File.Open(self.FullName, FileMode.Open, FileAccess.Read))
            {
                var md5 = MD5.Create();
                return md5.ComputeHash(fs);
            }
        }
    }
}

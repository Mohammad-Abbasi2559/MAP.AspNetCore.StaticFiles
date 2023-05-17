using ByteSizeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace MAP.AspNetCore.StaticFiles.FilesAction.Actions
{
    internal static class FileSize
    {
        public static string Size(long size)
        {
            var fileSizeBit = ByteSize.FromBytes(Convert.ToInt32(size));

            if (1024 > fileSizeBit.KiloBytes)
            {
                return  Convert.ToString(fileSizeBit.KiloBytes);
            }
            else if (1024 > fileSizeBit.MegaBytes)
            {
                return Convert.ToString(fileSizeBit.MegaBytes);
            }
            else
            {
                return Convert.ToString(fileSizeBit.GigaBytes);
            }
        }
    }
}

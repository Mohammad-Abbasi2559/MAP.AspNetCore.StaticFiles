using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.AspNetCore.StaticFiles.FilesAction.Models
{
    public class RootFile
    {
        public int fileId { get; set; }
        public string? fileName { get; set; }
        public string? fileAddress { get; set; }
        public string? alt { get; set; }
        public string? title { get; set; }
        public string? fileType { get; set; }
        public DateTime date { get; set; }
        public string? sourceRedirect { get; set; }
        public string? fileSize { get; set; }
    }
}

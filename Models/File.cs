using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa_ko_s22106.Models
{
    public class File
    {
        public int fileId { get; set; }
        public int teamId { get; set; }
        public string fileName { get; set; }
        public string fileExtension { get; set; }
        public int fileSize { get; set; }
        public virtual Team Team { get; set; }
    }
}
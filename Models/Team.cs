using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa_ko_s22106.Models
{
    public class Team
    {
        public int teamId { get; set; }
        public int organizationId { get; set; }
        public string teamName { get; set; }
        public string description { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual IEnumerable<Membership> Memberships { get; set; }
        public virtual IEnumerable<File> Files { get; set; }
    }
}
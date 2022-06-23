using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa_ko_s22106.Models
{
    public class Organization
    {
        public int organizationID { get; set; }
        public string organizationName { get; set; }
        public string organizationDomain { get; set; }
        public virtual IEnumerable<Team> Teams { get; set; }
        public virtual IEnumerable<Member> Members { get; set; }
    }
}
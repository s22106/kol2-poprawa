using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa_ko_s22106.Models
{
    public class Membership
    {
        public int memberId { get; set; }
        public int teamId { get; set; }
        public DateTime membershipDate { get; set; }
        public virtual Team Team { get; set; }
        public virtual Member Member { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa_ko_s22106.Models
{
    public class Member
    {
        public int memberId { get; set; }
        public int organizationId { get; set; }
        public string memberName { get; set; }
        public string memberSurname { get; set; }
        public string memberNickname { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual IEnumerable<Membership> Membperships { get; set; }
    }
}
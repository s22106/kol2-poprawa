using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2poprawa_ko_s22106.Models.DTOs
{
    public class TeamsDetailsGet
    {
        public string teamName { get; set; }
        public string teamDescription { get; set; }
        public string orgName { get; set; }
        public List<MemberGet> members { get; set; }
    }

    public class MemberGet
    {
        public string memberName { get; set; }
        public string memberSurname { get; set; }
        public DateTime membershipDate { get; set; }
    }
}
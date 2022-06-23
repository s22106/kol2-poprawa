using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2poprawa_ko_s22106.Models.DTOs;

namespace kol2poprawa_ko_s22106.Services
{
    public interface ITeamService
    {
        public Task<bool> TeamExists(int id);
        public Task<bool> MemberExists(int id);
        public Task<bool> MembershipExists(int teamId, int memberId);
        public Task<TeamsDetailsGet> GetTeamInfo(int id);
        public Task<bool> CheckTeamOrg(int teamId, int organizationId);
        public Task CreateAsync<T>(T entity) where T : class;
        public Task SaveChangesAsync();
        public Task<int> GetMemberOrgId(int memberId);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2poprawa_ko_s22106.Models;
using kol2poprawa_ko_s22106.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace kol2poprawa_ko_s22106.Services
{
    public class TeamService : ITeamService
    {
        private readonly TeamDbContext _context;
        public TeamService(TeamDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckTeamOrg(int teamId, int organizationId)
        {
            return await _context.Teams.Where(t => teamId == t.teamId).AnyAsync(x => x.organizationId == organizationId);
        }

        public async Task CreateAsync<T>(T entity) where T : class
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<int> GetMemberOrgId(int memberId)
        {
            return await _context.Members.Where(e => e.memberId == memberId)
            .Select(e => e.organizationId).FirstAsync();
        }

        public async Task<TeamsDetailsGet> GetTeamInfo(int id)
        {
            return await _context.Teams.Where(e => e.teamId == id)
                        .Include(e => e.Organization)
                        .Include(e => e.Memberships)
                        .ThenInclude(e => e.Member)
                        .Select(e => new TeamsDetailsGet
                        {
                            teamName = e.teamName,
                            teamDescription = e.description,
                            orgName = e.Organization.organizationName,
                            members = e.Memberships.Where(ms => ms.teamId == id).Select(m => new MemberGet
                            {
                                memberName = m.Member.memberName,
                                memberSurname = m.Member.memberSurname,
                                membershipDate = m.membershipDate
                            }).OrderBy(x => x.membershipDate).ToList()
                        }).SingleAsync();
        }

        public async Task<bool> MemberExists(int id)
        {
            return await _context.Members.AnyAsync(e => e.memberId == id);
        }

        public async Task<bool> MembershipExists(int teamId, int memberId)
        {
            return await _context.Memberships.AnyAsync(e => e.memberId == memberId && e.teamId == teamId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> TeamExists(int id)
        {
            return await _context.Teams.AnyAsync(e => e.teamId == id);
        }
    }
}
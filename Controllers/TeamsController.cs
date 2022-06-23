using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2poprawa_ko_s22106.Models;
using kol2poprawa_ko_s22106.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol2poprawa_ko_s22106.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ITeamService _service;
        public TeamsController(ITeamService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamInfo(int id)
        {
            if (!await _service.TeamExists(id))
            {
                return NotFound("Team does not exists");
            }

            var teamInfo = await _service.GetTeamInfo(id);

            return Ok(teamInfo);
        }

        [HttpPost("{teamId}/Members/{memberId}")]
        public async Task<ActionResult> AddMemberToTeam(int teamId, int memberId)
        {
            if (!await _service.TeamExists(teamId))
            {
                return NotFound("Team does not exists");
            }

            if (!await _service.MemberExists(teamId))
            {
                return NotFound("Member does not exists");
            }

            if (await _service.MembershipExists(teamId, memberId))
            {
                return Conflict("This member already belongs to this team");
            }

            var memberOrgId = await _service.GetMemberOrgId(memberId);

            if (!await _service.CheckTeamOrg(teamId, memberOrgId))
            {
                return Conflict("Team doesn't belong to the same organization as member");
            }

            await _service.CreateAsync(new Membership
            {
                memberId = memberId,
                teamId = teamId,
                membershipDate = DateTime.Now
            });

            await _service.SaveChangesAsync();

            return NoContent();
        }

    }
}
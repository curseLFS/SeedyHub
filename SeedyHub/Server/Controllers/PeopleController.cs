using Microsoft.AspNetCore.Mvc;

namespace SeedyHub.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DataContext _context;

        public PeopleController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Members>>> GetMembers()
        {
            var members = await _context.Members.Include(m => m.Role).ToListAsync();
            return Ok(members);
        }

        [HttpGet("roles")]
        public async Task<ActionResult<List<Role>>> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetSingleMember(int id)
        {
            var member = _context.Members
                .Include(m => m.Role)
                .FirstOrDefault(m => m.MemberId == id);
            if (member == null) 
            {
                return NotFound("Sorry, no member here. :/");
            }
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<List<Members>>> MemberRegistration(Members members)
        {
            members.Role = null;
            members.Accepted = DateTime.Now;
          
            if (string.IsNullOrEmpty(members.Suffix)) 
            {
                members.Suffix = "None";
            }
            _context.Members.Add(members);

            await _context.SaveChangesAsync();

            return Ok(await GetDbMembers());  
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Members>>> UpdateMember(Members members, int id)
        {
            var dbMember = await _context.Members
                .Include(_m => _m.Role)
                .FirstOrDefaultAsync(m => m.MemberId == id);

            if (dbMember == null)
                return NotFound("Sorry, but no member for you. :/");

            dbMember.FirstName = members.FirstName;
            dbMember.LastName  = members.LastName; 
            dbMember.Suffix = members.Suffix;
            dbMember.Birthday = members.Birthday;
            dbMember.Accepted = DateTime.Now;
            dbMember.RoleId = members.RoleId;

            await _context.SaveChangesAsync();

            return Ok(await GetDbMembers());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Members>>> DeleteMember(int id)
        {
            var dbMember = await _context.Members
                .Include(_m => _m.Role)
                .FirstOrDefaultAsync(m => m.MemberId == id);

            if (dbMember == null)
                return NotFound("Sorry, but no member for you. :/");

            _context.Members.Remove(dbMember);

            await _context.SaveChangesAsync();

            return Ok(await GetDbMembers());
        }

        private async Task<List<Members>> GetDbMembers() 
        {
            return await _context.Members.Include(m => m.Role).ToListAsync();
        }
    }
}

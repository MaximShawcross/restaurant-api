using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Controllers
{
    [Route("userRoles")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly RestaurantContext _context;
        private IUserRolesService _userRolesService;

        public UserRolesController(RestaurantContext context, IUserRolesService userRolesService)
        {
            _context = context;
            _userRolesService = userRolesService;
        }
        
        [HttpPost("singleUserWithRoles")]
        public async Task<IEnumerable<UserRoles>> GetUserRoles([FromBody] UserDto user)
        {
            return await _userRolesService.GetUserRoles(user);
        }

        [HttpGet("allUsersWithRoles")]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetChosenUserRoles()
        {
            
            return await _context.UserRoles
                .Include((ur) => ur.User)
                .Include((ur) => ur.Role)
                .ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoles>>> GetUserRoles()
        {

            return await _context.UserRoles.ToListAsync();
        }
        

        // PUT: api/UserRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRoles(int id, UserRoles userRoles)
        {
            if (id != userRoles.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRoles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRolesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRoles>> PostUserRoles(UserRoles userRoles)
        {
            _context.UserRoles.Add(userRoles);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRoles", new { id = userRoles.Id }, userRoles);
        }

        // DELETE: api/UserRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRoles(int id)
        {
            var userRoles = await _context.UserRoles.FindAsync(id);
            if (userRoles == null)
            {
                return NotFound();
            }

            _context.UserRoles.Remove(userRoles);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRolesExists(int id)
        {
            return (_context.UserRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

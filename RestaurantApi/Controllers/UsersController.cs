using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Controllers
{
    [Route("user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly RestaurantContext _context;
        private ILoginService _loginService;

        public UsersController(RestaurantContext context, ILoginService loginService)
        {
            _context = context;
            _loginService = loginService;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<JwtToken> Login([FromBody] UserLoginDto userDto)
        {
            User user = await _loginService.Authenticate(userDto);
            string token = _loginService.CreateToken(user);

            return new JwtToken() {Token = token};
        }

        // GET: api/Users
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            
            return Ok(UsersToDto(users));
        }

        
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return UserToDto(user);
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private static UserDto UserToDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Email = user.Email,
                CurrentDomainId = user.CurrentDomainId,
                Name = user.Name
            };
        }
        
        private static IEnumerable<UserDto> UsersToDto(IEnumerable<User> users)
        {
            List<UserDto> userDtoList = new List<UserDto>();

            foreach (User user in users)
            {
                userDtoList.Add(UserToDto(user));
            }

            return userDtoList;
        }
    }
}
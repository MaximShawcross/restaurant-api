using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using RestoranApi.DTOs;
using RestoranApi.Models;
using RestoranApi.Services.Interfaces;

namespace RestoranApi.Services;

public class LoginService : ILoginService
{
    private readonly IConfiguration _config;
    private readonly RestaurantContext _context;
    
    public LoginService(IConfiguration config, RestaurantContext context)
    {
        _config = config;
        _context = context;
    }
    
    public string CreateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Name),
            new Claim("CurrentDomain", $"{user.CurrentDomain}"),
        };

        var token = new JwtSecurityToken(_config["Jwt:Issuer"]
            , _config["Jwt:Audience"],
            claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );  
            
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<User> Authenticate(UserLoginDto userDto)
    {
        // it would be error if there's more than one row in Users tabel 
        var currentUser = await _context.Users.Where(u => u.Name == userDto.Name && u.Password == userDto.Password).SingleAsync();
        Console.WriteLine($"currentUser.Password: {currentUser.Password}, currentUser.Name: {currentUser.Name}");
        return currentUser;
    }

    public string Test()
    {
        return "TestTestTest";
    }
}
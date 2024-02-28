using appFitness.Data;
using appFitness.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public UserController(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
        _configuration = configuration;
    }

    private string GenerateJwtToken(User user)
    {
        string jwtKey = _configuration["JwtKey"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
        };
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
           issuer: "http://localhost:5000",
           audience: "http://localhost:5000",
           claims: claims,
           expires: DateTime.Now.AddHours(1),
           signingCredentials: creds
       );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = new User
        {
            UserName = model.Email,
            Email = model.Email,
            Age = model.Age != 0 ? model.Age : 18,
            Goal = model.Goal,
            Gender = model.Gender,
        };

        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            return Ok(new { Message = "User registered successfully." });
        }
        else
        {
            return BadRequest(new { Errors = result.Errors });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var token = GenerateJwtToken(user);
                    return Ok(new { UserId = user.Id, Token = token }); 
                }
                else
                {
                    return BadRequest("Unable to retrieve user information");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
        }

        return BadRequest(ModelState);
    }


    [HttpGet("userinfo/{userId}")]
    public async Task<IActionResult> GetUserInfo(string userId)
    {
        try
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(new
            {
                user.UserName,
                user.Email,
                user.Age,
                user.Goal,
                user.Gender
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }


    [Authorize]
    [HttpGet("progress/{userId}")]
    public async Task<IActionResult> GetUserProgress(string userId)
    {
        try
        {
            var progress = await _context.Progress.Where(p => p.UserId == userId).ToListAsync();
            return Ok(progress);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}

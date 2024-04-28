using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Beachcombing_API.Models.Dto.Account;
using Microsoft.AspNetCore.Authorization;
using Beachcombing_API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public AccountController(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto model)
    {
        var user = new User { 
            UserName = model.UserName,
            Email = model.Email,
            AvatarUrl = model.AvatarUrl,
            SelfIntro = model.SelfIntro,
        };

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            // 注册成功后，也可以为用户生成JWT令牌，如果业务场景需要的话
            var token = GenerateJwtToken(user);
            return Ok(new { token = token, expiration = DateTime.UtcNow.AddHours(1) });
        }   
        var errors = result.Errors.Select(e => e.Description);
        return BadRequest(new { Errors = errors });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = GenerateJwtToken(user);
            return Ok(new { token = token, expiration = DateTime.UtcNow.AddHours(1) });
        }
        return Unauthorized(new { Error = "Invalid login attempt." });
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet("userinfo")]
   
    public async Task<IActionResult> GetUserInfo()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound("User not found");
        }
        var userInfoDto = new UserInfoDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            SelfIntro = user.SelfIntro,
            AvatarUrl = user.AvatarUrl 
        };
        return Ok(userInfoDto);
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    // PUT: api/Account/update
    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto model)
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound("User not found");
        }

        // Update user properties
        user.Email = model.Email;
        user.UserName = model.UserName;
        user.SelfIntro = model.SelfIntro;

        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            var userInfoDto = new UserInfoDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                SelfIntro = user.SelfIntro,
            };
            return Ok(userInfoDto);
        }

        var errors = result.Errors.Select(e => e.Description);
        return BadRequest(new { Errors = errors });
    }

    // DELETE: api/Account/delete
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser()
    {
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        var result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
            return Ok(new { message = "User deleted successfully" });
        }

        var errors = result.Errors.Select(e => e.Description);
        return BadRequest(new { Errors = errors });
    }

    

    // ... rest of your existing methods ...


    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        // 根据需要添加其他声明
    };

        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));
        var token = new JwtSecurityToken(
            expires: DateTime.UtcNow.AddHours(1),
            claims: claims,
            signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}



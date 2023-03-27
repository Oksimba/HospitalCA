using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HospitalCA.Application.Common.Interfaces;
using HospitalCA.Infrastructure.Common;
using HospitalCA.Domain.Entities;
using HospitalCA.Domain.Entities.Contracts;
using HospitalCA.Infrastructure.Common.Helpers;
using HospitalCA.WebUI.Converters;

namespace HospitalCA.WebUI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    IAccountService accountService;
    public AuthController(IOptions<AuthOptions> authOptions, IAccountService accountService)
    {
        AuthOptions = authOptions;
        this.accountService = accountService;
    }

    public IOptions<AuthOptions> AuthOptions { get; }

    [Route("login")]
    [HttpPost]
    public IActionResult Login([FromBody] Login request)
    {
        var user = AuthenticateUser(request.LoginName, request.Password);
        if (user != null)
        {
            var token = GenerateJWT(user);

            return Ok(new
            {
                access_token = token
            });
        }

        return Unauthorized();
    }

    private AccountContract AuthenticateUser(string email, string password)
    {
        //IEnumerable<string> hashPasws = accountService.Get().Select(acc => GetHashString(acc.Password)).ToList();
        //string hashPass = GetHashString(password);
        List<Account> _accounts = accountService.Get().ToList();
        return _accounts.SingleOrDefault(u => u.Login == email && u.Password == AuthHelper.GetHashString(password)).ToAccountContract();
    }

    private string GenerateJWT(AccountContract user)
    {
        var authParams = AuthOptions.Value;

        var securityKey = authParams.GetSymetricSecurityKey();
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Login),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim("role", role.Name.ToString()));
        }

        var token = new JwtSecurityToken(authParams.Issuer,
            authParams.Audience,
            claims,
            expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

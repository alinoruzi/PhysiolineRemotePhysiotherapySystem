using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Physioline.Endpoint.WebAPI.Services.AuthenticationServices
{
	public class JwtTokenGenerator
	{
		private readonly IConfiguration _configuration;
		public JwtTokenGenerator(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		
		public string Generate(long userId, string role)
		{
			var claims = new List<Claim>()
			{
				new Claim("userId", userId.ToString()),
				new Claim(ClaimTypes.Role,role),
			};

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
			var sign = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

			var descriptor = new SecurityTokenDescriptor()
			{
				Subject = new ClaimsIdentity(claims),
				Audience = _configuration["Jwt:Audience"],
				Issuer = _configuration["Jwt:Issuer"],
				Expires = DateTime.Now.AddDays(7),
				NotBefore = DateTime.Now,
				SigningCredentials = sign,
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(descriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}

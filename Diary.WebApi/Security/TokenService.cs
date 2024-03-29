using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Diary.Data;
using Diary.Domain;
using Diary.WebApi.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Diary.WebApi.Security
{
    public class TokenService
    {
        TokenSettings _settings;
        private GenericRepository<User> _usersRepository;

        public TokenService(
            TokenSettings settings,
            GenericRepository<User> usersRepository)
        {
            _settings = settings;
            _usersRepository = usersRepository;
        }

        public async Task<TokenViewModel> GenerateTokenAsync(string username, string password)
        {
            var user = (await _usersRepository.GetPageAsync(predicate: s => s.Username == username)).SingleOrDefault();

            Console.WriteLine($"user is null: {user is null}");

            if (user == null)
                throw new ArgumentException(nameof(username));

            Console.WriteLine($"pass: {password}");
            Console.WriteLine($"pass: {user.Password}");

            if (!user.ComparePassword(password))
                throw new ArgumentException(nameof(password));

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Convert.FromBase64String(_settings.SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(DefaultClaims.Username, user.Username),
                    new Claim(DefaultClaims.UserId, user.Id.ToString())
                }),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddYears(7),
                Audience = _settings.Audience,
                Issuer = _settings.Issuer,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var viewModel = new TokenViewModel
            {
                Token = tokenHandler.WriteToken(token),
                Type = user.Type.ToString().ToLower(),
                UserId = user.Id.ToString()
            };

            return viewModel;
        }
    }
}
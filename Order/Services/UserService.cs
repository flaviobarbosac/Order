using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Order.Dominio;
using Order.Dominio.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Order.Services.Interfaces;
using MongoDB.Bson;

namespace Order.Services
{

    //Implementei uma criptografia para a senha do usuario pra aumentar a segurança do sistema
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMapper _mapper;
        private readonly JwtSettings _jwtSettings;

        public UserService(IMongoClient client, IMapper mapper, IOptions<JwtSettings> jwtSettings)
        {
            var database = client.GetDatabase("TechsysLogDB");
            _users = database.GetCollection<User>("Users");
            _mapper = mapper;
            _jwtSettings = jwtSettings.Value;            
        }

        public async Task<User> Register(UserDto userDto)
        {
            var existingUser = await _users.Find(u => u.Email == userDto.Email).FirstOrDefaultAsync();
            if (existingUser != null)
            {
                return null;
            }

            var user = _mapper.Map<User>(userDto);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await _users.InsertOneAsync(user);
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _users.Find(c => true).ToListAsync();
        }

        public async Task<User> GetUserById(ObjectId id)
        {
            return await _users.Find(c => c.Id == id).FirstOrDefaultAsync();
        }    

        public async Task<bool> DeleteUser(ObjectId id)
        {
            var result = await _users.DeleteOneAsync(c => c.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }

        public async Task<string> Authenticate(LoginDto loginDto)
        {
            var user = await _users.Find(u => u.Email == loginDto.Email).FirstOrDefaultAsync();
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtSettings.Issuer,
                Audience = _jwtSettings.Audience
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
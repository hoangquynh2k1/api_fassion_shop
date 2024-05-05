using API_FashionShop.Entities;
using API_FashionShop.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API_FashionShop.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private AppDBContext db;

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, AppDBContext db)
        {
            _appSettings = appSettings.Value;
            this.db = db;
        }

        public User Authenticate(string username, string password)
        {
            var result = from n in db.NhanViens
                         select new User { 
                             Role = n.Quyen, 
                             MaNguoiDung = n.Id,
                             TaiKhoan = n.Id.ToString(),
                             HoTen = n.HoTen!, 
                             MatKhau = n.Password!, 
                             DienThoai = n.SoDT!, 
                             Email = n.Email! 
                         };
            var user = result.SingleOrDefault(x => x.MaNguoiDung.ToString() == username && x.MatKhau == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var key = new byte[32]; // Độ dài key là 256-bit (32 bytes)
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.TaiKhoan.ToString()),
                    new Claim(ClaimTypes.MobilePhone, user.DienThoai.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user.WithoutPassword();
        }

    }
}

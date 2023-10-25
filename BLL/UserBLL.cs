﻿using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BLL
{
    public class UserBLL : IUserBLL
    {
        private IUserDAL _userDAL;
        private readonly IConfiguration _configuration;

        public UserBLL(IUserDAL userDA, IConfiguration configuration)
        {
            _userDAL = userDA;
            _configuration = configuration;
        }

        public User Login(string taikhoan, string matkhau)
        {
            var user = _userDAL.Login(taikhoan, matkhau);

            if (user != null)
            {
                // Tạo khóa HMAC-SHA256 có kích thước 256 bits
                var keyBytes = new byte[32]; // 32 bytes = 256 bits
                using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
                {
                    rngCryptoServiceProvider.GetBytes(keyBytes);
                }

                // Chuyển đổi khóa thành đối tượng SymmetricSecurityKey
                var securityKey = new SymmetricSecurityKey(keyBytes);

                // Tạo token
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.TenTaiKhoan),
                        new Claim(ClaimTypes.Email, user.Email)
                        // Thêm các thông tin khác nếu cần thiết
                    }),
                    Expires = DateTime.UtcNow.AddDays(7), // Thời gian hết hạn của token
                    SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.token = tokenHandler.WriteToken(token); // Gán token vào đối tượng UserModel

                return user;
            }

            return null; // Trả về null nếu đăng nhập không thành công
        }
    }
}


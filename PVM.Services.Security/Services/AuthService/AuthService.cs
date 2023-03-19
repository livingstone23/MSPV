﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PVM.Services.Security.DbContexts;
using PVM.Services.Security.Model;
using PVM.SharedLibrary;

namespace PVM.Services.Security.Services.AuthService
{
    public class AuthService //: IAuthService
    {


        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthService(ApplicationDbContext context,
            IConfiguration configuration,
            IHttpContextAccessor httpContextAccesor)
        {
            _context = context;
            _configuration = configuration;
            _httpContextAccessor = httpContextAccesor;
        }



        public int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));


        public string GetUserEmail() => _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);



        //public async Task<ServiceResponse<int>> Register(PolicyUser user, string password)
        //{

        //    //Confirmamos si el usuario existe
        //    if (await UserExists(user.Email))
        //    {
        //        return new ServiceResponse<int>
        //        {
        //            Success = false,
        //            Message = "User already exists."
        //        };
        //    }

        //    //Encriptamos la password
        //    CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;

        //    _context.PolicyUsers.Add(user);
        //    await _context.SaveChangesAsync();

        //    return new ServiceResponse<int> { Data = user.Oid, Message = "Registration successful!" };

        //}


        ///// <summary>
        ///// Confirmamos is existe el correo indicado por el usuario
        ///// </summary>
        ///// <param name="email"></param>
        ///// <returns></returns>
        //public async Task<bool> UserExists(string email)
        //{
        //    if (await _context.PolicyUsers.AnyAsync(user => user.Email.ToLower()
        //            .Equals(email.ToLower())))
        //    {
        //        return true;
        //    }
        //    return false;
        //}


        /// <summary>
        /// Metodo complementario para encriptar la password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        //public async Task<ServiceResponse<string>> Login(string email, string password)
        //{

        //    //var response = new ServiceResponse<string>{ Data = "token" };


        //    var response = new ServiceResponse<string>();

        //    //Confirmamos que el usuario existe en nuestra base de datos
        //    var user = await _context.PolicyUsers.FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower()));

        //    if (user == null)
        //    {
        //        response.Success = false;
        //        response.Message = "User not found.";
        //    }
        //    //Confirma si la password es correcta
        //    else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //    {
        //        response.Success = false;
        //        response.Message = "Wrong password.";
        //    }
        //    else
        //    {

        //        response.Data = CreateToken(user);
        //    }

        //    return response;
        //}


        /// <summary>
        /// Metodo que confirma que la clave almacenada es la correcta.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <param name="passwordSalt"></param>
        /// <returns></returns>
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }


        private string CreateToken(PolicyUser user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                //new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }


        //public async Task<ServiceResponse<bool>> ChangePassword(int userId, string newPassword)
        //{
        //    var user = await _context.PolicyUsers.FindAsync(userId);
        //    if (user == null)
        //    {
        //        return new ServiceResponse<bool>
        //        {
        //            Success = false,
        //            Message = "User not found."
        //        };
        //    }

        //    CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);

        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;

        //    await _context.SaveChangesAsync();

        //    return new ServiceResponse<bool> { Data = true, Message = "Password has been changed." };
        //}




    }

}

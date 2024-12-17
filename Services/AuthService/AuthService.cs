using eCommerceWebApiBackEnd.Data;
using eCommerceWebApiBackEnd.Dto;
using eCommerceWebApiBackEnd.Shared;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace eCommerceWebApiBackEnd.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<int>> AddUser(User newUser, string passwored)
        {
            bool exists = await UserExists(newUser.Email);
            if(exists)
            {
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists."
                };
            }
            CreatePasswordHash(passwored, out byte[] passwordHash, out byte[] passwordSalt);
            newUser.PasswordHash = passwordHash;
            newUser.PasswordSalt = passwordSalt;
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return new ServiceResponse<int>
            {
                Data = newUser.Id,
                Message = "User created successfully."
            };

        }

        public async Task<bool> UserExists(string email)
        {
            bool exists = await _context.Users.AnyAsync(x => x.Email.ToLower().Equals(email.ToLower()));
            if (exists)
            {
                return true;
            }

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

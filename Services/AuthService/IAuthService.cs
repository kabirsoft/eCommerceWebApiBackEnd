using eCommerceWebApiBackEnd.Dto;
using eCommerceWebApiBackEnd.Shared;

namespace eCommerceWebApiBackEnd.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> AddUser(User newUser, string passwored);
        Task<bool> UserExists(string email);
        Task<ServiceResponse<string>> Login(string email, string password);
    }
}

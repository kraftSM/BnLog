using BnLog.DLL.Models.Security;
using BnLog.DLL.Models;
using BnLog.DLL.Request;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace BnLog.BLL.Services.IService
{
    public interface IAccountService
    {
        Task<IdentityResult> Register(RegisterRequest model);
        Task<SignInResult> Login(LoginRequest model);
        Task<IdentityResult> EditAccount(UserEditRequest model);
        //Task<UserEditRequest> EditAccount(Guid id);
        Task RemoveAccount(Guid id);
        Task<List<User>> GetAccounts();
        Task LogoutAccount();
    }
}

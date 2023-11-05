using BnLog.DLL.Models.Security;
using BnLog.DLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using BnLog.DLL.Request.Security;

namespace BnLog.BLL.Services.IService
{
    public interface ISecurityService
    {
        Task<IdentityResult> Register(RegisterRequest model);
        Task<SignInResult> Login(LoginRequest model);
        Task<IdentityResult> EditAccount(UserEditRequest model);
        Task<UserEditRequest> EditAccount(Guid id);
        Task RemoveAccount(Guid id);
        Task<List<User>> GetAccounts();
        Task LogoutAccount();
    }
}

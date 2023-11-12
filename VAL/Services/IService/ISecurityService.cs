using BnLog.DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Security;

namespace BnLog.VAL.Services.IService
{
    public interface ISecurityService
    {
        Task<IdentityResult> Register(UserRegisterRequest model);
        Task<SignInResult> Login(UserLoginRequest model);
        Task<IdentityResult> EditAccount(UserEditRequest model);
        Task<UserEditRequest> EditAccount(Guid id);

        Task RemoveAccount(Guid id);
        Task<List<User>> GetAccounts();
        Task LogoutAccount();
    }
}

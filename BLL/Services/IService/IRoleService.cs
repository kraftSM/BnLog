using BnLog.DLL.Models.Security;
using BnLog.DLL.Request.Security;

namespace BnLog.BLL.Services.IService
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateRequest model);
        Task EditRole(RoleEditRequest model);
        Task RemoveRole(Guid id);
        Task<List<Role>> GetRoles();
    }
}

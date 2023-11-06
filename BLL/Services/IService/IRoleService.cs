using BnLog.DAL.Models.Security;
using BnLog.DAL.Request.Security;

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

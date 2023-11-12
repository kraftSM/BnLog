using BnLog.DAL.Models.Entity;
using BnLog.DAL.Models.Security;
using BnLog.VAL.Request.Security;

namespace BnLog.BLL.Services.IService
{
    public interface IRoleService
    {
        Task<Guid> CreateRole(RoleCreateRequest model);
        Task EditRole(RoleEditRequest model);
        Task RemoveRole(Guid id);
        Task<Role> GetRole(Guid id);
        Task<List<Role>> GetRoles();
    }
}

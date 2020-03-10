using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Srbac
{
    public interface ISrbacRepository
    {
        IEnumerable<SrbacRolePermissionModel> RolesPermissions { get; set; }
    }
}
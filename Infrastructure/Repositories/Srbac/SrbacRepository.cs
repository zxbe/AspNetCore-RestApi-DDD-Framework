using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Srbac;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Srbac
{
    public class SrbacRepository : BaseRepository<SrbacRolePermissionModel>
    {
        public IEnumerable<SrbacRolePermissionModel> RolesPermissions { get; set; }

        public SrbacRepository(Context context) : base(context)
        {
            RolesPermissions = Context.SrbacRolePermission.ToList();
        }
    }
}
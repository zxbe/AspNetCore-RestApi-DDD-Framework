using System.Collections.Generic;
using System.Linq;
using Domain.Srbac;

namespace Services.Implementations
{
    public class SrbacService : ISrbacService
    {
        private ISrbacRepository _srbacRepository;

        public SrbacService(ISrbacRepository srbacRepository)
        {
            _srbacRepository = srbacRepository;
        }

        public bool CheckPermission(SrbacRoles role, SrbacPermissions permission)
        {
            var res = _srbacRepository.RolesPermissions.FirstOrDefault(
                p => p.Permission == permission && p.Role == role
            );
            return res != null;
        }
    }
}
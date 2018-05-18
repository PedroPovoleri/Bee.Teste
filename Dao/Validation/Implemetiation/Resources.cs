
using Bll.Validation.Interfaces;
using Repository.Interface;
using System;
using System.Linq;

namespace Bll.Validation.Implemetiation
{
    public class Resources : IResources
    {
        private readonly IRepository<Model.POCO.Roles> _rolesRepository;
        private readonly IRepository<Model.POCO.UserRoles> _userRolesRepository;

        public Resources(IRepository<Model.POCO.Roles> rolesRepository, IRepository<Model.POCO.UserRoles> userRolesRepository)
        {
            _rolesRepository = rolesRepository;
            _userRolesRepository = userRolesRepository;
        }

        public bool UserHasResourceAuthorization(long userId, string resourceName)
        {
            var roles = _rolesRepository.GetAll().ToList().Where(x => x.Name == resourceName).FirstOrDefault();
            var userRoles = _userRolesRepository.GetAll().ToList();

            

            return userRoles.Where(x => x.UserId == userId && x.RoleId == roles.id).ToList().Count () > 0;
        }

        public bool UserNotLogged(long userId)
        {
            throw new NotImplementedException();
        }
    }
}

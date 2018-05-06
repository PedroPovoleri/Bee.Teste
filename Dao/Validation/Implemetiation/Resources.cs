
using Bll.Validation.Interfaces;
using Repository.Interface;
using System;
using System.Linq;

namespace Bll.Validation.Implemetiation
{
    public class Resources : IResources
    {
        private readonly IRepository<Model.POCO.User> _rolesRepository;

        public Resources(IRepository<Model.POCO.User> repository)
        {
            _rolesRepository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public bool UserHasResourceAuthorization(long userId, string resourceName)
        {
            var roles = _rolesRepository.GetAll().ToList();            


            return roles.Where(x => x.UserId == userId && x.Name == resourceName).FirstOrDefault().id > 0;
        }

        public bool UserNotLogged(long userId)
        {
            throw new NotImplementedException();
        }
    }
}

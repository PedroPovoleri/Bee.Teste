using Bll.Login.Interface;
using Model.POCO;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bll.Login.Implementation
{
    public class LoginValidation : ILogin
    {
        private readonly IRepository<Users> _userRepository ; 

        public LoginValidation(IRepository<Users> repository)
        {
            _userRepository = repository;
        }

        public long ValidateUser(string _login, string _password)
        {
            return _userRepository.GetAll().ToList().Where(x => x.username == _login && x.password == _password).FirstOrDefault().id;
        }
    }
}

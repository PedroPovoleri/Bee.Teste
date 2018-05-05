using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.Login.Interface
{
    public interface ILogin
    {
        long ValidateUser(string login, string password);


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Bll.Validation.Interfaces
{
    public interface IResources
    {
        bool UserHasResourceAuthorization(long userId, string resourceName);

        bool UserNotLogged(long userId);

    }
}

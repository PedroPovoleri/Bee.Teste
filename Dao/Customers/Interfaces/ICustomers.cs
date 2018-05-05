using Model.POCO;
using System.Collections.Generic;

namespace Bll.Customers.Interfaces
{
    public interface ICustomers
    {
        List<Model.POCO.Customers> GetCustomers();

        Model.POCO.Customers EditCustomers(long customersId);

        bool AddCustumers(Model.POCO.Customers customers);

        bool RemoveCustumers(Model.POCO.Customers customers);

    }
}

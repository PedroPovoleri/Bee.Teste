using Model.POCO;
using System.Collections.Generic;

namespace Bll.Customers.Interfaces
{
    public interface ICustomers
    {
        List<Model.POCO.Customers> GetCustomers();

        List<Model.POCO.Customers> GetPaged(int page, int perPage);

        Model.POCO.Customers GetCustomersById(long custumersId);

        Model.POCO.Customers UpdateCustomers(Model.POCO.Customers newCustomer);

        bool AddCustumers(Model.POCO.Customers customers);

        bool RemoveCustumers(Model.POCO.Customers customers);

    }
}

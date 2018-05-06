using Bll.Customers.Interfaces;
using System;
using System.Collections.Generic;

using Repository.Interface;
using System.Linq;
using Model.POCO;

namespace Bll.Customers.Implemetiation
{
    public class Custumers : ICustomers
    {
        private readonly IRepository<Model.POCO.Customers> _custumersRepository;

        public Custumers(IRepository<Model.POCO.Customers> repository)
        {
            _custumersRepository = repository;
        }
        public bool AddCustumers(Model.POCO.Customers customers)
        {
            return _custumersRepository.Save(customers).id != 0;
        }

        public Model.POCO.Customers UpdateCustomers(Model.POCO.Customers newCustomer)
        {
            return _custumersRepository.Update(newCustomer);
        }

        public List<Model.POCO.Customers> GetCustomers()
        {
            var result = _custumersRepository.GetAll();
            return  result.ToList();
        }

        public bool RemoveCustumers(Model.POCO.Customers customers)
        {
            try
            {
                _custumersRepository.Remove(customers);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Model.POCO.Customers GetCustomersById(long custumersId)
        {
            return _custumersRepository.GetById(custumersId);
        }

        public List<Model.POCO.Customers> GetPaged(int page, int perPage)
        {
            return _custumersRepository.WithPaging(page, perPage).ToList();
        }
    }
}

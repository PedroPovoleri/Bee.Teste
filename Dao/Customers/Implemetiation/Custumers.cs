using Bll.Customers.Interfaces;
using System;
using System.Collections.Generic;

using Repository.Interface;
using System.Linq;

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
            return _custumersRepository.Save(customers).Id != 0;
        }

        public Model.POCO.Customers EditCustomers(long customersId)
        {
            return _custumersRepository.GetById(customersId);
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
    }
}

﻿using business.Logic.DataContracts.Repositories.Customers;
using business.Logic.Domain.Models.Customer;

namespace business.Logic.Services
{
    public class CustomerListService
    {
        private ICustomerRepository _clientRepository;
        public CustomerListService(ICustomerRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        public CustomerList GetClientList(int skip, int take)
        {
            var count = _clientRepository.Count();
            var result = new CustomerList
            {
                Skip = skip,
                Take = take,
                TotalCount = count
            };
            if (skip > count)
            {
                result.Customers = new List<Customer>();
                return result;
            }

            result.Customers = _clientRepository
                .Get("", skip, take)
                .Select(x => new Customer()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Middlename = x.Middlename,
                Email = x.Email,
                Phone = x.Phone
            }).ToList();
            return result;
        }
        
    }
}
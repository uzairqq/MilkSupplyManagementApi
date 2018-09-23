using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces.RepositoryInterfaces;
using ApplicationCore.Interfaces.ServiceInterfaces;

namespace ApplicationCore.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IAsyncRepository<Customer> _customerRepository;

        public CustomerService(IAsyncRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<CustomerResponseViewModel>> GetAllAsync()
        {

            var result = (await _customerRepository.ListAllAsync())
                .Select(i => new CustomerResponseViewModel { Name = i.Name })
                .ToList();
            return result;
        }


        public async Task AddAsync(CustomerResponseViewModel customerResponseViewModel)
        {

            await _customerRepository.AddAsync(new Customer
            {
                Name = customerResponseViewModel.Name,
            });
        }

        public async Task UpdateAsync(CustomerResponseViewModel customerResponseViewModel)
        {

            await _customerRepository.UpdateAsync(new Customer
            {
                Name = customerResponseViewModel.Name,
                Id = customerResponseViewModel.Id
            });
        }

        public async Task DeleteAsync(CustomerResponseViewModel customerResponseViewModel)
        {

            await _customerRepository.DeleteAsync(new Customer
            {
                Name = customerResponseViewModel.Name,
                Id = customerResponseViewModel.Id
            });
        }
    }

   
}

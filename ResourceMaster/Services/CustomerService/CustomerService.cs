using Mapster;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.CustomerRepository;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Services.CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository repository, ILogger<CustomerService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<CustomerViewModel>> GetAllAsync()
        {

            _logger.LogInformation("GetAllAsync Method called");
            var customerList =  await _repository.GetAllAsync();
            return customerList.Adapt<IEnumerable<CustomerViewModel>>();
        }

        public async Task AddAsync(CustomerViewModel customer)
        {
            var newEntry = customer.Adapt<Customer>();
            await _repository.AddAsync(newEntry);
        }

        public async Task UpdateCustomer(CustomerViewModel customer)
        {
            var newEntry = customer.Adapt<Customer>();
            await _repository.Update(newEntry);
        }

        public async Task DeleteCustomer(CustomerViewModel customer)
        {
            var itemToDelte = customer.Adapt<Customer>();
            await _repository.Delete(itemToDelte);
        }
    }
}

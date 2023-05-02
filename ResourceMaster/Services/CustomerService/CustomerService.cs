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

        public async Task<IEnumerable<CustomerViewModel>> GetAllAsync( )
        {

            _logger.LogInformation("GetAllAsync Method called");
            var customerList =  await _repository.GetAllAsync();
            List<CustomerViewModel> resultList = new List<CustomerViewModel>();
            foreach (var table in customerList)
            {
                var viewModel = new CustomerViewModel()
                {
                    id = table.id,
                    companyName = table.companyName,
                    firstName = table.firstName,
                    lastName = table.lastName,
                    street = table.street,
                    location = table.location,
                    country = (Countries)Enum.Parse(typeof(Countries), table.country),
                    zipCode = table.zipCode
                };
                resultList.Add(viewModel);
            }
            return resultList;
        }

        public async Task AddAsync(CustomerViewModel customer)
        {
            var newEntry = new Customer()
            {
                id = customer.id,
                companyName = customer.companyName,
                firstName = customer.firstName,
                lastName = customer.lastName,
                street = customer.street,
                location = customer.location,
                country = customer.country.ToString(),
                zipCode = customer.zipCode
            };

            await _repository.AddAsync(newEntry);
        }
    }
}

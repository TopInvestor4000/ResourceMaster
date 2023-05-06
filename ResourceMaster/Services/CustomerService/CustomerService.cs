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
            List<CustomerViewModel> resultList = new List<CustomerViewModel>();
            foreach (var table in customerList)
            {
                var viewModel = new CustomerViewModel()
                {
                    id = table.Id,
                    companyName = table.CompanyName,
                    firstName = table.FirstName,
                    lastName = table.LastName,
                    street = table.Street,
                    location = table.Location,
                    country = (Countries)Enum.Parse(typeof(Countries), table.Country),
                    zipCode = table.ZipCode
                };
                resultList.Add(viewModel);
            }
            return resultList;
        }

        public async Task AddAsync(CustomerViewModel customer)
        {
            var newEntry = new Customer()
            {
                Id = customer.id,
                CompanyName = customer.companyName,
                FirstName = customer.firstName,
                LastName = customer.lastName,
                Street = customer.street,
                Location = customer.location,
                Country = customer.country.ToString(),
                ZipCode = customer.zipCode
            };

            await _repository.AddAsync(newEntry);
        }

        public CustomerViewModel ToViewModel(Customer customer)
        {
            var viewModel = new CustomerViewModel()
            {
                id = customer.Id,
                companyName = customer.CompanyName,
                firstName = customer.FirstName,
                lastName = customer.LastName,
                street = customer.Street,
                location = customer.Location,
                country = (Countries)Enum.Parse(typeof(Countries), customer.Country),
                zipCode = customer.ZipCode
            };

            return viewModel;
        }

        public Customer ToDb(CustomerViewModel customer)
        {
            var model = new Customer()
            {
                Id = customer.id,
                CompanyName = customer.companyName,
                FirstName = customer.firstName,
                LastName = customer.lastName,
                Street = customer.street,
                Location = customer.location,
                Country = customer.country.ToString(),
                ZipCode = customer.zipCode
            };

            return model;
        }
    }
}

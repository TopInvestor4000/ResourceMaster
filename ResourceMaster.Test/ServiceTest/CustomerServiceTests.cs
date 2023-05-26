using Mapster;
using NUnit.Framework;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.CustomerRepository;
using ResourceMaster.Services.CustomerService;
using ResourceMaster.ViewModels;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResourceMaster.Tests.Services
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> _repositoryMock;
        private Mock<ILogger<CustomerService>> _loggerMock;
        private CustomerService _service;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<ICustomerRepository>();
            _loggerMock = new Mock<ILogger<CustomerService>>();
            _service = new CustomerService(_repositoryMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllCustomersViewModel()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, CompanyName = "Company 1", FirstName = "John", LastName = "Doe", Street = "123 Main St", ZipCode = "12345", Location = "City", Country = "Country", Project = new List<Project>() },
                new Customer { Id = 2, CompanyName = "Company 2", FirstName = "Jane", LastName = "Smith", Street = "456 Elm St", ZipCode = "67890", Location = "Town", Country = "Country", Project = new List<Project>() }
            };
            _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(customers);

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<CustomerViewModel>>(result);
            Assert.AreEqual(customers.Count, result.Count());
        }

        [Test]
        public async Task AddAsync_ShouldAddNewCustomer()
        {
            // Arrange
            var customerViewModel = new CustomerViewModel { Id = 1, CompanyName = "Company 1", FirstName = "John", LastName = "Doe", Street = "123 Main St", ZipCode = "12345", Location = "City", Country = "Country", Project = new List<ProjectViewModel>() };
            var customer = customerViewModel.Adapt<Customer>();
            _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Customer>())).Verifiable();

            // Act
            await _service.AddAsync(customerViewModel);

            // Assert
            _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Customer>()), Times.Once);
        }

        [Test]
        public async Task UpdateCustomer_ShouldUpdateExistingCustomer()
        {
            // Arrange
            var customerViewModel = new CustomerViewModel { Id = 1, CompanyName = "Company 1", FirstName = "John", LastName = "Doe", Street = "123 Main St", ZipCode = "12345", Location = "City", Country = "Country", Project = new List<ProjectViewModel>() };
            var customer = customerViewModel.Adapt<Customer>();
            _repositoryMock.Setup(repo => repo.Update(It.IsAny<Customer>())).Verifiable();

            // Act
            await _service.UpdateCustomer(customerViewModel);

            // Assert
            _repositoryMock.Verify(repo => repo.Update(It.IsAny<Customer>()), Times.Once);
        }

        [Test]
        public async Task DeleteCustomer_ShouldDeleteExistingCustomer()
        {
            // Arrange
            var customerViewModel = new CustomerViewModel { Id = 1, CompanyName = "Company 1", FirstName = "John", LastName = "Doe", Street = "123 Main St", ZipCode = "12345", Location = "City", Country = "Country", Project = new List<ProjectViewModel>() };
            var customer = customerViewModel.Adapt<Customer>();
            _repositoryMock.Setup(repo => repo.Delete(customer)).Verifiable();

            // Act
            await _service.DeleteCustomer(customerViewModel);

            // Assert
            _repositoryMock.Verify(repo => repo.Delete(It.IsAny<Customer>()), Times.Once);
        }

        [Test]
        public async Task GetSingle_ShouldReturnSingleCustomerViewModel()
        {
            // Arrange
            var customerId = 1;
            var customer = new Customer { Id = customerId, CompanyName = "Company 1", FirstName = "John", LastName = "Doe", Street = "123 Main St", ZipCode = "12345", Location = "City", Country = "Country", Project = new List<Project>() };
            _repositoryMock.Setup(repo => repo.GetSingle(customerId)).ReturnsAsync(customer);

            // Act
            var result = await _service.GetSingle(customerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CustomerViewModel>(result);
            Assert.AreEqual(customerId, result.Id);
        }
    }
}

using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.CustomerRepository;
using ResourceMaster.Services.CustomerService;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Test.ServiceTest
{
    [TestFixture]
    public class CustomerServiceTests
    {
        private Mock<ICustomerRepository> _mockRepository;
        private Mock<ILogger<CustomerService>> _mockLogger;
        private CustomerService _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<ICustomerRepository>();
            _service = new CustomerService(_mockRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllAsync_ReturnsExpectedViewModels()
        {
            // Arrange
            var customerList = new List<Customer>()
        {
            new Customer()
            {
                Id = 1,
                FirstName = "Peter",
                LastName = "Meier",
                Street = "Löwengasse 5",
                ZipCode = "3000",
                Location = "Zürich",
                Country = "Schweiz",
                CompanyName = "Bond Agency"
            },
        };

            _mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(customerList);

            var expectedViewModels = customerList.Select(table => new CustomerViewModel()
            {
                Id = table.Id,
                FirstName = table.FirstName,
                LastName = table.LastName,
                Street = table.Street,
                ZipCode = table.ZipCode,
                Location = table.Location,
                Country = (Countries)Enum.Parse(typeof(Countries), table.Country),
                CompanyName = table.CompanyName,
            });

            // Act
            var result = await _service.GetAllAsync();

            // Assert
            result.Should().BeEquivalentTo(expectedViewModels);
        }

        [Test]
        public async Task AddAsync_AddsNewEntryToRepository()
        {
            // Arrange
            var customerViewModel = new CustomerViewModel()
            {
                Id = 1,
                FirstName = "James",
                LastName = "Bond",
                Street = "Löwengasse 5",
                ZipCode = "3000",
                Location = "Zürich",
                Country = Countries.Switzerland,
                CompanyName = "Bond Agency",
            };

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Customer>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            await _service.AddAsync(customerViewModel);

            // Assert
            _mockRepository.Verify();
        }
    }
}

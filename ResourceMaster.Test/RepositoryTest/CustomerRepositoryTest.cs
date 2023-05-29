using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.CustomerRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceMaster.Test.RepositoryTest
{
    [TestFixture]
    public class CustomerRepositoryTest
    {
        private DbContextOptions<DatabaseContext> _dbContextOptions;
        private DatabaseContext _dbContext;
        private CustomerRepository _repository;

        [SetUp]
        public void Setup()
        {
            _dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _dbContext = new DatabaseContext(_dbContextOptions);
            _dbContext.Database.EnsureCreated();

            _repository = new CustomerRepository(_dbContext);
        }

        [TearDown]
        public void Cleanup()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }

        [Test]
        public async Task GetAllAsync_ShouldReturnAllCustomers()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, CompanyName = "Company 1", FirstName = "John", LastName = "Doe", Street = "123 Main St", ZipCode = "12345", Location = "City", Country = "Country" },
                new Customer { Id = 2, CompanyName = "Company 2", FirstName = "Jane", LastName = "Smith", Street = "456 Elm St", ZipCode = "67890", Location = "Town", Country = "Country" },
                new Customer { Id = 3, CompanyName = "Company 3", FirstName = "Bob", LastName = "Johnson", Street = "789 Oak St", ZipCode = "54321", Location = "Village", Country = "Country" }
            };

            _dbContext.Customers.AddRange(customers);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.AreEqual(customers.Count, result.Count());
            Assert.That(result.Select(x => new { x.Id, x.CompanyName }).ToList(), Is.EquivalentTo(customers.Select(x => new { x.Id, x.CompanyName })));
        }

        [Test]
        public async Task AddAsync_ShouldAddCustomerToContext()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                CompanyName = "New Company",
                FirstName = "New",
                LastName = "Customer",
                Street = "789 Elm St",
                ZipCode = "54321",
                Location = "City",
                Country = "Country"
            };

            // Act
            await _repository.AddAsync(customer);

            // Assert
            var addedCustomer = _dbContext.Customers.Find(1);
            Assert.NotNull(addedCustomer);
            Assert.AreEqual(customer.CompanyName, addedCustomer.CompanyName);
            Assert.AreEqual(customer.FirstName, addedCustomer.FirstName);
            Assert.AreEqual(customer.LastName, addedCustomer.LastName);
            Assert.AreEqual(customer.Street, addedCustomer.Street);
            Assert.AreEqual(customer.ZipCode, addedCustomer.ZipCode);
            Assert.AreEqual(customer.Location, addedCustomer.Location);
            Assert.AreEqual(customer.Country, addedCustomer.Country);
        }

        [Test]
        public async Task Update_ShouldUpdateCustomerInContext()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                CompanyName = "Updated Company",
                FirstName = "Updated",
                LastName = "Customer",
                Street = "789 Elm St",
                ZipCode = "54321",
                Location = "City",
                Country = "Country"
            };
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            // Act
            await _repository.Update(customer);

            // Assert
            var updatedCustomer = _dbContext.Customers.Find(1);
            Assert.NotNull(updatedCustomer);
            Assert.AreEqual(customer.CompanyName, updatedCustomer.CompanyName);
            Assert.AreEqual(customer.FirstName, updatedCustomer.FirstName);
            Assert.AreEqual(customer.LastName, updatedCustomer.LastName);
            Assert.AreEqual(customer.Street, updatedCustomer.Street);
            Assert.AreEqual(customer.ZipCode, updatedCustomer.ZipCode);
            Assert.AreEqual(customer.Location, updatedCustomer.Location);
            Assert.AreEqual(customer.Country, updatedCustomer.Country);
        }

        [Test]
        public async Task Delete_ShouldDeleteCustomerFromContext()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                CompanyName = "Company to Delete",
                FirstName = "Delete",
                LastName = "Customer",
                Street = "789 Elm St",
                ZipCode = "54321",
                Location = "City",
                Country = "Country"
            };
            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            // Act
            await _repository.Delete(customer);

            // Assert
            var deletedCustomer = _dbContext.Customers.Find(1);
            Assert.Null(deletedCustomer);
        }

        [Test]
        public async Task GetSingle_ShouldReturnCustomerWithMatchingId()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, CompanyName = "Company 1", FirstName = "John", LastName = "Doe", Street = "123 Main St", ZipCode = "12345", Location = "City", Country = "Country" },
                new Customer { Id = 2, CompanyName = "Company 2", FirstName = "Jane", LastName = "Smith", Street = "456 Elm St", ZipCode = "67890", Location = "Town", Country = "Country" },
                new Customer { Id = 3, CompanyName = "Company 3", FirstName = "Bob", LastName = "Johnson", Street = "789 Oak St", ZipCode = "54321", Location = "Village", Country = "Country" }
            };

            _dbContext.Customers.AddRange(customers);
            _dbContext.SaveChanges();

            // Act
            var result = await _repository.GetSingle(2);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Id);
            Assert.AreEqual("Company 2", result.CompanyName);
            Assert.AreEqual("Jane", result.FirstName);
            Assert.AreEqual("Smith", result.LastName);
            Assert.AreEqual("456 Elm St", result.Street);
            Assert.AreEqual("67890", result.ZipCode);
            Assert.AreEqual("Town", result.Location);
            Assert.AreEqual("Country", result.Country);
        }
    }
}

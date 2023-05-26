using Mapster;
using NUnit.Framework;
using ResourceMaster.DAL.Models;
using ResourceMaster.ViewModels;
using System.Collections.Generic;

namespace ResourceMaster.Tests.Mapping
{
    [TestFixture]
    public class CustomerMappingTests
    {
        [Test]
        public void Map_Customer_To_CustomerViewModel_ShouldMapPropertiesCorrectly()
        {
            // Arrange
            var customer = new Customer
            {
                Id = 1,
                CompanyName = "Company",
                FirstName = "John",
                LastName = "Doe",
                Street = "123 Main St",
                ZipCode = "12345",
                Location = "City",
                Country = "Country",
                Project = new List<Project>()
            };

            // Act
            var customerViewModel = customer.Adapt<CustomerViewModel>();

            // Assert
            Assert.AreEqual(customer.Id, customerViewModel.Id);
            Assert.AreEqual(customer.CompanyName, customerViewModel.CompanyName);
            Assert.AreEqual(customer.FirstName, customerViewModel.FirstName);
            Assert.AreEqual(customer.LastName, customerViewModel.LastName);
            Assert.AreEqual(customer.Street, customerViewModel.Street);
            Assert.AreEqual(customer.ZipCode, customerViewModel.ZipCode);
            Assert.AreEqual(customer.Location, customerViewModel.Location);
            Assert.AreEqual(customer.Country, customerViewModel.Country);
            Assert.IsNotNull(customerViewModel.Project);
            Assert.IsEmpty(customerViewModel.Project);
        }
    }
}

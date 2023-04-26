﻿using FluentAssertions;
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
                id = 1,
                firstName = "Peter",
                lastName = "Meier",
                street = "Löwengasse 5",
                zipCode = "3000",
                location = "Zürich",
                country = "Schweiz",
                companyName = "Bond Agency"
            },
        };

            _mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(customerList);

            var expectedViewModels = customerList.Select(table => new CustomerViewModel()
            {
                id = table.id,
                firstName = table.firstName,
                lastName = table.lastName,
                street = table.street,
                zipCode = table.zipCode,
                location = table.location,
                country = table.country,
                companyName = table.companyName,
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
                id = 1,
                firstName = "James",
                lastName = "Bond",
                street = "Löwengasse 5",
                zipCode = "3000",
                location = "Zürich",
                country = "Schweiz",
                companyName = "Bond Agency",
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
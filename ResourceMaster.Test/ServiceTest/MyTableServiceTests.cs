using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResourceMaster.DAL.Repositories.MyTableRepository;
using ResourceMaster.Models;
using ResourceMaster.Services.MyTableService;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Test.ServiceTest
{
    [TestFixture]
    public class MyTableServiceTests
    {
        private Mock<IMyTableRepository> _mockRepository;
        private Mock<ILogger<CustomerService>> _mockLogger;
        private CustomerService _service;

        [SetUp]
        public void SetUp()
        {
            _mockRepository = new Mock<IMyTableRepository>();
            _service = new CustomerService(_mockRepository.Object, _mockLogger.Object);
        }

        [Test]
        public async Task GetAllAsync_ReturnsExpectedViewModels()
        {
            // Arrange
            var myTableList = new List<MyTable>()
        {
            new MyTable() { Id = 1, Age = 21 },
            new MyTable() { Id = 2, Age = 33 },
            new MyTable() { Id = 3, Age = 25 }
        };

            _mockRepository.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(myTableList);

            var expectedViewModels = myTableList.Select(table => new MyTableViewModel()
            {
                Id = table.Id,
                Age = table.Age
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
            var myTableViewModel = new MyTableViewModel()
            {
                Id = 4,
                Age = 28
            };

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<MyTable>()))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            await _service.AddAsync(myTableViewModel);

            // Assert
            _mockRepository.Verify();
        }
    }
}

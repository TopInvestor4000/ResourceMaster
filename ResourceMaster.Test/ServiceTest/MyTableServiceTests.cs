using FluentAssertions;
using Moq;
using ResourceMaster.DAL.Repositories.MyTableRepository;
using ResourceMaster.Models;
using ResourceMaster.Services.MyTableService;
using ResourceMaster.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceMaster.Test.ServiceTest
{
    public class MyTableServiceTests
    {
        private readonly Mock<IMyTableRepository> _mockRepository;
        private readonly MyTableService _service;

        public MyTableServiceTests()
        {
            _mockRepository = new Mock<IMyTableRepository>();
            _service = new MyTableService(_mockRepository.Object);
        }

        [Fact]
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

        [Fact]
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

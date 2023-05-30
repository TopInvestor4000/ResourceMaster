using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.ResourceProject;
using ResourceMaster.Services.CustomerService;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Tests.Services
{
    [TestFixture]
    public class AvailabilityServiceTests
    {
        private Mock<IResourceProjectRepository> _repositoryMock;
        private Mock<ILogger<AvailabilityService>> _loggerMock;
        private AvailabilityService _service;

        [SetUp]
        public void Setup()
        {
            _repositoryMock = new Mock<IResourceProjectRepository>();
            _loggerMock = new Mock<ILogger<AvailabilityService>>();
            _service = new AvailabilityService(_repositoryMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task GetAvailability_ShouldReturnAllResourceWhichAreFreeInTimeRange()
        {
            // Arrange
            var availabelResources = new List<ProjectResource>
            {
                new ProjectResource
                {
                    Id = 1, BookedFrom = new DateTime(2000, 10, 9), BookedTo = new DateTime(2000, 10, 10),
                    Project = new Project(), ProjectId = 4, Resource = new Resource(), ResourceId = 3
                },
                new ProjectResource
                {
                    Id = 2, BookedFrom = new DateTime(2000, 10, 8), BookedTo = new DateTime(2000, 10, 11),
                    Project = new Project(), ProjectId = 5, Resource = new Resource(), ResourceId = 6
                },
            };
            _repositoryMock
                .Setup(repo => repo.GetAvailability(2, new DateTime(2000, 10, 4), new DateTime(2000, 10, 15)))
                .ReturnsAsync(availabelResources);

            // Act
            var result = await _service.GetAvailability(2, new DateTime(2000, 10, 4), new DateTime(2000, 10, 15));

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<AvailabilityViewModel>>(result);
            Assert.AreEqual(availabelResources.Count, result.Count());
        }
    }
}

using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResourceMaster.DAL.Repositories.ResourceProject;
using ResourceMaster.DAL.Repositories.ResourceRepository;
using ResourceMaster.Services.CustomerService;
using ResourceMaster.Services.MatchingService;
using ResourceMaster.ViewModels;

namespace ResourceMaster.Tests.Services
{
    [TestFixture]
    public class MatchingServiceTests
    {
        private Mock<ILogger<MatchingService>> _loggerMock;
        private Mock<ResourceService> _resourceServiceMock;
        private Mock<AvailabilityService> _availabilityServiceMock;
        private MatchingService _matchingService;

        [SetUp]
        public void Setup()
        {
            _loggerMock = new Mock<ILogger<MatchingService>>();
            _resourceServiceMock = new Mock<ResourceService>(new Mock<IResourceRepository>().Object, new Mock<ILogger<ResourceService>>().Object);
            _availabilityServiceMock = new Mock<AvailabilityService>(new Mock<IResourceProjectRepository>().Object, new Mock<ILogger<AvailabilityService>>().Object);
            _matchingService = new MatchingService(_availabilityServiceMock.Object, _resourceServiceMock.Object, _loggerMock.Object);
        }

        [Test]
        public async Task MatchResources_correctResourcesShouldBeInResultingList()
        {
            // Arrange
            var project = new ProjectViewModel
            {
                Customer = new CustomerViewModel
                {
                    Id = 1, CompanyName = "Company 1", FirstName = "John", LastName = "Doe", Street = "123 Main St",
                    ZipCode = "12345", Location = "City", Country = "Country", Project = new List<ProjectViewModel>()
                },
                Id = 1, ProjectEnd = new DateTime(2000, 10, 15), ProjectName = "Test",
                ProjectResources = new List<ProjectResourceViewModel>(), ProjectStart = new DateTime(2000, 10, 10),
                Skills = new List<SkillInformationViewModel>()

            };
            
            project.Skills.Add(new SkillInformationViewModel{ Id = 2, IsCertification = true, Necessity = "true", RequiredWorkHours = 10, Skill = new SkillViewModel {Id = 10, SkillName = "JAVA"}, SkillId = 2, SkillLevel = SkillLevel.Beginner});
            
            var availableResources = new List<ResourceViewModel>
            {
                new() { Id = 1, FirstName = "John", LastName = "Doe", Age = 30, Skills = new()},
            };
            
            availableResources[0].Skills.Add(new SkillInformationViewModel{ Id = 2, IsCertification = true, Necessity = "true", RequiredWorkHours = 10, Skill = new SkillViewModel {Id = 10, SkillName = "JAVA"}, SkillId = 2, SkillLevel = SkillLevel.Beginner});
            
            _resourceServiceMock
                .Setup(repo => repo.GetAllWithInclude())
                .ReturnsAsync(availableResources);

            var availabilities = new List<AvailabilityViewModel>();
            availabilities.Add(new AvailabilityViewModel { BookedFrom = new DateTime(2000, 10, 11), BookedTo = new DateTime(2000, 10, 15) });

            _availabilityServiceMock
                .Setup(repo => repo.GetAvailability(It.IsAny<int>(), It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .ReturnsAsync(availabilities);

            // Act
            var result = await _matchingService.MatchResourcesToProjectAsync(project);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<MatchingResourceViewModel>>(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(1, result[0].BestScore);
            Assert.AreEqual("JAVA", result[0].BestSkill.SkillName);
            Assert.AreEqual(1, result[0].BestOverallScore);
        }
        
        [Test]
        public async Task MatchResources_noResourcesShouldBeInResultingList()
        {
            // Arrange
            var project = new ProjectViewModel
            {
                Customer = new CustomerViewModel
                {
                    Id = 1, CompanyName = "Company 1", FirstName = "John", LastName = "Doe", Street = "123 Main St",
                    ZipCode = "12345", Location = "City", Country = "Country", Project = new List<ProjectViewModel>()
                },
                Id = 1, ProjectEnd = new DateTime(2000, 10, 15), ProjectName = "Test",
                ProjectResources = new List<ProjectResourceViewModel>(), ProjectStart = new DateTime(2000, 10, 10),
                Skills = new List<SkillInformationViewModel>()

            };
            
            project.Skills.Add(new SkillInformationViewModel{ Id = 2, IsCertification = true, Necessity = "true", RequiredWorkHours = 10, Skill = new SkillViewModel {Id = 10, SkillName = "JAVA"}, SkillId = 2, SkillLevel = SkillLevel.Beginner});
            
            var availableResources = new List<ResourceViewModel>
            {
                new() { Id = 1, FirstName = "John", LastName = "Doe", Age = 30, Skills = new()},
            };
            
            availableResources[0].Skills.Add(new SkillInformationViewModel{ Id = 2, IsCertification = true, Necessity = "true", RequiredWorkHours = 10, Skill = new SkillViewModel {Id = 10, SkillName = "PHP"}, SkillId = 2, SkillLevel = SkillLevel.Beginner});
            
            _resourceServiceMock
                .Setup(repo => repo.GetAllWithInclude())
                .ReturnsAsync(availableResources);

            // Act
            var result = await _matchingService.MatchResourcesToProjectAsync(project);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<MatchingResourceViewModel>>(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}

using Mapster;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.ResourceRepository;
using ResourceMaster.Services.CustomerService;
using ResourceMaster.ViewModels;

[TestFixture]
public class ResourceServiceTests
{
    private Mock<IResourceRepository> _repositoryMock;
    private Mock<ILogger<ResourceService>> _loggerMock;
    private ResourceService _service;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IResourceRepository>();
        _loggerMock = new Mock<ILogger<ResourceService>>();
        _service = new ResourceService(_repositoryMock.Object, _loggerMock.Object);
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnAllResources()
    {
        // Arrange
        var resources = new List<Resource>
    {
        new Resource { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 },
        new Resource { Id = 2, FirstName = "Jane", LastName = "Smith", Age = 25 }
    };
        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(resources.AsQueryable());

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<IEnumerable<ResourceViewModel>>(result);
        Assert.AreEqual(resources.Count, result.Count());
    }


    [Test]
    public async Task GetSingle_ShouldReturnResourceById()
    {
        // Arrange
        var resource = new Resource { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 };
        _repositoryMock.Setup(repo => repo.GetSingle(1)).ReturnsAsync(resource);

        // Act
        var result = await _service.GetSingle(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(resource.Id, result.Id);
        Assert.AreEqual(resource.FirstName, result.FirstName);
        Assert.AreEqual(resource.LastName, result.LastName);
        Assert.AreEqual(resource.Age, result.Age);
    }

    [Test]
    public async Task AddAsync_ShouldAddNewResource()
    {
        // Arrange
        var resourceViewModel = new ResourceViewModel { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 };
        var resource = resourceViewModel.Adapt<Resource>();
        _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Resource>())).Verifiable();

        // Act
        await _service.AddAsync(resourceViewModel);

        // Assert
        _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Resource>()), Times.Once);
    }

    [Test]
    public async Task GetAllWithInclude_ShouldReturnAllResourcesWithIncludedEntities()
    {
        // Arrange
        var resources = new List<Resource>
        {
            new Resource { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 },
            new Resource { Id = 2, FirstName = "Jane", LastName = "Smith", Age = 25 }
        };
        _repositoryMock.Setup(repo => repo.GetAllWithIncludeAsync()).ReturnsAsync(resources);

        // Act
        var result = await _service.GetAllWithInclude();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<IEnumerable<ResourceViewModel>>(result);
        Assert.AreEqual(resources.Count, result.Count());
    }

    [Test]
    public async Task UpdateAsync_ShouldUpdateResource()
    {
        // Arrange
        var resourceViewModel = new ResourceViewModel { Id = 1, FirstName = "John", LastName = "Doe", Age = 30 };
        var resource = resourceViewModel.Adapt<Resource>();
        _repositoryMock.Setup(repo => repo.UpdateAsync(It.IsAny<Resource>())).Verifiable();

        // Act
        await _service.UpdateAsync(resourceViewModel);

        // Assert
        _repositoryMock.Verify(repo => repo.UpdateAsync(It.IsAny<Resource>()), Times.Once);
    }

    [Test]
    public async Task Delete_ShouldDeleteResource()
    {
        // Arrange
        var resourceId = 1;
        _repositoryMock.Setup(repo => repo.Delete(resourceId)).Verifiable();

        // Act
        await _service.Delete(resourceId);

        // Assert
        _repositoryMock.Verify(repo => repo.Delete(resourceId), Times.Once);
    }
}

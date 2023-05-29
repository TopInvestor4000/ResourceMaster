using Mapster;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.ProjectRepository;
using ResourceMaster.Services.CustomerService;
using ResourceMaster.ViewModels;

[TestFixture]
public class ProjectServiceTests
{
    private Mock<IProjectRepository> _repositoryMock;
    private Mock<ILogger<ProjectService>> _loggerMock;
    private ProjectService _service;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<IProjectRepository>();
        _loggerMock = new Mock<ILogger<ProjectService>>();
        _service = new ProjectService(_repositoryMock.Object, _loggerMock.Object);
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnAllProjects()
    {
        // Arrange
        var projects = new List<Project>
        {
            new Project { Id = 1, ProjectName = "Project 1", Customer = new Customer(), Skills = new List<ProjectSkill>(), ProjectResources = new List<ProjectResource>() },
            new Project { Id = 2, ProjectName = "Project 2", Customer = new Customer(), Skills = new List<ProjectSkill>(), ProjectResources = new List<ProjectResource>() }
        };
        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(projects);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<IEnumerable<ProjectViewModel>>(result);
        Assert.AreEqual(projects.Count, result.Count());
    }

    [Test]
    public async Task GetSingle_ShouldReturnProjectById()
    {
        // Arrange
        var project = new Project { Id = 1, ProjectName = "Project 1", Customer = new Customer(), Skills = new List<ProjectSkill>(), ProjectResources = new List<ProjectResource>() };
        _repositoryMock.Setup(repo => repo.GetSingle(1)).ReturnsAsync(project);

        // Act
        var result = await _service.GetSingle(1);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(project.Id, result.Id);
        Assert.AreEqual(project.ProjectName, result.ProjectName);
    }

    [Test]
    public async Task AddAsync_ShouldAddNewProject()
    {
        // Arrange
        var projectViewModel = new ProjectViewModel { Id = 1, ProjectName = "Project 1", Customer = new CustomerViewModel(), Skills = new (), ProjectResources = new () };
        var project = projectViewModel.Adapt<Project>();
        _repositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Project>())).Verifiable();

        // Act
        await _service.AddAsync(projectViewModel);

        // Assert
        _repositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Project>()), Times.Once);
    }

    [Test]
    public async Task Update_ShouldUpdateProject()
    {
        // Arrange
        var projectViewModel = new ProjectViewModel { Id = 1, ProjectName = "Project 1", Customer = new CustomerViewModel(), Skills = new(), ProjectResources = new () };
        var project = projectViewModel.Adapt<Project>();
        _repositoryMock.Setup(repo => repo.UpdateHires(It.IsAny<Project>())).Verifiable();

        // Act
        await _service.Update(projectViewModel);

        // Assert
        _repositoryMock.Verify(repo => repo.UpdateHires(It.IsAny<Project>()), Times.Once);
    }

    [Test]
    public async Task DeleteProject_ShouldDeleteProject()
    {
        // Arrange
        var projectViewModel = new ProjectViewModel { Id = 1, ProjectName = "Project 1", Customer = new CustomerViewModel(), Skills = new (), ProjectResources = new () };
        var project = projectViewModel.Adapt<Project>();
        _repositoryMock.Setup(repo => repo.Delete(It.IsAny<Project>())).Verifiable();

        // Act
        await _service.DeleteProject(projectViewModel);

        // Assert
        _repositoryMock.Verify(repo => repo.Delete(It.IsAny<Project>()), Times.Once);
    }
}

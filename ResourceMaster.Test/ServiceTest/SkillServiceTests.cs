using Mapster;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.SkillRepository;
using ResourceMaster.Services.CustomerService;
using ResourceMaster.ViewModels;

[TestFixture]
public class SkillServiceTests
{
    private Mock<ISkillRepository> _repositoryMock;
    private Mock<ILogger<SkillService>> _loggerMock;
    private SkillService _service;

    [SetUp]
    public void Setup()
    {
        _repositoryMock = new Mock<ISkillRepository>();
        _loggerMock = new Mock<ILogger<SkillService>>();
        _service = new SkillService(_repositoryMock.Object, _loggerMock.Object);
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnAllSkills()
    {
        // Arrange
        var skills = new List<Skill>
        {
            new Skill { Id = 1, SkillName = "Programming" },
            new Skill { Id = 2, SkillName = "Database Management" }
        };
        _repositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(skills);

        // Act
        var result = await _service.GetAllAsync();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOf<IEnumerable<SkillViewModel>>(result);
        Assert.AreEqual(skills.Count, result.Count());
    }

    [Test]
    public async Task AddAsync_ShouldAddNewSkill()
    {
        // Arrange
        var skillViewModel = new SkillViewModel { Id = 1, SkillName = "Programming" };
        var skill = skillViewModel.Adapt<Skill>();
        _repositoryMock.Setup(repo => repo.AddUpdate(It.IsAny<Skill>())).Verifiable();

        // Act
        await _service.AddAsync(skillViewModel);

        // Assert
        _repositoryMock.Verify(repo => repo.AddUpdate(It.IsAny<Skill>()), Times.Once);
    }

    [Test]
    public async Task UpdateSkill_ShouldUpdateSkill()
    {
        // Arrange
        var skillViewModel = new SkillViewModel { Id = 1, SkillName = "Programming" };
        var skill = skillViewModel.Adapt<Skill>();
        _repositoryMock.Setup(repo => repo.AddUpdate(It.IsAny<Skill>())).Verifiable();

        // Act
        await _service.UpdateSkill(skillViewModel);

        // Assert
        _repositoryMock.Verify(repo => repo.AddUpdate(It.IsAny<Skill>()), Times.Once);
    }

    [Test]
    public async Task DeleteSkill_ShouldDeleteSkill()
    {
        // Arrange
        var skillId = 1;
        _repositoryMock.Setup(repo => repo.DeleteAsync(skillId)).Verifiable();

        // Act
        await _service.DeleteSkill(skillId);

        // Assert
        _repositoryMock.Verify(repo => repo.DeleteAsync(skillId), Times.Once);
    }
}

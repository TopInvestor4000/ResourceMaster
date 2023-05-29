using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using ResourceMaster.DAL.Data;
using ResourceMaster.DAL.Models;
using ResourceMaster.DAL.Repositories.SkillRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceMaster.Test.RepositoryTests
{
    [TestFixture]
    public class SkillRepositoryTests
    {
        private DbContextOptions<DatabaseContext> dbContextOptions;

        [SetUp]
        public void Setup()
        {
            var dbName = $"SkillDb_{DateTime.Now.ToFileTimeUtc()}";
            dbContextOptions = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(dbName)
                .Options;
        }

        [Test]
        public async Task GetAllAsync_Success_Test()
        {
            await using (var context = new DatabaseContext(dbContextOptions))
            {
                // Arrange
                await PopulateDataAsync(context);
                var repository = new SkillRepository(context);

                // Act
                var skillList = await repository.GetAllAsync();

                // Assert
                Assert.AreEqual(3, skillList.Count());
            }
        }

        [Test]
        public async Task AddUpdateAsync_Success_Test()
        {
            await using (var context = new DatabaseContext(dbContextOptions))
            {
                // Arrange
                var repository = new SkillRepository(context);
                var skill = new Skill { SkillName = "New Skill" };

                // Act
                await repository.AddUpdate(skill);

                // Assert
                var skills = await repository.GetAllAsync();
                Assert.That(skills.Any(s => s.SkillName == "New Skill"));
            }
        }

        [Test]
        public async Task DeleteAsync_Success_Test()
        {
            await using (var context = new DatabaseContext(dbContextOptions))
            {
                // Arrange
                await PopulateDataAsync(context);
                var repository = new SkillRepository(context);

                // Act
                await repository.DeleteAsync(3);

                // Assert
                var skills = await repository.GetAllAsync();
                Assert.AreEqual(2, skills.Count());
            }
        }

        private async Task PopulateDataAsync(DatabaseContext context)
        {
            int index = 1;

            while (index <= 3)
            {
                var skill = new Skill
                {
                    SkillName = $"Skill_{index}"
                };

                index++;
                await context.Skills.AddAsync(skill);
            }

            await context.SaveChangesAsync();
        }
    }
}

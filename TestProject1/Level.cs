using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using SkillAssessment.Data;
using SkillAssessment.Models;
using SkillAssessment.Repositories;
using Xunit;

namespace SkillAssessment.Tests
{
    public class LevelRepositoryTests
    {
        [Fact]
        public async Task GetLevelsAsync_ReturnsListOfLevels()
        {
            // Arrange
            var levels = new List<Level>
            {
                new Level { LevelId = 1, LevelName = "Beginner" },
                new Level { LevelId = 2, LevelName = "Intermediate" }
            };

            var dbContextOptions = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: "GetLevelsAsync_TestDatabase")
                .Options;

            using (var context = new UserContext(dbContextOptions))
            {
                context.levels.AddRange(levels);
                context.SaveChanges();
            }

            using (var context = new UserContext(dbContextOptions))
            {
                var repository = new LevelRepository(context);

                // Act
                var result = await repository.GetLevelsAsync();

                // Assert
                Assert.Equal(levels.Count, result.Count());
            }
        }
      

        [Fact]
        public async Task DeleteLevelAsync_DeletesLevelAndReturnsTrue()
        {
            // Arrange
            var levels = new List<Level>
            {
                new Level { LevelId = 1, LevelName = "Beginner" },
                new Level { LevelId = 2, LevelName = "Intermediate" },
                new Level { LevelId = 3, LevelName = "Upkills" },
                new Level { LevelId = 4, LevelName = "Advanced" }
            };

            var dbContextOptions = new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase(databaseName: "DeleteLevelAsync_TestDatabase")
                .Options;

            using (var context = new UserContext(dbContextOptions))
            {
                context.levels.AddRange(levels);
                context.SaveChanges();
            }

            using (var context = new UserContext(dbContextOptions))
            {
                var repository = new LevelRepository(context);

                // Act
                var resultUpkills = await repository.DeleteLevelAsync(3);
                var resultAdvanced = await repository.DeleteLevelAsync(4);

                // Assert
                Assert.True(resultUpkills);
                Assert.True(resultAdvanced);
                Assert.Null(await context.levels.FindAsync(3));
                Assert.Null(await context.levels.FindAsync(4));
            }
        }
    }
}

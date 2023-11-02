using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SkillAssessment.Controllers;
using SkillAssessment.Models;

namespace SkillAssessment.Tests
{
    public class ResultsControllerTests
    {
        [Fact]
        public async Task GetResults_ReturnsListOfResults()
        {
            // Arrange
            var mockRepository = new Mock<IResultRepository>();
            var results = new List<Result> { new Result(), new Result() };
            mockRepository.Setup(repo => repo.GetAllResultsAsync()).ReturnsAsync(results);

            var controller = new ResultsController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetResults();

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var model = Assert.IsType<List<Result>>(okObjectResult.Value);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task GetResult_ReturnsSingleResult()
        {
            // Arrange
            var mockRepository = new Mock<IResultRepository>();
            var resultId = 1;
            var result = new Result { /* Set properties */ };
            mockRepository.Setup(repo => repo.GetResultByIdAsync(resultId)).ReturnsAsync(result);

            var controller = new ResultsController(mockRepository.Object);

            // Act
            var actionResult = await controller.GetResult(resultId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var model = Assert.IsType<Result>(okObjectResult.Value);
            Assert.Equal(result, model);
        }

        [Fact]
        public async Task PostResult_CreatesResult()
        {
            // Arrange
            var mockRepository = new Mock<IResultRepository>();
            var resultToCreate = new Result { /* Set properties */ };
            var createdResult = new Result { /* Set properties */ };
            mockRepository.Setup(repo => repo.CreateResultAsync(resultToCreate)).ReturnsAsync(createdResult);

            var controller = new ResultsController(mockRepository.Object);

            // Act
            var actionResult = await controller.PostResult(resultToCreate);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);
            var model = Assert.IsType<Result>(createdAtActionResult.Value);
            Assert.Equal(createdResult, model);
        }

      
    }
}

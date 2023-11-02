using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SkillAssessment.Controllers;
using SkillAssessment.Models;
using SkillAssessment.Repositories;
using Xunit;

namespace TestProject1
{
    public class AnswersControllerTests
    {
        [Fact]
        public async Task GetAnswers_ReturnsListOfAnswers()
        {
            // Arrange
            var mockRepository = new Mock<IAnswerRepository>();
            mockRepository.Setup(repo => repo.GetAllAnswersAsync())
                .ReturnsAsync(GetTestAnswers());

            var controller = new AnswersController(mockRepository.Object);

            // Act
            var result = await controller.GetAnswers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var answers = Assert.IsAssignableFrom<IEnumerable<Answer>>(okResult.Value);
            Assert.Equal(2, answers.Count()); // Adjust this based on your test data
        }


        [Fact]
        public async Task PostAnswer_ReturnsCreatedResult()
        {
            // Arrange
            var mockRepository = new Mock<IAnswerRepository>();
            var newAnswer = new Answer { Id = 3 }; // Adjust as needed
            mockRepository.Setup(repo => repo.CreateAnswerAsync(newAnswer))
                .ReturnsAsync(newAnswer);

            var controller = new AnswersController(mockRepository.Object);

            // Act
            var result = await controller.PostAnswer(newAnswer);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var answer = Assert.IsType<Answer>(createdResult.Value);
            Assert.Equal(newAnswer.Id, answer.Id);
        }

        [Fact]
        public async Task DeleteAnswer_ReturnsNoContent()
        {
            // Arrange
            var mockRepository = new Mock<IAnswerRepository>();
            int answerId = 1;
            mockRepository.Setup(repo => repo.DeleteAnswerAsync(answerId))
                .ReturnsAsync(true); // Simulating successful deletion

            var controller = new AnswersController(mockRepository.Object);

            // Act
            var result = await controller.DeleteAnswer(answerId);

            // Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(204, noContentResult.StatusCode);
        }

        [Fact]
        public async Task DeleteAnswer_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IAnswerRepository>();
            int answerId = 1;
            mockRepository.Setup(repo => repo.DeleteAnswerAsync(answerId))
                .ReturnsAsync(false); // Simulating failure to delete

            var controller = new AnswersController(mockRepository.Object);

            // Act
            var result = await controller.DeleteAnswer(answerId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        private static IEnumerable<Answer> GetTestAnswers()
        {
            return new List<Answer>
            {
                new Answer { Id = 1 },
                new Answer { Id = 2 }
            };
        }
    }
}

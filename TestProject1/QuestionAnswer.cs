using Microsoft.AspNetCore.Mvc;
using Moq;
using SkillAssessment.Controllers;
using SkillAssessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProject1
{
    public class QuestionAnswersControllerTests
    {
        [Fact]
        public async Task GetQuestionAnswers_ReturnsOkResultWithQuestionAnswers()
        {
            // Arrange
            var mockRepository = new Mock<IQuestionAnswerRepository>();
            mockRepository.Setup(repo => repo.GetAllQuestionAnswersAsync()).ReturnsAsync(GetTestQuestionAnswers());
            var controller = new QuestionAnswersController(mockRepository.Object);

            // Act
            var result = await controller.GetQuestionAnswers();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var questionAnswers = Assert.IsAssignableFrom<IEnumerable<QuestionAnswer>>(okResult.Value);
            Assert.Equal(2, questionAnswers.Count()); // Adjust count as per your test data
        }

        [Fact]
        public async Task GetQuestionAnswer_ValidId_ReturnsOkResultWithQuestionAnswer()
        {
            // Arrange
            var testId = 1; // Adjust with your test data
            var mockRepository = new Mock<IQuestionAnswerRepository>();
            mockRepository.Setup(repo => repo.GetQuestionAnswerByIdAsync(testId)).ReturnsAsync(GetTestQuestionAnswer());
            var controller = new QuestionAnswersController(mockRepository.Object);

            // Act
            var result = await controller.GetQuestionAnswer(testId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var questionAnswer = Assert.IsType<QuestionAnswer>(okResult.Value);
            Assert.Equal(testId, questionAnswer.Id);
        }

        // Add more test methods for other controller actions

        private IEnumerable<QuestionAnswer> GetTestQuestionAnswers()
        {
            return new List<QuestionAnswer>
            {
                new QuestionAnswer { Id = 1 },
                new QuestionAnswer { Id = 2 }
            };
        }

        private QuestionAnswer GetTestQuestionAnswer()
        {
            return new QuestionAnswer { Id = 1 };
        }
    }
}

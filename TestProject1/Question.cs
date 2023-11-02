using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SkillAssessment.Controllers;
using SkillAssessment.Models;
using Xunit;

namespace SkillAssessment.Tests
{
    public class QuestionsControllerTests
    {
        private readonly QuestionsController _controller;
        private readonly Mock<IQuestionRepository> _repositoryMock;

        public QuestionsControllerTests()
        {
            _repositoryMock = new Mock<IQuestionRepository>();
            _controller = new QuestionsController(_repositoryMock.Object);
        }

        // Test for GetQuestions action
        [Fact]
        public async Task GetQuestions_ReturnsOkResult()
        {
            // Arrange
            var questions = new List<Questions> { new Questions { QnId = 1, /* ... */ } };
            _repositoryMock.Setup(repo => repo.GetAllQuestionsAsync()).ReturnsAsync(questions);

            // Act
            var result = await _controller.GetQuestions();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<Questions>>(okResult.Value);
            Assert.Single(model); // You can adjust this based on your scenario
        }
        [Fact]
        public async Task GetQuestion_ReturnsOkResultWithQuestion()
        {
            // Arrange
            int questionId = 1;
            var question = new Questions { QnId = questionId, /* ... */ };
            _repositoryMock.Setup(repo => repo.GetQuestionByIdAsync(questionId)).ReturnsAsync(question);

            // Act
            var result = await _controller.GetQuestion(questionId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<Questions>(okResult.Value);
            Assert.Equal(questionId, model.QnId);
        }

        [Fact]
        public async Task PostQuestion_ReturnsCreatedAtAction()
        {
            // Arrange
            var newQuestion = new Questions { /* ... */ };
            _repositoryMock.Setup(repo => repo.CreateQuestionAsync(It.IsAny<Questions>())).ReturnsAsync(newQuestion);

            // Act
            var result = await _controller.PostQuestion(newQuestion);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal("GetQuestion", createdAtActionResult.ActionName);
        }

        [Fact]
        public async Task DeleteQuestion_ReturnsNoContent()
        {
            // Arrange
            int questionId = 1;
            _repositoryMock.Setup(repo => repo.DeleteQuestionAsync(questionId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteQuestion(questionId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

      
    }

}

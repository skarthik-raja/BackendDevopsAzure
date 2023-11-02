using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SkillAssessment.Controllers;
using SkillAssessment.Models;
using Xunit;

namespace TestProject1
{
    public class AssessmentsControllerTests
    {
        private readonly Mock<IAssessmentRepository> _mockAssessmentRepository;
        private readonly AssessmentsController _controller;

        public AssessmentsControllerTests()
        {
            _mockAssessmentRepository = new Mock<IAssessmentRepository>();
            _controller = new AssessmentsController(_mockAssessmentRepository.Object, null);
        }

        [Fact]
        public async Task GetAssessments_ReturnsOkResult()
        {
            // Arrange
            _mockAssessmentRepository.Setup(repo => repo.GetAllAssessments())
                                     .ReturnsAsync(new List<Assessment>());

            // Act
            var result = await _controller.GetAssessments();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        

        [Fact]
        public async Task PostAssessment_ReturnsOkResult()
        {
            // Arrange
            var newAssessment = new Assessment();
            _mockAssessmentRepository.Setup(repo => repo.CreateAssessment(It.IsAny<Assessment>()))
                                     .ReturnsAsync(newAssessment);

            // Act
            var result = await _controller.PostAssessment(newAssessment);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

      
    }
}

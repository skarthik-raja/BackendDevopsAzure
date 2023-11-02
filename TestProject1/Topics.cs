using Microsoft.AspNetCore.Mvc;
using Moq;
using SkillAssessment.Controllers;
using SkillAssessment.Models;
using SkillAssessment.Repositories.Interfaces;


namespace TestProject1
{
    public class TopicsControllerTests
    {
        [Fact]
        public async Task GetTopics_ReturnsOkResult()
        {
            // Arrange
            var mockRepository = new Mock<ITopicRepository>();
            mockRepository.Setup(repo => repo.GetTopicsAsync()).ReturnsAsync(GetTestTopics());

            var controller = new TopicsController(mockRepository.Object);

            // Act
            var result = await controller.GetTopics();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTopic_WithValidName_ReturnsOkResult()
        {
            // Arrange
            var topicName = "TestTopic";
            var mockRepository = new Mock<ITopicRepository>();
            mockRepository.Setup(repo => repo.GetTopicByNameAsync(topicName)).ReturnsAsync(new Topics());

            var controller = new TopicsController(mockRepository.Object);

            // Act
            var result = await controller.GetTopic(topicName);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetTopic_WithInvalidName_ReturnsNotFoundResult()
        {
            // Arrange
            var topicName = "NonExistentTopic";
            var mockRepository = new Mock<ITopicRepository>();
            mockRepository.Setup(repo => repo.GetTopicByNameAsync(topicName)).ReturnsAsync((Topics)null);

            var controller = new TopicsController(mockRepository.Object);

            // Act
            var result = await controller.GetTopic(topicName);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        private static IEnumerable<Topics> GetTestTopics()
        {
            return new List<Topics>
            {
                new Topics { Topic_Id = 1, Topic_Name = "Topic1" },
                new Topics { Topic_Id = 2, Topic_Name = "Topic2" }
            };
        }
    }
}

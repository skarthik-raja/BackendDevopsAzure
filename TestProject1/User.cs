using Xunit;
using TestProject1;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SkillAssessment.Controllers;
using SkillAssessment.Repositories.Interfaces;

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace TestProject1.Tests
{
    public class UserTests
    {
        [Fact]
        public void User_Properties_Are_Set_Correctly()
        {
            // Arrange
            int userId = 1;
            string firstName = "John";
            string lastName = "Doe";
            string department = "IT";
            string designation = "Developer";

            // Act
            var user = new User
            {
                User_ID = userId,
                User_FirstName = firstName,
                User_LastName = lastName,
                User_Departmenr = department,
                User_Designation = designation
            };

            // Assert
            Assert.Equal(userId, user.User_ID);
            Assert.Equal(firstName, user.User_FirstName);
            Assert.Equal(lastName, user.User_LastName);
            Assert.Equal(department, user.User_Departmenr);
            Assert.Equal(designation, user.User_Designation);
        }
    }

    public class UsersControllerTests
    {

        [Fact]
        public async Task GetUser_ReturnsNotFound_ForInvalidId()
        {
            // Arrange
            var mockRepository = new Mock<IUserRepository>();
            mockRepository.Setup(repo => repo.GetUserAsync(It.IsAny<int>())).ThrowsAsync(new KeyNotFoundException());
            var controller = new UsersController(mockRepository.Object, null);

            // Act
            var result = await controller.GetUser(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        private List<User> GetTestUsers()
        {
            return new List<User>
            {
                new User { User_ID = 1, User_FirstName = "John" },
                new User { User_ID = 2, User_FirstName = "Jane" }
            };
        }
    }
}

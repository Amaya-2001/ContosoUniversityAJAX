using AutoFixture;
using BusinessLayer.Interfaces;
using BusinessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PracticeProject.Controllers;
using PracticeProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer.Services;
using PracticeProject.Models;

namespace ContosoUniversityTestProject
{
    [TestClass]
    public class StudentControllerTest
    {
        private readonly Mock<IStudentService> _mockService;
        private readonly StudentsController controller;
        private readonly Fixture _fixture;

        public StudentControllerTest()
        {
            _fixture = new Fixture();

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _mockService = new Mock<IStudentService>();

            // Initialize the controller with the mock repository
            controller = new StudentsController(_mockService.Object);
        }

        [TestMethod]
        public async Task GetStudents_ReturnOk()
        {
            // Arrange
            var studentList = _fixture.CreateMany<Student>(3).ToList();
            _mockService.Setup(service => service.GetStudents()).ReturnsAsync(studentList);

            // Act
            var result = await controller.GetStudentList();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            var actualStudents = ((OkObjectResult)result).Value as List<StudentModel>;
            Assert.AreEqual(studentList.Count, actualStudents?.Count);
        }

        [TestMethod]
        public async Task Create_ReturnsOk()
        {
            // Arrange
            var studentModel = _fixture.Create<StudentModel>();

            // Act
            var result =  controller.Create(studentModel);

            // Assert
            Assert.IsInstanceOfType(result, typeof(JsonResult));
            var jsonResult = (JsonResult)result;

            
            var successValue = jsonResult.Value.GetType().GetProperty("success")?.GetValue(jsonResult.Value);

            Assert.IsNotNull(successValue);
            Assert.AreEqual(true, successValue);


        }
        [TestMethod]
        public async Task EditPost_ReturnsTrue()
        {
            // Arrange
            var studentId = 1;
            var student = _fixture.Create<Student>();
            _mockService.Setup(service => service.GetStudentByID(studentId)).ReturnsAsync(student);

            // Act
            var result = await controller.EditPost(studentId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(JsonResult));
            var jsonResult = (JsonResult)result;

            var successValue = jsonResult.Value.GetType().GetProperty("success")?.GetValue(jsonResult.Value);
            Assert.IsNotNull(successValue);
            Assert.AreEqual(true, successValue);

        }

        [TestMethod]
        public async Task DeleteConfirm_ReturnsTrue()
        {
            // Arrange
            var studentId = 1;
            _mockService.Setup(service => service.DeleteStudent(studentId));

            // Act
            var result = await controller.DeleteConfirm(studentId);

            // Assert
            Assert.IsInstanceOfType(result, typeof(JsonResult));
            var jsonResult = (JsonResult)result;

            var successValue = jsonResult.Value.GetType().GetProperty("success")?.GetValue(jsonResult.Value);
            Assert.IsNotNull(successValue);
            Assert.AreEqual(true, successValue);

        }

    }
}

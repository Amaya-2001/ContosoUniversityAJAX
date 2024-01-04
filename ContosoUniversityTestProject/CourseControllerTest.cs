using AutoFixture;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PracticeProject.Controllers;
using PracticeProject.Entities;
using PracticeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoUniversityTestProject
{
    [TestClass]
    public class CourseControllerTest
    {
        private readonly Mock<ICourseService> _courseServiceMock;
        private readonly CoursesController _controller;
        private readonly Fixture _fixture;

        public CourseControllerTest()
        {
            _fixture = new Fixture();
            _courseServiceMock = new Mock<ICourseService>();
            _controller = new CoursesController(_courseServiceMock.Object);

            _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [TestMethod]
        public async Task GetCourseList_ReturnPartialView()
        {
            //var courseList = 
            
        }


    }
}

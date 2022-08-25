using Castle.Core.Logging;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Web.Controllers;
using Project.Web.Models;
using Xunit;
using Xunit.Abstractions;
using CategoriesApiTests;
using System.Linq;

namespace MajorxUnitTestProject
{
    public partial class CategoriesApiTests
    {
        [Fact]
        public void GetCategoryByID_NotFoundResult()
        {
            var dbName = nameof(CategoriesApiTests.GetCategoryByID_NotFoundResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);
            int findCategoryID = 900;

            IActionResult actionresult = controller.GetCategory(findCategoryID).Result;

            Assert.IsType<NotFoundResult>(actionresult);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.NotFound; //404
            var actualStatusCode = (actionresult as NotFoundResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryByID_BadFoundResult()
        {
            var dbName = nameof(CategoriesApiTests.GetCategoryByID_BadFoundResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);
            int? findCategoryID = null;

            IActionResult actionresult = controller.GetCategory(findCategoryID).Result;

            Assert.IsType<BadRequestResult>(actionresult);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.BadRequest; //404
            var actualStatusCode = (actionresult as BadRequestResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }



        [Fact]
        public void GetCategoryById_OkResult()
        {

            var dbName = nameof(CategoriesApiTests.GetCategoryById_OkResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);
            int findCategoryID = 2;

            IActionResult actionresult = controller.GetCategory(findCategoryID).Result;

            Assert.IsType<OkObjectResult>(actionresult);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK; //200
            var actualStatusCode = (actionresult as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryById_CorrectResult()
        {

            var dbName = nameof(CategoriesApiTests.GetCategoryById_CorrectResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);
            int findCategoryID = 2;

            Category expectedCategory = DbContextMocker.TestData_Categories
                                            .SingleOrDefault(c => c.CatgoryId == findCategoryID);



            IActionResult actionresult = controller.GetCategory(findCategoryID).Result;

            OkObjectResult result = actionresult.Should().BeOfType<OkObjectResult>().Subject;

            Assert.IsType<Category>(result.Value);

            Category pc = result.Value.Should().BeAssignableTo<Category>().Subject;//actual category
            _outputHelper.WriteLine($"Found: Category Id : {pc.CatgoryId}, Category Name : {pc.Categories}");

            Assert.NotNull(pc);



            Assert.Equal<int>(expected: expectedCategory.CatgoryId, actual: pc.CatgoryId);


            Assert.Equal(expected: expectedCategory.Categories, actual: pc.Categories);


          


        }

    }
}


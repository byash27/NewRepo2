﻿using Castle.Core.Logging;
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

namespace MajorxUnitTestProject
{
    public partial class CategoriesApiTests
    {
        [Fact]
        public void DeleteCategory_NotFoundResult()
        {
            var dbName = nameof(CategoriesApiTests.GetCategoryByID_NotFoundResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);
            int findCategoryID = 900;

            IActionResult actionresultDelete = controller.DeleteCategory(findCategoryID).Result;

            Assert.IsType<NotFoundResult>(actionresultDelete);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.NotFound; //404
            var actualStatusCode = (actionresultDelete as NotFoundResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void DeleteCategory_BadRequestResult()
        {


            var dbName = nameof(CategoriesApiTests.GetCategoryByID_BadFoundResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);
            int? findCategoryID = null;

            IActionResult actionresultDelete = controller.DeleteCategory(findCategoryID).Result;

            Assert.IsType<BadRequestResult>(actionresultDelete);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.BadRequest; //400
            var actualStatusCode = (actionresultDelete as BadRequestResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void DeleteCategory_OkResult()
        {

            var dbName = nameof(CategoriesApiTests.GetCategoryById_OkResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);
            int findCategoryID = 1;

            IActionResult actionresultDelete = controller.DeleteCategory(findCategoryID).Result;

            Assert.IsType<OkObjectResult>(actionresultDelete);


            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK; //400
            var actualStatusCode = (actionresultDelete as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }
    }
}


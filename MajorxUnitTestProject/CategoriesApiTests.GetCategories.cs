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
        public void GetCategories_OkResult()
        {
            var dbName = nameof(CategoriesApiTests.GetCategories_OkResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);

            IActionResult actionresult = controller.GetCategories().Result;

            Assert.IsType<OkObjectResult>(actionresult);

            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            var actualStatusCode = (actionresult as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategories_CheckCorrectResult()    // second 
        {
            var dbName = nameof(CategoriesApiTests.GetCategories_CheckCorrectResult);
            var logger = Mock.Of<ILogger<CategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new CategoriesController(dbContext, logger);

            IActionResult actionresult = controller.GetCategories().Result;

            Assert.IsType<OkObjectResult>(actionresult);

            var okResult = actionresult.Should().BeOfType<OkObjectResult>().Subject;

            Assert.IsAssignableFrom<List<Category>>(okResult.Value); //error can be found

            var categories = okResult.Value.Should().BeAssignableTo<List<Category>>().Subject;

            Assert.NotNull(categories);

            Assert.Equal(expected: DbContextMocker.TestData_Categories.Length,
                        actual: categories.Count);


            int ndx = 0;
            foreach (Category Category in DbContextMocker.TestData_Categories)
            {
                Assert.Equal<int>(expected: Category.CatgoryId,
                    actual: categories[ndx].CatgoryId);

                Assert.Equal(expected: Category.Categories,
                    actual: categories[ndx].Categories);

                _outputHelper.WriteLine($"Row # {ndx} Okay !!! Issue Id - {Category.CatgoryId} Issue - {Category.Categories}");
                ndx++;
            }

        }
    }
}


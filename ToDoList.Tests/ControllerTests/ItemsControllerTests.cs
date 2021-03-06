﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using IdentityStuff.Controllers;
using IdentityStuff.Models;
using Xunit;
using Microsoft.AspNetCore.Identity;

namespace IdentityStuff.Tests
{
    public class ItemsControllerTest
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            ToDoController controller = new ToDoController(_userManager, _db);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Get_ModelList_Index_Test()
        {
            //Arrange
            ToDoController controller = new ToDoController(_userManager, _db);
            IActionResult actionResult = controller.Index();
            ViewResult indexView = controller.Index() as ViewResult;

            //Act
            var result = indexView.ViewData.Model;

            //Assert
            Assert.IsType<List<Item>>(result);
        }
    }
}

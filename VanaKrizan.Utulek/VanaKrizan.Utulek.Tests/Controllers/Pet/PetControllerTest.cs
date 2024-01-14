using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using Moq;

using VanaKrizan.Utulek.Web.Areas.Security.Controllers;
using VanaKrizan.Utulek.Web.Controllers;
using VanaKrizan.Utulek.Tests.Helpers;
using VanaKrizan.Utulek.Application.ViewModels;
using VanaKrizan.Utulek.Web.Areas.admin.Controllers;
using VanaKrizan.Utulek.Application.Implementation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VanaKrizan.Utulek.Application.Abstraction;
using VanaKrizan.Utulek.Domain.Entities;
using System.Drawing;
using Microsoft.AspNetCore.Http.HttpResults;

namespace VanaKrizan.Utulek.Tests.Security.Account
{
    public class PetControllerTest
    {

        [Fact]
        public void Pet_Index()
        {
            // Arrange
            var testData = new List<Pet>
            {
                new Pet { Id = 1, Name = "Pet 1" },
                new Pet { Id = 2, Name = "Pet 2" }
            };

            var mockPetService = new Mock<IPetService>();
            mockPetService.Setup(repo => repo.PetSelectAll())
                .Returns(testData) ; 

            var controller = new PetController(mockPetService.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<List<Pet>>(viewResult.Model);
            Assert.Equal(testData.Count, model.Count);
        }

        #region test Create funcs
        [Fact]
        public async Task Pet_CreateGet_Valid()
        {
            // Arrange
            var mockPetService = new Mock<IPetService>();
            var controller = new PetController(mockPetService.Object);

            // Act
            var result = controller.Create();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Contains("Sizes", viewResult.ViewData.Keys);
            Assert.Contains("Breeds", viewResult.ViewData.Keys);
        }

        [Fact]
        public async Task Pet_CreatePost_Valid()
        {
            // Arrange
            var mockPetService = new Mock<IPetService>();
            var controller = new PetController(mockPetService.Object);
            var pet = new Pet { Name = "Test Pet" };
            var petFile = new PetFile { PetObj = pet, ImageFile = null };

            // Act
            var result = await controller.Create(petFile);

            // Assert
            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(nameof(PetController.Index), redirectResult.ActionName);
        }

        [Fact]
        public async Task Pet_CreatePost_Invalid()
        {
            // Arrange
            var mockPetService = new Mock<IPetService>();
            var controller = new PetController(mockPetService.Object);
            var pet = new Pet { Name = "" };
            var petFile = new PetFile { PetObj = pet, ImageFile = null };

            controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await controller.Create(petFile);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(petFile, viewResult.Model);
        }
        #endregion


        #region test Edit funcs
        [Fact]
        public async Task Pet_EditGet_Valid()
        {
            // Arrange
            var testData = new Pet
            {
                Id = 1,
                Name = "PesoTest",
                BreedId = -1,
            };

            var mockPetService = new Mock<IPetService>();
            mockPetService.Setup(repo => repo.PetSelectById(testData.Id))
                .Returns(testData);

            var controller = new PetController(mockPetService.Object);

            // Act
            var result = controller.Edit(testData.Id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Contains("Sizes", viewResult.ViewData.Keys);
            Assert.Contains("Breeds", viewResult.ViewData.Keys);
            
            var model = Assert.IsAssignableFrom<PetFile>(viewResult.Model);
            Assert.Equal(testData, model.PetObj);
        }

        [Fact]
        public async Task Pet_EditGet_Invalid()
        {
            // Arrange
            var pet = new Pet
            {
                Id = 1,
                BreedId = -1,
            };
            var testData = new PetFile
            {
                PetObj = pet,
                ImageFile = null,
            };

            var mockPetService = new Mock<IPetService>();
            mockPetService.Setup(repo => repo.PetSelectById(testData.PetObj.Id))
                .Returns(testData.PetObj);

            var controller = new PetController(mockPetService.Object);
            controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = controller.Edit(testData.PetObj.Id);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<PetFile>(viewResult.Model);
        }

        [Fact]
        public async Task Pet_EditPost_Valid()
        {
            // Arrange
            var pet = new Pet
            {
                Id = 1,
                Name = "Test",
                BreedId = -1,
            };
            var testData = new PetFile { PetObj = pet, ImageFile = null };

            var mockPetService = new Mock<IPetService>();
            mockPetService.Setup(repo => repo.PetEdit(testData.PetObj))
                .Returns(true);
            var controller = new PetController(mockPetService.Object);

            // Act
            var result = await controller.Edit(testData);

            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Matches(nameof(PetController.Index), redirect.ActionName);
            Assert.Matches(nameof(PetController).Replace(nameof(Controller), String.Empty), redirect.ControllerName);
        }

        [Fact]
        public async Task Pet_EditPost_Invalid()
        {
            // Arrange
            var pet = new Pet
            {
                Id = 1,
                Name = "Test",
                BreedId = -1,
            };
            var testData = new PetFile { PetObj = pet, ImageFile = null };


            var mockPetService = new Mock<IPetService>();
            mockPetService.Setup(repo => repo.PetEdit(testData.PetObj))
                .Returns(false);
            var controller = new PetController(mockPetService.Object);

            // Act
            var result = await controller.Edit(testData);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }
        #endregion

        #region test Delete funcs

        [Fact]
        public async Task Pet_DeletePost_Valid()
        {
            // Arrange
            var testData = new Pet
            {
                Id = 1,
                Name = "Test",
                BreedId = -1,
            };

            var mockPetService = new Mock<IPetService>();
            mockPetService.Setup(repo => repo.PetDelete(testData.Id))
                .Returns(true);
            var controller = new PetController(mockPetService.Object);

            // Act
            var result = controller.Delete(testData.Id);

            // Assert
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Matches(nameof(UserController.Index), redirect.ActionName);
            Assert.Matches(nameof(UserController).Replace(nameof(Controller), String.Empty), redirect.ControllerName);
        }

        [Fact]
        public async Task Pet_DeletePost_Invalid()
        {
            // Arrange
            var testData = new Pet
            {
                Id = 1,
                Name = "Test",
                BreedId = -1,
            };

            var mockPetService = new Mock<IPetService>();
            mockPetService.Setup(repo => repo.PetDelete(testData.Id))
                .Returns(false);
            var controller = new PetController(mockPetService.Object);

            // Act
            var result = controller.Delete(testData.Id);

            // Assert
            var viewResult = Assert.IsType<NotFoundResult>(result);
        }




        #endregion

    }
}
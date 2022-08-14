// <summary>
// <copyright file="FacadeTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.Test.Facade
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using Axity.Users.Dtos.Users;
    using Axity.Users.Facade.Users.Impl;
    using Axity.Users.Services.Users;

    /// <summary>
    /// Class UsersServiceTest.
    /// </summary>
    [TestFixture]
    public class FacadeTest : BaseTest
    {
        private UsersFacade modelFacade;

        /// <summary>
        /// The init.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var mockServices = new Mock<IUsersService>();
            var model = this.GetUsersDto();
            IEnumerable<UsersDto> listUsers = new List<UsersDto> { model };

            mockServices
                .Setup(m => m.GetAllUsersAsync())
                .Returns(Task.FromResult(listUsers));

            mockServices
                .Setup(m => m.GetUsersAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(model));

            mockServices
                .Setup(m => m.InsertUsers(It.IsAny<UsersDto>()))
                .Returns(Task.FromResult(true));

            this.modelFacade = new UsersFacade(mockServices.Object);
        }

        /// <summary>
        /// Test for selecting all models.
        /// </summary>
        /// <returns>nothing.</returns>
        [Test]
        public async Task GetAllUsersAsyncTest()
        {
            // arrange

            // Act
            var response = await this.modelFacade.GetListUsersActive();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Any());
        }

        /// <summary>
        /// gets the model.
        /// </summary>
        /// <returns>the model with the correct id.</returns>
        [Test]
        public async Task GetListUsersActive()
        {
            // arrange
            var id = 10;

            // Act
            var response = await this.modelFacade.GetListUsersActive(id);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(id, response.Id);
        }

        /// <summary>
        /// Test for inseting models.
        /// </summary>
        /// <returns>the bool if it was inserted.</returns>
        [Test]
        public async Task InsertUsers()
        {
            // Arrange
            var model = new UsersDto();

            // Act
            var response = await this.modelFacade.InsertUsers(model);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response);
        }
    }
}

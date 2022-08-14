// <summary>
// <copyright file="UsersServiceTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.Test.Services.Users
{
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Axity.Users.DataAccess.DAO.Users;
    using Axity.Users.Entities.Context;
    using Axity.Users.Services.Mapping;
    using Axity.Users.Services.Users;
    using Axity.Users.Services.Users.Impl;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;

    /// <summary>
    /// Class UsersServiceTest.
    /// </summary>
    [TestFixture]
    public class UsersServiceTest : BaseTest
    {
        private IUsersService modelServices;

        private IMapper mapper;

        private IUsersDao modelDao;

        private DatabaseContext context;

        /// <summary>
        /// Init configuration.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            this.mapper = mapperConfiguration.CreateMapper();

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "Temporal")
                .Options;

            this.context = new DatabaseContext(options);
            this.context.CatUsers.AddRange(this.GetAllUserss());
            this.context.SaveChanges();

            this.modelDao = new UsersDao(this.context);
            this.modelServices = new UsersService(this.mapper, this.modelDao);
        }

        /// <summary>
        /// Method to verify Get All Userss.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateGetAllUserss()
        {
            var result = await this.modelServices.GetAllUsersAsync();

            Assert.True(result != null);
            Assert.True(result.Any());
        }

        /// <summary>
        /// Method to validate get model by id.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task ValidateSpecificUserss()
        {
            var result = await this.modelServices.GetUsersAsync(2);

            Assert.True(result != null);
            Assert.True(result.FirstName == "Jorge");
        }

        /// <summary>
        /// test the insert.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [Test]
        public async Task InsertUsers()
        {
            // Arrange
            var model = this.GetUsersDto();

            // Act
            var result = await this.modelServices.InsertUsers(model);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
    }
}

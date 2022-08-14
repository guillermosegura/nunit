// <summary>
// <copyright file="BaseTest.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.Test
{
    using System;
    using System.Collections.Generic;
    using Axity.Users.Dtos.Users;
    using Axity.Users.Entities.Model;

    /// <summary>
    /// Class Base Test.
    /// </summary>
    public abstract class BaseTest
    {
        /// <summary>
        /// List of Userss.
        /// </summary>
        /// <returns>IEnumerable Userss.</returns>
        public IEnumerable<UsersModel> GetAllUserss()
        {
            return new List<UsersModel>()
            {
                new UsersModel { Id = 1, FirstName = "Alejandro", LastName = "Ojeda", Email = "alejandro.ojeda@axity.com", Birthdate = DateTime.Now },
                new UsersModel { Id = 2, FirstName = "Jorge", LastName = "Morales", Email = "jorge.morales@axity.com", Birthdate = DateTime.Now },
                new UsersModel { Id = 3, FirstName = "Arturo", LastName = "Miranda", Email = "arturo.miranda@axity.com", Birthdate = DateTime.Now },
                new UsersModel { Id = 4, FirstName = "Benjamin", LastName = "Galindo", Email = "benjamin.galindo@axity.com", Birthdate = DateTime.Now },
            };
        }

        /// <summary>
        /// Gets user Dto.
        /// </summary>
        /// <returns>the user.</returns>
        public UsersDto GetUsersDto()
        {
            return new UsersDto
            {
                Id = 10,
                FirstName = "Jorge",
                LastName = "Morales",
                Email = "test@test.com",
                Birthdate = DateTime.Now,
            };
        }
    }
}

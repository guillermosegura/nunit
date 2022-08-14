// <summary>
// <copyright file="IUsersService.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.Services.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Users.Dtos.Users;

    /// <summary>
    /// Interface Users Service.
    /// </summary>
    public interface IUsersService
    {
        /// <summary>
        /// Method for get all users from db.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<UsersDto>> GetAllUsersAsync();

        /// <summary>
        /// Method for get Users by id from db.
        /// </summary>
        /// <param name="id">User Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<UsersDto> GetUsersAsync(int id);

        /// <summary>
        /// Method for add Users to DB.
        /// </summary>
        /// <param name="model">Users Dto.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> InsertUsers(UsersDto model);
    }
}

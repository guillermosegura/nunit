// <summary>
// <copyright file="IUsersFacade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.Facade.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Users.Dtos.Users;

    /// <summary>
    /// Interface User Facade.
    /// </summary>
    public interface IUsersFacade
    {
        /// <summary>
        /// Method for get all list of Users.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<UsersDto>> GetListUsersActive();

        /// <summary>
        /// Method for get User by id.
        /// </summary>
        /// <param name="id">Id User.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<UsersDto> GetListUsersActive(int id);

        /// <summary>
        /// Method to add user to DB.
        /// </summary>
        /// <param name="model">User Model.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> InsertUsers(UsersDto model);
    }
}
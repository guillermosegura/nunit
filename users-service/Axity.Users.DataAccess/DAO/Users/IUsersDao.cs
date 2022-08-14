// <summary>
// <copyright file="IUsersDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.DataAccess.DAO.Users
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Users.Entities.Model;

    /// <summary>
    /// Interface IUserDao.
    /// </summary>
    public interface IUsersDao
    {
        /// <summary>
        /// Method for get all users from db.
        /// </summary>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<IEnumerable<UsersModel>> GetAllUsersAsync();

        /// <summary>
        /// Method for get user by id from db.
        /// </summary>
        /// <param name="id">Users Id.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<UsersModel> GetUsersAsync(int id);

        /// <summary>
        /// Method for add Users to DB.
        /// </summary>
        /// <param name="model">Users Dto.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the result of the asynchronous operation.</returns>
        Task<bool> InsertUsers(UsersModel model);
    }
}

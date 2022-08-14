// <summary>
// <copyright file="UsersDao.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.DataAccess.DAO.Users
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Axity.Users.Entities.Context;
    using Axity.Users.Entities.Model;

    /// <summary>
    /// Class Users Dao.
    /// </summary>
    public class UsersDao : IUsersDao
    {
        private readonly IDatabaseContext databaseContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersDao"/> class.
        /// </summary>
        /// <param name="databaseContext">DataBase Context.</param>
        public UsersDao(IDatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext ?? throw new ArgumentNullException(nameof(databaseContext));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UsersModel>> GetAllUsersAsync()
        {
            return await this.databaseContext.CatUsers.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<UsersModel> GetUsersAsync(int id)
        {
            return await this.databaseContext.CatUsers.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        /// <inheritdoc/>
        public async Task<bool> InsertUsers(UsersModel model)
        {
            var response = await this.databaseContext.CatUsers.AddAsync(model);
            bool result = response.State.Equals(EntityState.Added);
            await ((DatabaseContext)this.databaseContext).SaveChangesAsync();
            return result;
        }
    }
}

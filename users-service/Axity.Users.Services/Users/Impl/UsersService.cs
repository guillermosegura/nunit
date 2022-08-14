// <summary>
// <copyright file="UsersService.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.Services.Users.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AutoMapper;
    using Axity.Users.DataAccess.DAO.Users;
    using Axity.Users.Dtos.Users;
    using Axity.Users.Entities.Model;

    /// <summary>
    /// Class Users Service.
    /// </summary>
    public class UsersService : IUsersService
    {
        private readonly IMapper mapper;

        private readonly IUsersDao modelDao;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="mapper">Object to mapper.</param>
        /// <param name="modelDao">Object to modelDao.</param>
        public UsersService(IMapper mapper, IUsersDao modelDao)
        {
            this.mapper = mapper;
            this.modelDao = modelDao ?? throw new ArgumentNullException(nameof(modelDao));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UsersDto>> GetAllUsersAsync()
        {
            return this.mapper.Map<List<UsersDto>>(await this.modelDao.GetAllUsersAsync());
        }

        /// <inheritdoc/>
        public async Task<UsersDto> GetUsersAsync(int id)
        {
            return this.mapper.Map<UsersDto>(await this.modelDao.GetUsersAsync(id));
        }

        /// <inheritdoc/>
        public async Task<bool> InsertUsers(UsersDto model)
        {
            return await this.modelDao.InsertUsers(this.mapper.Map<UsersModel>(model));
        }
    }
}

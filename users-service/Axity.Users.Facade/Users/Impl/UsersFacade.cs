// <summary>
// <copyright file="UsersFacade.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.Facade.Users.Impl
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Axity.Users.Dtos.Users;
    using Axity.Users.Services.Users;

    /// <summary>
    /// Class Users Facade.
    /// </summary>
    public class UsersFacade : IUsersFacade
    {
        private readonly IUsersService modelService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersFacade"/> class.
        /// </summary>
        /// <param name="modelService">Interface Users Service.</param>
        public UsersFacade(IUsersService modelService)
        {
            this.modelService = modelService ?? throw new ArgumentNullException(nameof(modelService));
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<UsersDto>> GetListUsersActive()
        {
            return await this.modelService.GetAllUsersAsync();
        }

        /// <inheritdoc/>
        public async Task<UsersDto> GetListUsersActive(int id)
        {
            return await this.modelService.GetUsersAsync(id);
        }

        /// <inheritdoc/>
        public async Task<bool> InsertUsers(UsersDto model)
        {
            return await this.modelService.InsertUsers(model);
        }
    }
}

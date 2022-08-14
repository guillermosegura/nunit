// <summary>
// <copyright file="UsersController.cs" company="Axity">
// This source code is Copyright Axity and MAY NOT be copied, reproduced,
// published, distributed or transmitted to or stored in any manner without prior
// written consent from Axity (www.axity.com).
// </copyright>
// </summary>

namespace Axity.Users.Api.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Axity.Users.Dtos.Users;
    using Axity.Users.Facade.Users;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using StackExchange.Redis;

    /// <summary>
    /// Class Users Controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersFacade logicFacade;

        private readonly IDatabase database;

        private readonly IConnectionMultiplexer redis;

        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
        /// </summary>
        /// <param name="logicFacade">Users Facade.</param>
        /// <param name="redis">Redis Cache.</param>
        public UsersController(IUsersFacade logicFacade, IConnectionMultiplexer redis)
        {
            this.logicFacade = logicFacade ?? throw new ArgumentNullException(nameof(logicFacade));
            this.redis = redis ?? throw new ArgumentNullException(nameof(redis));
            this.database = redis.GetDatabase();
        }

        /// <summary>
        /// Method to get all Users.
        /// </summary>
        /// <returns>List of Users.</returns>
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await this.logicFacade.GetListUsersActive();
            return this.Ok(response);
        }

        /// <summary>
        /// Method to get Users By Id.
        /// </summary>
        /// <param name="id">Users Id.</param>
        /// <returns>Users Model.</returns>
        [Route("{UsersId}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            UsersDto response = null;

            ////Example to get value with Redis Cache
            var result = await this.database.StringGetAsync(id.ToString());

            if (!result.HasValue)
            {
                response = await this.logicFacade.GetListUsersActive(id);

                ////Example to set value with Redis Cache
                await this.database.StringSetAsync(id.ToString(), JsonConvert.SerializeObject(response));
            }
            else
            {
                ////If key in Redis, deserialize response and return object
                response = JsonConvert.DeserializeObject<UsersDto>(result);
            }

            return this.Ok(response);
        }

        /// <summary>
        /// Method to Add Users.
        /// </summary>
        /// <param name="dataToStore">Users Model.</param>
        /// <returns>Success or exception.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsersDto dataToStore)
        {
            var response = await this.logicFacade.InsertUsers(dataToStore);
            return this.Ok(response);
        }

        /// <summary>
        /// Method Ping.
        /// </summary>
        /// <returns>Pong.</returns>
        [Route("/ping")]
        [HttpGet]
        public IActionResult Ping()
        {
            return this.Ok("Pong");
        }
    }
}
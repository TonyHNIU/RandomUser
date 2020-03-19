using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomUser.Core.Models;
using RandomUser.DataAccess.Services;

namespace RandomUser.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        [Route("getusers")]
        [HttpGet]
        public async Task<List<UserModel>> GetUsers(string firstName = null, string lastName = null, int limit = 0)
        {
            using (var service = new UserService())
            {
                return await service.GetUsers(firstName, lastName, limit);
            }
        }

        [Route("getuser/{userId}")]
        [HttpGet]
        public async Task<UserModel> GetUser(int userId)
        {
            using (var service = new UserService())
            {
                return await service.GetUser(userId);
            }
        }

        [Route("updateuser")]
        [HttpPost]
        public async Task<UserModel> UpdateUser([FromBody] UserModel user)
        {
           
            using (var service = new UserService())
            {
                return await service.UpdateUser(user);
            }
        }

        [Route("deleteuser/{userId}")]
        [HttpDelete]
        public async void DeleteUser(int userId)
        {
            using (var service = new UserService())
            {
                await service.DeleteUser(userId);
            }
        }
    }
}

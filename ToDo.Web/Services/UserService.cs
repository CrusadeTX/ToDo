using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Web.Services
{
    public class UserService : IUserService
    {
        
        private readonly HttpClient httpClient;

        public UserService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<User> GetUser(int id)
        {
            return await httpClient.GetJsonAsync<User>($"api/users/{id}");
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await httpClient.GetJsonAsync<User[]>("api/users");
        
        }
        public async Task<User> UpdateUser(User updatedUser)
        {
            return await httpClient.PutJsonAsync<User>("api/users", updatedUser);
        }
        public async Task<User> CreateUser(User createdUser)
        {
            return await httpClient.PostJsonAsync<User>("api/users", createdUser);
        }
    }
}

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Web.Services;

namespace ToDo.Web.Pages
{
    public class UserListBase : ComponentBase
    {


        [Inject]
        public IUserService UserService { get; set; }
        public IEnumerable<User> Users { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Users = (await UserService.GetUsers()).ToList();
        }
    }
}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Web.Services;

namespace ToDo.Web.Pages
{
    public class UserDetailsBase : ComponentBase
    {
        public User user { get; set; } = new User();

        [Inject]
        public IUserService UserService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            user = await UserService.GetUser(int.Parse(Id));
        }

    }
}

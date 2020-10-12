using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Web.Services;

namespace ToDo.Web.Pages
{
    public class DeleteUserBase : ComponentBase
    {
        public User User { get; set; } = new User();


        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }
        protected async override Task OnInitializedAsync()
        {
            User = await UserService.GetUser(int.Parse(Id));
        }
        protected async Task Delete_Click()
        {
            await UserService.DeleteUser(User.UserId);
            NavigationManager.NavigateTo("/");
        }
    }
}

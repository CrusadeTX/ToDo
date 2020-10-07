using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Web.Models;
using ToDo.Web.Services;

namespace ToDo.Web.Pages
{
    public class EditUserDetailsBase : ComponentBase
    {
        public User User { get; set; } = new User();
        public EditUserModel EditUser { get; set; } = new EditUserModel();

        [Inject]
        public IUserService UserService { get; set; }
        public IToDoNoteService ToDoNoteService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
           User = await UserService.GetUser(int.Parse(Id));
            EditUser.UserId = User.UserId;
            EditUser.FName = User.FName;
            EditUser.LName = User.LName;
            EditUser.Email = User.Email;
            EditUser.Password = User.Password;
            EditUser.ToDos = User.ToDos;
           //User.ToDos = (await ToDoNoteService.GetToDos()).ToList();
        }
        protected async Task HandleValidSubmit()
        {
           User editedUser = new User();
            editedUser.FName = EditUser.FName;
            editedUser.UserId = EditUser.UserId;
            editedUser.LName = EditUser.LName;
            editedUser.Email = EditUser.Email;
            editedUser.Password = EditUser.Password;
            editedUser.ToDos = EditUser.ToDos;
            var result = await UserService.UpdateUser(editedUser);
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}

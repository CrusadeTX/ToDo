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
        public List<ToDoNote> ToDoNotes { get; set; } = new List<ToDoNote>();
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public IToDoNoteService ToDoNoteService { get; set; }
        public string UserId { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            ToDoNotes = (await ToDoNoteService.GetToDos()).ToList();
            user = await UserService.GetUser(int.Parse(Id));

            
        }
        protected async Task Delete_Click()
        {
            await UserService.DeleteUser(user.UserId);
            NavigationManager.NavigateTo("/");

        }

    }
}

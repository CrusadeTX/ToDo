using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Web.Services;

namespace ToDo.Web.Pages
{
    public class EditToDoNoteDetailsBase : ComponentBase
    {
        public ToDoNote ToDoNote { get; set; } = new ToDoNote();
        public List<User> Users { get; set; } = new List<User>();

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
            ToDoNote = await ToDoNoteService.GetToDo(int.Parse(Id));
            Users = (await UserService.GetUsers()).ToList();
            UserId = ToDoNote.UserId.ToString();


        }
    }
}

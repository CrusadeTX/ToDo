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
    public class CreateToDoNoteBase : ComponentBase
    {
        public ToDoNote ToDoNote { get; set; } = new ToDoNote();
        public List<User> Users { get; set; } = new List<User>();
        public EditToDoNoteModel EditToDoNote { get; set; } = new EditToDoNoteModel();

        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public IToDoNoteService ToDoNoteService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string UserId { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            ToDoNote = await ToDoNoteService.GetToDo(int.Parse(Id));
            Users = (await UserService.GetUsers()).ToList();
            UserId = ToDoNote.UserId.ToString();
            //EditToDoNote.IsDone = ToDoNote.IsDone;
            //EditToDoNote.ToDoNoteId = ToDoNote.ToDoNoteId;
            //EditToDoNote.ToDoText = ToDoNote.ToDoText;
            //EditToDoNote.ToDoTitle = ToDoNote.ToDoTitle;
            //foreach (User user in Users)
            //{
            //    if (user.UserId == ToDoNote.UserId)
            //    {
            //        EditToDoNote.User = user;
            //    }

            //}
            //EditToDoNote.UserId = ToDoNote.UserId;


        }
        protected async Task HandleValidSubmit()
        {
            ToDoNote editedToDoNote = new ToDoNote();
            editedToDoNote.IsDone = EditToDoNote.IsDone;
            editedToDoNote.ToDoNoteId = Int32.Parse(EditToDoNote.ToDoNoteId);
            editedToDoNote.ToDoText = EditToDoNote.ToDoText;
            editedToDoNote.ToDoTitle = EditToDoNote.ToDoTitle;
            editedToDoNote.User = EditToDoNote.User;
            editedToDoNote.UserId = Int32.Parse(EditToDoNote.UserId);
            var result = await ToDoNoteService.CreateToDo(editedToDoNote);
            if (result != null)
            {
                NavigationManager.NavigateTo("/ToDoNotes");
            }
        }
    

    }
}

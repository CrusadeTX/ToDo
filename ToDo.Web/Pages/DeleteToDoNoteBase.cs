using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Web.Services;

namespace ToDo.Web.Pages
{
    public class DeleteToDoNoteBase : ComponentBase
    {
        public ToDoNote ToDoNote { get; set; } = new ToDoNote();


        [Inject]
        public IToDoNoteService ToDoNoteService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id { get; set; }
        protected async override Task OnInitializedAsync()
        {
            ToDoNote = await ToDoNoteService.GetToDo(int.Parse(Id));
        }
        protected async Task Delete_Click()
        {
            await ToDoNoteService.DeleteToDo(ToDoNote.ToDoNoteId);
            NavigationManager.NavigateTo("/");
        }
    }
}


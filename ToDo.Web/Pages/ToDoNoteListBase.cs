using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Web.Services;

namespace ToDo.Web.Pages
{
    public class ToDoNoteListBase : ComponentBase
    {
        [Inject]
        public IToDoNoteService toDoNoteService { get; set; }
        public IEnumerable<ToDoNote> ToDoNotes { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ToDoNotes = (await toDoNoteService.GetToDos()).ToList();
        }
    }
}

using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Web.Services;

namespace ToDo.Web.Pages
{
    public class ToDoNoteDetailsBase : ComponentBase
    {
        public ToDoNote toDoNote { get; set; } = new ToDoNote();

        [Inject]
        public IToDoNoteService toDoNoteService { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            toDoNote = await toDoNoteService.GetToDo(int.Parse(Id));
        }

    }
}

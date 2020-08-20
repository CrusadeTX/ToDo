using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.API.Models
{
    interface IToDoNoteRepository
    {
        Task<IEnumerable<ToDoNote>> GetToDoNotes();
        Task<ToDoNote> GetToDoNote (int toDoNoteId);
        Task<ToDoNote> AddToDoNote(ToDoNote toDoNote);
        Task<ToDoNote> UpdateToDoNote(ToDoNote toDoNote);
        Task<ToDoNote> DeleteToDoNote(int toDoNoteId);
    }
}

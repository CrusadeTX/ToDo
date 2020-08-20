using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Web.Services
{
    public interface IToDoNoteService
    {
        Task<IEnumerable<ToDoNote>> GetToDos();
    }
}

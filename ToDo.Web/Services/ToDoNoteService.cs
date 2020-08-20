using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Web.Services
{
    public class ToDoNoteService : IToDoNoteService
    {
        public Task<IEnumerable<ToDoNote>> GetToDos()
        {
            throw new NotImplementedException();
        }
    }
}

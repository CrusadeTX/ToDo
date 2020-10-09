using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Web.Models
{
    public class EditToDoNoteModel
    {
        public string ToDoNoteId { get; set; }
        public string ToDoTitle { get; set; }
        public string ToDoText { get; set; }
        public string UserId { get; set; }
        public bool IsDone { get; set; }
        public User User { get; set; }
    }
}

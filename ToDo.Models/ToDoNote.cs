using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Models
{
    public class ToDoNote
    {
        public int ToDoNoteId { get; set; }
        public string ToDoTitle { get; set; }
        public string ToDoText { get; set; }
        public int UserId { get; set; }
        public bool IsDone { get; set; }
        public User User { get; set; }
    }
}

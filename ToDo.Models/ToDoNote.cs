using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ToDo.Models
{
    public class ToDoNote
    {
        public int ToDoNoteId { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 5)]
        public string ToDoTitle { get; set; }
        [Required]
        public string ToDoText { get; set; }
        public int UserId { get; set; }
        [Required]
        public bool IsDone { get; set; }
        public User User { get; set; }
    }
}

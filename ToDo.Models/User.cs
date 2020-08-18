using System;
using System.Collections.Generic;

namespace ToDo.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<ToDoNote> ToDos { get; set; }
    }
}

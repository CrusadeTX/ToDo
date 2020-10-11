using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Web.Models
{
    public class EditUserModel
    {

        public string UserId { get; set; }
       
        public string FName { get; set; }
        
        public string LName { get; set; }
       
        public string Email { get; set; }
        
        public string Password { get; set; }
       
        public List<ToDoNote> ToDos { get; set; }

    }
}

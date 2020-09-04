using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Web.Pages
{
    public class EditUserModel
    {
       
            public int UserId { get; set; }
            public string FName { get; set; }
            public string LName { get; set; }
            public string Email { get; set; }
            public string ConfirmEmail { get; set; }
        
    }
}

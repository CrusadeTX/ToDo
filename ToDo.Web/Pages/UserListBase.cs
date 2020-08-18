using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Web.Pages
{
    public class UserListBase : ComponentBase
    {
        public IEnumerable<User> Users { get; set; }
    }
}

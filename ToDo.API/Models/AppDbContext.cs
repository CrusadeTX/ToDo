using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.API
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {

        }
        public DbSet<ToDoNote> ToDos { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                FName = "First Name",
                LName = "Last Name",
                Password = "Pass",
                Email = "Email@Email.bg"


            });
            modelBuilder.Entity<ToDoNote>().HasData(new ToDoNote
            {
                UserId = 1,
                ToDoNoteId = 1,
                ToDoText = "Text",
                ToDoTitle = "Title",
                IsDone = false




            });
        }
    }
}

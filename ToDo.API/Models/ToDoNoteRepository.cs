using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.API.Models
{
    public class ToDoNoteRepository : IToDoNoteRepository
    {
        private readonly AppDbContext appDbContext;

        public ToDoNoteRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<ToDoNote> AddToDoNote(ToDoNote toDoNote)
        {
            var result = await appDbContext.ToDos.AddAsync(toDoNote);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ToDoNote> DeleteToDoNote(int toDoNoteId)
        {
            var result = await appDbContext.ToDos.FirstOrDefaultAsync(t => t.ToDoNoteId == toDoNoteId);
            if (result != null)
            {
                appDbContext.ToDos.Remove(result);
                await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<ToDoNote>> GetToDoNotes()
        {
            return await appDbContext.ToDos.ToListAsync();
        }

        public async Task<ToDoNote> GetToDoNote(int toDoNoteId)
        {
            return await appDbContext.ToDos.Include(t => t.User).FirstOrDefaultAsync(t => t.ToDoNoteId == toDoNoteId);
        }

        public async Task<ToDoNote> UpdateToDoNote(ToDoNote toDoNote)
        {
            var result = await appDbContext.ToDos
                .FirstOrDefaultAsync(t => t.ToDoNoteId == toDoNote.ToDoNoteId);

            if (result != null)
            {
                result.ToDoTitle = toDoNote.ToDoTitle;
                result.ToDoText = toDoNote.ToDoText;
                result.IsDone = toDoNote.IsDone;
                result.UserId = toDoNote.UserId;
                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}

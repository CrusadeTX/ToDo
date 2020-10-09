using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ToDo.Models;

namespace ToDo.Web.Services
{
    public class ToDoNoteService : IToDoNoteService
    {
        private readonly HttpClient httpClient;

        public ToDoNoteService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ToDoNote> GetToDo(int id)
        {
            return await httpClient.GetJsonAsync<ToDoNote>($"api/ToDoNotes/{id}");
        }

        public async Task<IEnumerable<ToDoNote>> GetToDos()
        {
            return await httpClient.GetJsonAsync<IEnumerable<ToDoNote>>($"api/ToDoNotes");
        }

        public async Task<ToDoNote> UpdateToDo(ToDoNote updatedToDoNote)
        {
            return await httpClient.PutJsonAsync<ToDoNote>("api/ToDoNotes", updatedToDoNote);
        }
        public async Task<ToDoNote> CreateToDo(ToDoNote createdToDoNote)
        {
            return await httpClient.PostJsonAsync<ToDoNote>("api/ToDoNotes", createdToDoNote);
        }
        public async Task DeleteToDo(int id)
        {
            await httpClient.DeleteAsync($"api/ToDoNotes/{id}");
        }
    }
}

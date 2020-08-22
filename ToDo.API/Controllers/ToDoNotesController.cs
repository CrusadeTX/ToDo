using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.API.Models;
using ToDo.Models;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoNotesController : ControllerBase
    {
        private readonly IToDoNoteRepository toDoNoteRepository;

        public ToDoNotesController(IToDoNoteRepository toDoNoteRepository)
        {
            this.toDoNoteRepository = toDoNoteRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoNote>>> GetToDos()
        {
            try
            {
                return Ok(await toDoNoteRepository.GetToDoNotes());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    e.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ToDoNote>> GetToDo(int id)
        {
            try
            {
                var result = await toDoNoteRepository.GetToDoNote(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }
        [HttpPost]
        public async Task<ActionResult<ToDoNote>> CreateToDo(ToDoNote toDoNote)
        {
            try
            {
                if (toDoNote == null)
                    return BadRequest();

                var createdToDo = await toDoNoteRepository.AddToDoNote(toDoNote);

                return CreatedAtAction(nameof(GetToDo),
                    new { id = createdToDo.ToDoNoteId }, createdToDo);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ToDoNote>> UpdateToDo(int id, ToDoNote toDoNote)
        {
            try
            {
                if (id != toDoNote.ToDoNoteId)
                    return BadRequest("ToDoNote ID mismatch");

                var toDoNoteToUpdate = await toDoNoteRepository.GetToDoNote(id);

                if (toDoNoteToUpdate == null)
                    return NotFound($"ToDoNote with Id = {id} not found");

                return await toDoNoteRepository.UpdateToDoNote(toDoNote);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ToDoNote>> DeleteToDoNote(int id)
        {
            try
            {
                var toDoNoteToDelete = await toDoNoteRepository.GetToDoNote(id);

                if (toDoNoteToDelete == null)
                {
                    return NotFound($"ToDoNote with Id = {id} not found");
                }

                return await toDoNoteRepository.DeleteToDoNote(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}

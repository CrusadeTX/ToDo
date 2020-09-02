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
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                return Ok(await userRepository.GetUsers());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database" + e.Message);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                var result = await userRepository.GetUser(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception e )
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database"+ e.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            try
            {
                if (user == null)
                    return BadRequest();

                var createdUser = await userRepository.AddUser(user);

                return CreatedAtAction(nameof(GetUser),
                    new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new employee record");
            }
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateEmployee(int id, User user)
        {
            try
            {
                if (id != user.UserId)
                    return BadRequest("User ID mismatch");

                var userToUpdate = await userRepository.GetUser(id);

                if (userToUpdate == null)
                    return NotFound($"User with Id = {id} not found");

                return await userRepository.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await userRepository.GetUser(id);

                if (userToDelete == null)
                {
                    return NotFound($"User with Id = {id} not found");
                }

                return await userRepository.DeleteUser(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

    }
}

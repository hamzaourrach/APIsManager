using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace APIsManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]/api")]
    public class UserController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public UserController(IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("AllUsers")]
        public IActionResult GetAllUsers()
        {
            try
            {
                var users = _repository.User.GetAllUsers();

                var userResult = _mapper.Map<IEnumerable<UserDto>>(users);
                _logger.LogInfo($"Returned all users from database.");
                return Ok(userResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllUsers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{email}/{password}", Name = "UserByEmailAndPassword")]
        public IActionResult SearchByEmailAndPassword(string email, string password)
        {
            try
            {
                var user = _repository.User.SearchByEmailAndPassword(email, password);

                if (user is null)
                {
                    _logger.LogError($"User with email: {email}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var userResult = _mapper.Map<UserDto>(user);
                    _logger.LogInfo($"Returned user from database.");
                    return Ok(userResult);
                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside SearchByEmailAndPassword action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetUserById/{id}", Name = "GetUserById")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _repository.User.GetUserById(id);

                if (user is null)
                {
                    _logger.LogError($"User with Id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var userResult = _mapper.Map<UserDto>(user);
                    _logger.LogInfo($"Returned user from database.");
                    return Ok(userResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetUserByIdAsync/{id}", Name = "GetUserByIdAsync")]
        public IActionResult GetUserByIdAsync(int id)
        {
            try
            {
                var user = _repository.User.GetUserById(id);

                if (user is null)
                {
                    _logger.LogError($"User with Id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    var userResult = _mapper.Map<UserDto>(user);
                    _logger.LogInfo($"Returned user from database.");
                    return Ok(userResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserByIdAsync action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserForCreationDto user)
        {
            try
            {
                if (user is null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var userEntity = _mapper.Map<User>(user);
                _repository.User.CreateUser(userEntity);
                _repository.Save();
                _logger.LogInfo("user object created successfully.");


                var createdUser = _mapper.Map<UserDto>(userEntity);
                return CreatedAtRoute("GetUserById", new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("UpdateUser/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserForUpdateDto user)
        {
            try
            {
                if (user is null)
                {
                    _logger.LogError("User object sent from client is null.");
                    return BadRequest("User object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var userEntity = _repository.User.GetUserById(id);
                if (userEntity is null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                
                var deletedUser = _mapper.Map<UserDto>(userEntity);
                _mapper.Map(user, userEntity);
                _repository.User.UpdateUser(userEntity);
                _repository.Save();
                _logger.LogInfo("user object Update successfully.");

                return CreatedAtRoute("GetUserById", new { id = deletedUser.Id }, deletedUser.Email + " User Update successfully.");
                //return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("DeleteUser/{id}", Name = "DeleteUserById")]
        public IActionResult DeleteUser(int id)
        {
            var user = _repository.User.GetUserById(id);
            try
            {
                var userEntity = _repository.User.GetUserById(id);
                if (userEntity is null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                var deletedUser = _mapper.Map<UserDto>(userEntity);
                _mapper.Map(user, userEntity);
                _repository.User.DeleteUser(userEntity);
                _repository.Save();
                _logger.LogInfo("user object deleted successfully.");

                return CreatedAtRoute("GetUserById", new { id = deletedUser.Id }, deletedUser.Email + " User Deleted Successfully.");
                //return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

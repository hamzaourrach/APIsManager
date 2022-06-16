using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIsManagerApi.Controllers
{
    [ApiController]
    [Route("[controller]/api/twitter")]
    public class TwitterController : Controller
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public TwitterController(IRepositoryWrapper repository, ILoggerManager logger, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("GetTwitterCredentialByUserId/{id}", Name = "GetUserTwitterCredential")]
        public IActionResult GetUserTwitterCredential(int id)
        {
            try
                {
                var userCredential = _repository.Twitter.GetCredential(id);

                if (userCredential is null)
                {
                    _logger.LogError($"User with Id: {id}, has no credential found in db.");
                    return NotFound();
                }
                else
                {
                    var userCredentialResult = _mapper.Map<TwitterCredentialDto>(userCredential);
                    _logger.LogInfo($"Returned user from database.");
                    return Ok(userCredentialResult);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUserTwitterCredential action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult AddUserCredential([FromBody] TwitterCredentialForCreationDto userTwitterCredential)
        {
            try
            {
                if (userTwitterCredential is null)
                {
                    _logger.LogError("User Twitter Credential object sent from client is null.");
                    return BadRequest("User Twitter Credential object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid user Twitter Credential object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var userTwitterCredentialEntity = _mapper.Map<TwitterCredential>(userTwitterCredential);
                _repository.Twitter.AddTwitterCredential(userTwitterCredentialEntity);
                _repository.Save();
                _logger.LogInfo("user Twitter Credential object created successfully.");


                var createdCredential = _mapper.Map<TwitterCredentialDto>(userTwitterCredentialEntity);
                return CreatedAtRoute("GetUserTwitterCredential", new { id = createdCredential.IdUser }, createdCredential);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside AddUserCredential action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}

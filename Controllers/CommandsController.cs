using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.REST.CRUD.Data;
using WebAPI.REST.CRUD.Dtos;
using WebAPI.REST.CRUD.Models;

namespace WebAPI.REST.CRUD.Controllers
{
    // api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // GET - api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandDto>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandDto>>(commands));
        }
        // GET - api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult <CommandDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);
            if(command != null)
            {
                return Ok(_mapper.Map<CommandDto>(command));
            }
            return NotFound();
        }
        // POST - api/commands
        [HttpPost]
        public ActionResult <CommandDto> AddCommand(CommandCreateDto cmd)
        {
            var command = _mapper.Map<Command>(cmd);
            _repository.CreateCommand(command);
            _repository.SaveChanges();
            var commandDtoObj = _mapper.Map<CommandDto>(command);

            return CreatedAtRoute(nameof(GetCommandById), new { 
                                Id = commandDtoObj.Id  },
                                commandDtoObj
                            );
        }
        // PUT - api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult <CommandDto> UpdateCommand(int id, CommandCreateDto cmd)
        {
            var cmdExist = _repository.GetCommandById(id);
            if(cmdExist == null)
            {
                return NotFound();
            }
            _mapper.Map(cmd, cmdExist);
            _repository.SaveChanges();
            return NoContent();
        }
        // PATCH - api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult <CommandDto> PartialUpdateCommand(int id, JsonPatchDocument<CommandCreateDto> patchdoc)
        {
            var cmdExist = _repository.GetCommandById(id);
            if (cmdExist == null)
            {
                return NotFound();
            }
            var cmdToPatch = _mapper.Map<CommandCreateDto>(cmdExist);
            patchdoc.ApplyTo(cmdToPatch, ModelState);
            if (!TryValidateModel(cmdToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(cmdToPatch, cmdExist);
            _repository.SaveChanges();
            return NoContent();
        }
        // DELETE - api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var cmdExist = _repository.GetCommandById(id);
            if (cmdExist == null)
            {
                return NotFound();
            }
            _repository.DeleteCommand(cmdExist);
            _repository.SaveChanges();
            return NoContent();
        }
    }
}

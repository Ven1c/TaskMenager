using AutoMapper;

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Project.Application.Tasks.Queries.GetProjectsList;
using Project.Application.Tasks.Queries.GetProjectDetails;
using Project.WebApi.Models;
using Project.Application.Tasks.Commands.CreateProject;
using Project.Application.Tasks.Commands.UpdateProject;
using Project.Application.Tasks.Commands.DeleteProject;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController:BaseController
    {

        private readonly IMapper _mapper;
        public ProjectController(IMapper mapper) => _mapper = mapper;


        [HttpGet]
        public async  Task<ActionResult<ProjectListVm>> GetAll()
        {
            var query = new GetProjectListQuery
            {
                AuthorId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectDetailsVm>> Get(Guid id)
        {
            var query = new GetProjectDetailsQuery
            {
                AuthorId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateProjectDto createNoteDto)
        {
            var command = _mapper.Map<CreateProjectCommand>(createNoteDto);
            command.AuthorId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProjectDto updateNoteDto)
        {
            var command = _mapper.Map<UpdateProjectCommand>(updateNoteDto);
            command.AuthorId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id)
        {
            var command = new DeleteProjectCommand
            {
                Id = id,
                AuthorId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

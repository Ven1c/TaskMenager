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

        /// <summary>
        /// Gets all projects from db to show, bad english
        /// </summary>
        ///  <remarks>
        /// Sample request:
        /// GET /note
        /// </remarks>
        ///  <returns>Returns ProjectListVm</returns>
        /// <response code="200">Success</response>
        /// <returns></returns>
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

        /// <summary>
        /// Get project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Create project from body  
        /// </summary>
        /// <param name="createProjectDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateProjectDto createProjectDto)
        {
            var command = _mapper.Map<CreateProjectCommand>(createProjectDto);
            command.AuthorId = UserId;
            var projectId = await Mediator.Send(command);
            return Ok(projectId);
        }

        /// <summary>
        /// Update project from body 
        /// </summary>
        /// <param name="updateProjectDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProjectDto updateProjectDto)
        {
            var command = _mapper.Map<UpdateProjectCommand>(updateProjectDto);
            command.AuthorId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete Project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

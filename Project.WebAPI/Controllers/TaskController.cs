using AutoMapper;
using Project.WebApi.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Project.Application.Tasks.Queries.TaskDetails;
using Project.Application.Tasks.Commands.AddTask;
using Project.Application.Tasks.Commands.ChangeStatus;
using Project.Application.Tasks.Commands.ChangeUser;
using Project.Application.Tasks.Commands.DeleteTask;
using Project.Application.Tasks.Queries.GetProjectsList;
using Project.Application.Tasks.Queries.GetProjectDetails;
using Project.Application.Tasks.Commands.CreateProject;
using Project.WebAPI.Models;
using Project.Application.Tasks.Commands.UpdateProject;
using Project.Application.Tasks.Commands.DeleteProject;
using Project.Application.Tasks.Queries.GetTaskList;

namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TaskController: BaseController
    {
        private readonly IMapper _mapper;
        public TaskController(IMapper mapper) => _mapper = mapper;


        /// <summary>
        /// Get task by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskDetailsVm>> Get(Guid id)
        {
            var query = new GetTaskDetails
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create Task
        /// </summary>
        /// <param name="addTaskDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] AddTaskDto addTaskDto)
        {
            var command = _mapper.Map<AddTaskCommand>(addTaskDto);
            command.UserId = UserId;
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }

        /// <summary>
        /// Change Status of task
        /// </summary>
        /// <param name="changeStatusDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatus([FromRoute] Guid id)
        {
            var changeStatusDto = new ChangeStatusDto
        {
            var command = _mapper.Map<ChangeStatusDto>(changeStatusDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Get all task by project id
        /// </summary>
        /// <param name="ProjectId"></param>
        /// <returns></returns>
        [HttpPatch("{ProjectId}")]
        public async Task<ActionResult<TaskDetailsVm>> GetByProject(Guid ProjectId)
        {
            var query = new GetTaskListQuery
            {
                UserId = UserId,
                ProjectId = ProjectId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Delete task
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteTaskCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}

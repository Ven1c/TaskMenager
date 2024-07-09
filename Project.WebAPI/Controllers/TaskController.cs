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
namespace Project.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TaskController: BaseController
    {
        private readonly IMapper _mapper;
        public TaskController(IMapper mapper) => _mapper = mapper;
        //TO DO
        //[HttpGet]

        //[HttpGet("{id}")]

        //[HttpPut]

        //[HttpPatch]

        //[HttpDelete("{id}")]

    }
}

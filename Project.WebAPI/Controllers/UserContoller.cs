using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Project.WebApi.Models;
using Project.Application.Users.Commands.Registration;
using AutoMapper;
using MediatR;

namespace Project.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UserContoller : BaseController
    {
        private readonly IMapper _mapper;
        public UserContoller(IMapper mapper) => _mapper = mapper;

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

        /// <summary>
        /// Register new member  
        /// </summary>
        /// <param name="RegisterDto"></param>
        /// <returns></returns>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] RegisterDto RegisterDto)
        {
            var command = _mapper.Map<RegistrationCommand>(RegisterDto);
            var registerId = await Mediator.Send(command);
            return Ok(registerId);
        }
    }
}

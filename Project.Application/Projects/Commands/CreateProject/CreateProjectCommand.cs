using System;
using AutoMapper;
using MediatR;

namespace Project.Application.Tasks.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public List<Guid> TasksId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public enum StatusCombination { New, Closed }
        
    }
    
}

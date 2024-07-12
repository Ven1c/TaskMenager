using System;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using MediatR;
using Projects.Domain;

namespace Project.Application.Tasks.Commands.CreateProject
{
    public class CreateProjectCommand : IRequest<Guid>
    {
        
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public List<Guid> TasksId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        
        public string[] StatusCombination {get; set; }

    }
    
}

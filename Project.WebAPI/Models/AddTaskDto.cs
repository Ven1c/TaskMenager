using AutoMapper;
using Project.Application.Common.Mappings;
using Project.Application.Tasks.Commands.AddTask;
using Project.WebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace Project.WebAPI.Models
{
    public class AddTaskDto: IMapWith<AddTaskCommand>
    {
        [Required]
        public Guid ProjectId { get; set; }
        public string TaskName { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddTaskDto, AddTaskCommand>()
                .ForMember(taskCommand => taskCommand.TaskName,
                    opt => opt.MapFrom(taskCommand => taskCommand.TaskName))
                .ForMember(taskCommand => taskCommand.Details,
                    opt => opt.MapFrom(taskCommand => taskCommand.Details))
                .ForMember(taskCommand => taskCommand.ProjectId,
                    opt => opt.MapFrom(taskCommand => taskCommand.ProjectId));
               
        }
    
    }
}

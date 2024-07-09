using AutoMapper;
using Project.Application.Common.Mappings;
using Project.Application.Tasks.Queries.GetProjectsList;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Tasks.Queries.GetTaskList
{
    public class TaskLookUpDto : IMapWith<Task_>
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task_, TaskLookUpDto>()
                .ForMember(projectDto => projectDto.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectDto => projectDto.TaskName,
                    opt => opt.MapFrom(project => project.TaskName));
        }
    }
}

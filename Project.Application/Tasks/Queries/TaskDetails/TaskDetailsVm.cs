using AutoMapper;
using Project.Application.Common.Mappings;
using Project.Application.Tasks.Queries.GetProjectDetails;
using Projects.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Tasks.Queries.TaskDetails
{
    public class TaskDetailsVm : IMapWith<Task_>
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string TaskName { get; set; }
        public string Details { get; set; }
        public string Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Task_, TaskDetailsVm>()
                .ForMember(taskVm => taskVm.TaskName,
                    opt => opt.MapFrom(task => task.TaskName))
                .ForMember(taskVm => taskVm.Details,
                    opt => opt.MapFrom(task => task.Details))
                .ForMember(taskVm => taskVm.Status,
                    opt => opt.MapFrom(task => task.Status))
                .ForMember(taskVm => taskVm.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(taskVm => taskVm.ProjectId,
                    opt => opt.MapFrom(task => task.ProjectId));
        }
    }
}

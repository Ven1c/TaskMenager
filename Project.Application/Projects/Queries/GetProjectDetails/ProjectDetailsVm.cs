using Project.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.Domain;
using AutoMapper;

namespace Project.Application.Projects.Queries.GetProjectDetails
{
    public class ProjectDetailsVm : IMapWith<Project_>
    {
        public Guid Id { get; set; }
       // public Guid[] TasksId { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project_, ProjectDetailsVm>()
                .ForMember(projectVm => projectVm.Name,
                    opt => opt.MapFrom(project => project.Name))
                .ForMember(projectVm => projectVm.Details,
                    opt => opt.MapFrom(project => project.Details))
                .ForMember(projectVm => projectVm.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectVm => projectVm.TasksId,
                   opt => opt.MapFrom(project => project.TasksId));
        }
    }
}

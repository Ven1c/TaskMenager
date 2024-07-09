using Project.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projects.Domain;
using AutoMapper;

namespace Project.Application.Tasks.Queries.GetProjectsList
{
    public class ProjectLookUpDto : IMapWith<Project_>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project_, ProjectLookUpDto>()
                .ForMember(projectDto => projectDto.Id,
                    opt => opt.MapFrom(project => project.Id))
                .ForMember(projectDto => projectDto.Name,
                    opt => opt.MapFrom(project => project.Name));
        }
    }
}

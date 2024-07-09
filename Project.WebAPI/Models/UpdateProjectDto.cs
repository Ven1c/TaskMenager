using AutoMapper;
using System;
using Project.Application.Common.Mappings;
using Project.Application.Projects.Commands.UpdateProject;


namespace Project.WebApi.Models
{
    public class UpdateProjectDto : IMapWith<UpdateProjectCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDto, UpdateProjectCommand>()
                .ForMember(projectCommand => projectCommand.Id,
                    opt => opt.MapFrom(projectCommand => projectCommand.Id))
                .ForMember(projectCommand => projectCommand.Name,
                    opt => opt.MapFrom(projectCommand => projectCommand.Name))
                .ForMember(projectCommand => projectCommand.Details,
                    opt => opt.MapFrom(projectCommand => projectCommand.Details));
        }
    }
}
using AutoMapper;
using Project.Application.Common.Mappings;
using Project.Application.Tasks.Commands.CreateProject;
using Projects.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.WebApi.Models
{
    public class CreateProjectDto : IMapWith<CreateProjectCommand>
    {
        
        public string Name { get; set; }
        public string Details { get; set; }
        
        public string[] StatusCombination {get; set;}
        
      
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                .ForMember(projectCommand => projectCommand.Name,
                    opt => opt.MapFrom(projectCommand => projectCommand.Name))
                .ForMember(projectCommand => projectCommand.Details,
                    opt => opt.MapFrom(projectCommand => projectCommand.Details))
                  .ForMember(projectCommand => projectCommand.StatusCombination,
                    opt => opt.MapFrom(projectCommand => projectCommand.StatusCombination));
        }
    }
}
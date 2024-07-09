﻿using AutoMapper;
using Project.Application.Common.Mappings;
using Project.Application.Tasks.Commands.CreateProject;
using System.ComponentModel.DataAnnotations;

namespace Project.WebApi.Models
{
    public class CreateProjectDto : IMapWith<CreateProjectCommand>
    {
        [Required]
        public string Name { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                .ForMember(projectCommand => projectCommand.Name,
                    opt => opt.MapFrom(projectCommand => projectCommand.Name))
                .ForMember(projectCommand => projectCommand.Details,
                    opt => opt.MapFrom(projectCommand => projectCommand.Details));
        }
    }
}
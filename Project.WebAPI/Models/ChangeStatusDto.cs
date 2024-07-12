using AutoMapper;
using Project.Application.Common.Mappings;
using Project.Application.Tasks.Commands.ChangeStatus;
using Project.Application.Tasks.Commands.UpdateProject;
using Project.WebApi.Models;

namespace Project.WebAPI.Models
{
    public class ChangeStatusDto:IMapWith<ChangeTaskStatusCommand>
    {
        public Guid Id { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChangeStatusDto, ChangeTaskStatusCommand>()
                .ForMember(taskCommand => taskCommand.Id,
                    opt => opt.MapFrom(taskCommand => taskCommand.Id));

        }
    }
}

using AutoMapper;
using Project.Application.Common.Mappings;
using Project.Application.Users.Commands.Registration;
using Projects.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.WebApi.Models
{
    public class RegisterDto : IMapWith<RegistrationCommand>
    {

        public string Login { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<RegisterDto, RegistrationCommand>()
                .ForMember(RegistrationCommand => RegistrationCommand.Login,
                    opt => opt.MapFrom(RegistrationCommand => RegistrationCommand.Login))
                .ForMember(RegistrationCommand => RegistrationCommand.Password,
                    opt => opt.MapFrom(RegistrationCommand => RegistrationCommand.Password))
                .ForMember(RegistrationCommand => RegistrationCommand.UserName,
                    opt => opt.MapFrom(RegistrationCommand => RegistrationCommand.UserName))
                .ForMember(RegistrationCommand => RegistrationCommand.UserRole,
                    opt => opt.MapFrom(RegistrationCommand => RegistrationCommand.UserRole));
        }
    }
}
using System.ComponentModel.Design;
using AutoMapper;
using StudyProject.Data.DTOs;
using StudyProject.Data.ResponseDTOs.DTOs;
using StudyProject.Models;

namespace StudyProject.Utils.Automapper;

public class ModelMapper : Profile
{
    public ModelMapper()
    {
        CreateMap<Person, PersonUserDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.UsersDTO, opt => opt.MapFrom(src => src.Users))
            .ReverseMap();

        CreateMap<Person, CreatePersonUserDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Users))
            .ReverseMap();

        CreateMap<User, UserDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Accesses, opt => opt.MapFrom(src => src.Accesses))
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom(src => src.PersonId))
            .ReverseMap();

        CreateMap<User, CreateUserDTOs>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Accesses, opt => opt.MapFrom(src => src.Accesses))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
            .ReverseMap();

        CreateMap<User, CreateUserDeviceDTO>()
            .ForMember(dest => dest.Login, opt => opt.MapFrom(src => src.Login))
            .ForMember(dest => dest.Accesses, opt => opt.MapFrom(src => src.Accesses))
            .ForMember(dest => dest.createDevicedTO, opt => opt.MapFrom(src => src.Device))
            .ReverseMap();

        CreateMap<Device, DeviceDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ReverseMap();

        CreateMap<Device, CreateDeviceDTO>()
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .ReverseMap();

        CreateMap<CreateUserDeviceDTO, User>()
            .ForMember(dest => dest.PersonId, opt => opt.MapFrom((src, dest, destMember, context) => (long)context.Items["PersonId"]));
    }
}
using AutoMapper;
using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.Address;
using IsacGulaker_Uppgift_Dataatkomster.Models.User;
using IsacGulaker_Uppgift_Dataatkomster.Services.User;

namespace IsacGulaker_Uppgift_Dataatkomster
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CreateUserModel, UserEntity>()
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.NewUserFirstName))
                .ForMember(dest => dest.LastName, act => act.MapFrom(src => src.NewUserLastName))
                .ForMember(dest => dest.EmailAddress, act => act.MapFrom(src => src.NewUserEmailAddress))
                .ForMember(dest => dest.PhoneNumber, act => act.MapFrom(src => src.NewUserPhoneNumber))
                .ForMember(dest => dest.AlternativePhoneNumber, act => act.MapFrom(src => src.NewUserAlternativePhoneNumber));
            CreateMap<UserEntity, RequestUserModel>();

            CreateMap<CreateAddressModel, AddressEntity>()
                .ForMember(dest => dest.City, act => act.MapFrom(src => src.NewAddressCity))
                .ForMember(dest => dest.PostalCode, act => act.MapFrom(src => src.NewAddressPostalCode))
                .ForMember(dest => dest.StreetName, act => act.MapFrom(src => src.NewAddressStreetName))
                .ForMember(dest => dest.ResidenceNumber, act => act.MapFrom(src => src.NewAddressResidenceNumber));
            CreateMap<AddressEntity, RequestAddressModel>();
        }
    }
}

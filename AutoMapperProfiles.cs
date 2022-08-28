using AutoMapper;
using IsacGulaker_Uppgift_Dataatkomster.Data.Entities;
using IsacGulaker_Uppgift_Dataatkomster.Models.Address;
using IsacGulaker_Uppgift_Dataatkomster.Models.Category;
using IsacGulaker_Uppgift_Dataatkomster.Models.Manufacturer;
using IsacGulaker_Uppgift_Dataatkomster.Models.Order;
using IsacGulaker_Uppgift_Dataatkomster.Models.Product;
using IsacGulaker_Uppgift_Dataatkomster.Models.Subcategory;
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

            CreateMap<CreateProductModel, ProductEntity>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.NewProductName))
                .ForMember(dest => dest.Description, act => act.MapFrom(src => src.NewProductDescription))
                .ForMember(dest => dest.Subcategory, act => act.MapFrom(src => src.NewProductSubcategory))
                .ForMember(dest => dest.Price, act => act.MapFrom(src => src.NewProductPrice))
                .ForMember(dest => dest.Manufacturer, act => act.MapFrom(src => src.NewProductManufacturer))
                .ForMember(dest => dest.EAN_13, act => act.MapFrom(src => src.NewProductEAN_13));
            CreateMap<ProductEntity, RequestProductModel>();

            CreateMap<CreateSubcategoryModel, SubcategoryEntity>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.NewSubcategoryName))
                .ForMember(dest => dest.Category, act => act.MapFrom(src => src.NewSubcategoryCategory));
            CreateMap<SubcategoryEntity, RequestSubcategoryModel>();

            CreateMap<CreateCategoryModel, CategoryEntity>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.NewCategoryName));
            CreateMap<CategoryEntity, RequestCategoryModel>();

            CreateMap<CreateManufacturerModel, ManufacturerEntity>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.NewManufacturerName))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => src.NewManufacturerAddress));
            CreateMap<ManufacturerEntity, RequestManufacturerModel>();

            CreateMap<CreateOrderModel, OrderEntity>();
        }
    }
}

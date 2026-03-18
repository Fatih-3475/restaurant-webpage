using ApiProjeWeb.Dtos.FeatureDtos;
using ApiProjeWeb.Dtos.MessegeDtos;
using ApiProjeWeb.Dtos.ProductDto;
using ApiProjeWeb.Entities;
using ApiWebV1.Dtos.CategoryDtos;
using ApiWebV1.Dtos.NotificationDtos;
using ApiWebV1.Entities;
using AutoMapper;
namespace ApiProjeWeb.Mapping
{
    public class GeneralMapping :Profile
    {
        public GeneralMapping() 
        {
            //ReverseMap() kullanarak dönüşümleri iki yönlü hale getirdik.
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();


            CreateMap<Messega, ResultMessegeDto>().ReverseMap();
            CreateMap<Messega, CreateMessegeDto>().ReverseMap();
            CreateMap<Messega, UpdateMessegeDto>().ReverseMap();
            CreateMap<Messega, GetByIdMessegeDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductWithCategoryDto>().ForMember(x=>x.CategoryName,y=>y.MapFrom(z=>z.Category.CategoryName)).ReverseMap();

            CreateMap<Notification, ResultNotificationDto>().ReverseMap();
            CreateMap<Notification, CreateNotificationDto>().ReverseMap();
            CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
            CreateMap<Notification, GetNotificationByIdDto>().ReverseMap();


            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}

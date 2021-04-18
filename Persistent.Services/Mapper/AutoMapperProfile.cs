using AutoMapper;
using Products.Domain.Entites;
using Products.Domain.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Persistence.Services.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Product....................
            CreateMap<Product, ViewProductModel>()
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Catergory, opt => opt.MapFrom(src => src.Catergory.Name)).ReverseMap();

            CreateMap<Product, CreateProductModel>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.CatergoryId, opt => opt.MapFrom(src => src.CatergoryId)).ReverseMap();
            //.............................
        }
    }
}

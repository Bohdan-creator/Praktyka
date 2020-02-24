using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication12.Models;
using WebApplication12.ViewModels;

namespace WebApplication12.Configuration
{
    public  static class AutoMapperConfig
    {

        public static IMapperConfigurationExpression Mapping(this IMapperConfigurationExpression configurationExpression)
        {
            Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<Pacient, PacientDetailsVm>()
                .ForMember(dest => dest.StartWeight, x => x.MapFrom(src => src.TargetWeight))
                .ForMember(dest => dest.EatNo, x => x.MapFrom(src => src.Сontraindication))
                .ForMember(dest => dest.DietName, x => x.MapFrom(src => src.Diet.Name))
         .ForMember(dest => dest.Meals, x => x.MapFrom(src => src.Diet.Meals));
                mapper.CreateMap<Diet, DietDetailsVm>();
                mapper.CreateMap<Meal, MealCreateVm>();
               
            });

            return configurationExpression;
        }
     
    }
}
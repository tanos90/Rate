using AutoMapper;
using DAL.Models;
using Rate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Rate.Mapping
{
    public class MappingConfigurations
    {
        public static void Init(IMapperConfigurationExpression mapper)
        {
            mapper.CreateMap<ReviewDTO, Review>().
                ForMember(dest => dest.Flick, opt=>opt.MapFrom(src=>src.Flick))
                  .ReverseMap();
            mapper.CreateMap<FlickDTO, Flick>().
                ForMember(dest => dest.Id, opt=> opt.MapFrom(src=>src.ImdbId))
                .ReverseMap();
        }
    }
}
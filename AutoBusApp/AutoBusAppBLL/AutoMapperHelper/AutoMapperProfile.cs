using AutoBusAppBLL.DTOModels;
using AutoMapper;
using DataAccessLayer.Models;

namespace AutoBusAppBLL.AutoMapperHelper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UrlAddDto, UrlModel>().ReverseMap();
            CreateMap<UrlEditDto, UrlModel>().ReverseMap();
        }
    }
}

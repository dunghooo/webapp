using AutoMapper;
using webapptest.DTOs.ItemListDTO;
using webapptest.Models;

namespace webapptest.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TblOrderDetail, AddItemListDto>().ReverseMap();
        }
    }
}

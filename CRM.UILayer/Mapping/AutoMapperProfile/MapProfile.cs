using AutoMapper;
using CRM.DTOLayer.ContactDTOs;
using CRM.DTOLayer.CustomerDTOs;
using CRM.EntityLayer.Concrete;

namespace CRM.UILayer.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()//Constructor
        {
            CreateMap<ContactAddDTO, Contact>().ReverseMap();

            CreateMap<ContactListDTO, Contact>().ReverseMap();

            CreateMap<ContactUpdateDTO, Contact>().ReverseMap();

            CreateMap<CustomerAddDTO, Customer>();
            CreateMap<Customer, CustomerAddDTO>();
        }
    }
}

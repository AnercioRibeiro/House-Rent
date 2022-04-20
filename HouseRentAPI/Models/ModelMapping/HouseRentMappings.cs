using AutoMapper;
using HouseRentAPI.Models.DTOs;

namespace HouseRentAPI.Models.ModelMapping
{
    public class HouseRentMappings : Profile
    {
        public HouseRentMappings()
        {
            CreateMap<Anouncement, AnouncementCreateDTO>().ReverseMap();
            CreateMap<Anouncement, AnouncementDTO>().ReverseMap();
            CreateMap<Anouncement, AnouncementUpdateDTO>().ReverseMap();
        }
    }
}

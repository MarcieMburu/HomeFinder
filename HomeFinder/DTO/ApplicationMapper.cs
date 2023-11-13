using AutoMapper;
using HomeFinder.Models;
using NuGet.Protocol.Plugins;

namespace HomeFinder.DTO
{
    
        public class ApplicationMapper : Profile
        {
            public ApplicationMapper()
            {

                CreateMap<HouseDetails, HouseDetailsViewModel>().ReverseMap();



               
            }
        }
    }


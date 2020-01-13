using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(
                    destination => destination.PhotoUrl,
                    options => options.MapFrom(
                        source => source.Photos.FirstOrDefault(p => p.IsMain).Url
                        )
                    )
                .ForMember(
                    destination => destination.Age,
                    options => options.MapFrom(
                        source => source.DateOfBirth.CalculateAge()
                    )
                );
            CreateMap<User, UserForDetailsDto>()
                .ForMember(
                    dest => dest.PhotoUrl,
                    options => options.MapFrom(
                        source => source.Photos.FirstOrDefault(p => p.IsMain).Url
                        )
                    )
                .ForMember(
                    destination => destination.Age,
                    options => options.MapFrom(
                        source => source.DateOfBirth.CalculateAge()
                    )
                ); ;
            CreateMap<Photo, PhotosForDetailsDto>();
        }
    }
}
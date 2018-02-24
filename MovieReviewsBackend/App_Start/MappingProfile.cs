using AutoMapper;
using MovieReviewsBackend.DTOs;
using MovieReviewsBackend.Models.Entities;
using MovieReviewsBackend.Models.MovieModels;
using MovieReviewsBackend.ViewModels;

namespace MovieReviewsBackend.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //maping review
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
            CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));
        }

    }
}
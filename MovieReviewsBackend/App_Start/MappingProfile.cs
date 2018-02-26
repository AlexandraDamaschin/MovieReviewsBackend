using AutoMapper;
using MovieReviewsBackend.DTOs;
using MovieReviewsBackend.Models.MovieModels;

namespace MovieReviewsBackend.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //maping review
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();
        }

    }
}
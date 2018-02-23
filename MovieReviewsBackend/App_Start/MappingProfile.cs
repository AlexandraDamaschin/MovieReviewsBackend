using AutoMapper;
using MovieReviewsBackend.DTOs;
using MovieReviewsBackend.Models.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewsBackend.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //maping review
            CreateMap<Review, ReviewDto>();
            CreateMap<ReviewDto, Review>();}
        }
}
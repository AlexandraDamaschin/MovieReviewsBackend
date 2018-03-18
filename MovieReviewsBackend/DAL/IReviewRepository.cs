﻿using MovieReviewsBackend.Models.MovieModels;
using System;
using System.Collections.Generic;

namespace MovieReviewsBackend.DAL
{
    interface IReviewRepository 
    {
        List<Review> GetReviews();
        Review GetReviewById(int id);
    }
}

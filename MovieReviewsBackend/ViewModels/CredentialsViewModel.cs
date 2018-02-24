using FluentValidation.Attributes;
using MovieReviewsBackend.ViewModels.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewsBackend.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
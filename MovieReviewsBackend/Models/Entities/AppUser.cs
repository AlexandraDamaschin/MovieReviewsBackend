using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewsBackend.Models.Entities
{
    // Add profile data for application users by adding properties to this class
    public class AppUser: IdentityUser
    {
        //extended properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
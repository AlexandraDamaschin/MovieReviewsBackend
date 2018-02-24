using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieReviewsBackend.Models.Entities
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string IdentityId { get; set; }
        public AppUser Identity { get; set; }
        public string Location { get; set; }
    }
}
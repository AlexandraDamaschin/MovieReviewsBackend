﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MovieReviewsBackend.Startup))]

namespace MovieReviewsBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

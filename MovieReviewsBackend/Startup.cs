using Microsoft.Owin;
using Owin;


[assembly: OwinStartup(typeof(MovieReviewsBackend.Startup))]

namespace MovieReviewsBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            

            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithOrigins("http://localhost:4200");///////////////////////point to angular-------josh
            }));


            services.AddSignalR();//SignalR
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("chat");
            });
        }


    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using PCWebShop.Data;
using Microsoft.EntityFrameworkCore;
using PCWebShop.Extensions;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Identity;
using PCWebShop.HubConfig;
using PCWebShop.TimerFeatures;
using PCWebShop.Controllers;
using PCWebShop.Core.Services;
using PCWebShop.Core.Interfaces;

namespace PCWebShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins("http://localhost:4200")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();


                });
            });


            services.AddDbContext<Context>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));




            var origins = Configuration.GetSection("AllowedDomains").Value;

            services.AddCors(options =>
            {
                options.AddPolicy("AppPolicy",
                builder =>
                {
                    builder.WithOrigins(origins)
                    .AllowAnyHeader()
                    .AllowAnyMethod();

                });
            });

            services.AddSingleton<IEmailSender, EmailSender>();

            //Dependecy injection
            services.ConfigureServices(Configuration);

            services.AddIdentity<IdentityUser, IdentityRole>(opt =>
            {

            }
           ).AddEntityFrameworkStores<Context>().AddDefaultTokenProviders();

            services.AddSignalR();

            services.AddSingleton<TimerManager>();
            services.AddSingleton<TimerManager2>();

            services.AddScoped<KorisnikController>();
            services.AddScoped<ProizvodController>();
            services.AddScoped<OglasController>();
            services.AddScoped<PostController>();
            services.AddScoped<NarudzbaController>();

            services.AddControllers();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            //HANGFIRE CONFIG
            services.AddHangfire(config =>
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseDefaultTypeSerializer()
                .UseMemoryStorage());

            services.AddHangfireServer();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(
            IApplicationBuilder app,
            IWebHostEnvironment env,
            IBackgroundJobClient backgroundJobClient, 
            IRecurringJobManager recurringJobManager, 
            IServiceProvider serviceProvider,
            IEmailSender emailSender)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors("CorsPolicy");

            app.UseDefaultFiles();
            app.UseStaticFiles();


            app.UseSwagger();



            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors("AppPolicy");

            app.UseCors(
               options => options
               .SetIsOriginAllowed(x => _ = true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
           ); //This needs to set everything allowed



            app.UseHttpsRedirection();




            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapHub<ChartHub>("/Chart");
                endpoints.MapHub<ChartHub2>("/Chart2");

            });


            app.UseHangfireDashboard();
            recurringJobManager.AddOrUpdate(
             "Run at 7AM every day//SendEmailAsync",
             () => serviceProvider.GetService<IEmailSender>().SendEmailAsync("benaid.rudan@gmail.com", "benaid.rudan@gmail.com", "Daily Email", "Hello, this is your daily email."),
             "0 0 7 * * ?"
             );

        }
    }
}

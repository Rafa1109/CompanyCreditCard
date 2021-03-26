using AutoMapper;
using CompanyCreditCard.Configurations;
using CompanyCreditCard.Infra.CrossCutting.IoC;
using CompanyCreditCard.Infra.Data.Context;
using CompanyCreditCard.Mappings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace CompanyCreditCard
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
            services.AddMvc(opt => { opt.EnableEndpointRouting = false; })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddAutoMapper(typeof(Startup));

            NativeInjectorBootStrapper.Register(services);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            services.AddSingleton(AutoMapperConfiguration.RegisterMappings().CreateMapper());
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));


            services.AddDbContext<CompanyCreditCardContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CompanyDB"));
            });

            // services.AddJwt(Configuration);

            services.AddSwaggerConfig(new OpenApiInfo
            {
                Version = "v1",
                Title = "Rafael API",
                Description = "API para teste",
                Contact = new OpenApiContact
                {
                    Name = "RafaelCompany",
                    Email = "rafaelmachado.cardoso@outlook.com"
                }
            }); 

            services.AddMediatR(typeof(Startup));
            
            services.AddDIConfiguration();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddMemoryCache();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseStaticFiles();
            app.UseMvc();

            app.UseAuthentication();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Rafael API v1.0");
                s.DocExpansion(DocExpansion.None);
            });

            UpdateDatabaseUsingEfCore(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void UpdateDatabaseUsingEfCore(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope
                    .ServiceProvider
                    .GetRequiredService<CompanyCreditCardContext>()
                    .Database.Migrate();
            }
        }
    }
}

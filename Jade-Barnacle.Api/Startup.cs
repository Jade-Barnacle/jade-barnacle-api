using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Jade.Barnacle.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Options;
using Jade.Barnacle.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;


namespace jade.barnacle.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            string authority = Configuration["Auth0:Authority"]??
            throw new ArgumentNullException("Auth0:Authority");

            string audience = Configuration["Autho0:Audience"] ??
            throw new ArgumentNullException("Auth0:Audience");


            services.AddControllers();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

            services.AddAuthorization(options =>
            {
                options.AddPolicy("delete:catalog", PolicyServiceCollectionExtensions =>
                policy.RequireAuthenticatedUser().RequireClaim("scope", "delete: catalog"));
        });
            
            .AddJwtBearer(options =>
            {
                options.Authority = authority;
                options.Audience = audience;
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<StoreContext>(options =>
                options.UseSqlite("Data Source =../Registrar.sqlite",
                    b => b.MigrationsAssembly("Jade-Barnacle.Api")));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            services.AddEndpointsApiExplorer();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
                "jade.barnacle.Api v1"));
            }
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

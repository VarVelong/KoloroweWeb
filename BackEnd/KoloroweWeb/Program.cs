
using KoloroweWeb.Entities;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using System.Configuration;
using static KoloroweWeb.Entities.KolorowewebContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KoloroweWeb
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEntityFrameworkMySQL()
                .AddDbContext<KolorowewebContext>(options =>
                {
                    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
                });

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => //i will work
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("JwtSettings:Secret")))
                };
            });

            builder.Services.AddAuthorization();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseCors(builder => builder
                 .AllowAnyHeader()
                 .AllowAnyMethod()
                 .SetIsOriginAllowed((host) => true)
                 .AllowCredentials()
             );

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.Run();



            // Builder for DbContext


            //builder.Services.AddDbContext<KolorowewebContext>(options =>
            //options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));



        }
    }

}


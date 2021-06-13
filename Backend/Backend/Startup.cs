using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Backend.Controllers;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Backend
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

			services.AddDbContext<Context>(options =>
				// options.UsePostgresSql(Configuration.GetConnectionString("DefaultConnection")));
				options.UseSqlite(Configuration.GetConnectionString("SqlLiteConnection")));

			services.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<Context>();

			services.AddSwaggerGen(swagger =>
			{
				//This is to generate the Default UI of Swagger Documentation
				swagger.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "ASP.NET 5 Web API",
					Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
				});
				// To Enable authorization using Swagger (JWT)
				swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
				});
				swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string[] {}

					}
				});
			});

			services.AddControllers().AddNewtonsoftJson(options =>
				options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			);
			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequireDigit = false;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireLowercase = false;
				options.Password.RequireUppercase = false;
				options.Password.RequiredLength = 6;
			});

			var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT"]);

			services.AddAuthentication(o =>
			{
				o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(o=> {
				o.RequireHttpsMetadata = false;
				o.SaveToken = false;
				o.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ClockSkew = TimeSpan.Zero
				};
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseOpenApi();
			}

			app.UseCors(builder =>
			{
				builder.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader();
			});

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseSwagger(c =>
			{
				c.SerializeAsV2 = true;
			});
			app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ASP.NET 5 Web API v1"));

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using utility_handler.Utility;
using Microsoft.OpenApi.Models;
using HRM.APIClients;
using HRM.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using HRM.Api.Extensions;
//using HRM.Api.Middleware;
//using HRM.Api.Util.Email;
//using HRM.Api.Util.Options;

namespace HRM
{
    public class Startup
    {
        //private readonly string _policyName = "CorsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddDbContext<IntegrationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services
            //    .AddAuthentication("xx-token")//2022/7/13

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie()
            .AddOpenIdConnect("Auth0", options =>
            {
                // Set the authority to the Auth0 domain
                options.Authority = $"https://{Configuration["Auth0:Domain"]}";
                options.ClientId = Configuration["Auth0:ClientId"];
                options.ClientSecret = Configuration["Auth0:ClientSecret"];
                options.ResponseType = OpenIdConnectResponseType.Code;

                options.Scope.Clear();
                options.Scope.Add("openid");

                options.CallbackPath = new PathString("/callback");

                options.ClaimsIssuer = "Auth0";

                //options.Events = new OpenIdConnectEvents
                //{
                //    //OnRedirectToIdentityProviderForSignOut = (context)
                //}

            })
                .AddJwtBearer("xx-token", options =>
                {

                    var KeyBytes = Encoding.UTF8.GetBytes(constants.Secret);

                    var key = new SymmetricSecurityKey(KeyBytes);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = constants.Ishuer,
                        ValidAudience = constants.Audience,
                        IssuerSigningKey = key


                    };
                });

            services.AddScoped<IHttpClientHelper, HttpClientHelper>();
            services.AddScoped<IHRMApiClient, HRMApiClient>();
            services.AddScoped<IKioskiApiClient, KioskiApiClient>();
            //services.AddMvc().AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; }); ;

            services.Configure<HRMOptions>(Configuration.GetSection(HRMOptions.Position));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", p =>
                {
                    p.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });


            services.AddControllers()
            .AddJsonOptions(options =>
             {
                 options.JsonSerializerOptions.PropertyNamingPolicy = null;
                 //options.JsonSerializerOptions.IgnoreNullValues = true;
             });

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new OpenApiInfo
            //    {
            //        Title = "HRM_API",
            //        Version = "v1",
            //        Description = ""
            //    });
            //});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "HRM API Documentation",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "SDDRIT",
                        Email = "info@sddrit.com"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Apache 2.0",
                        Url = new Uri("http://www.apache.org/licenses/LICENSE-2.0.html")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });



            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment("DevelopmentLk") || env.IsEnvironment("DevelopmentId") || env.IsEnvironment("UatId") || env.IsEnvironment("UatLk") || env.IsEnvironment("TestLk") || env.IsEnvironment("TestId"))
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRM.Api v1 " + env.EnvironmentName));
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger(c =>
                {
                    c.SerializeAsV2 = true;
                });

                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRM_API v1")
                );
            }



            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors("AllowAll");
            
            app.UseAuthentication();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //29:25
                endpoints.MapControllers();
            });

        }
    }
}

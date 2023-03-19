using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;
using WebApiTemplate.Context;
using WebApiTemplate.Filter;
using WebApiTemplate.Services;
using WebApiTemplate.Utility;

namespace WebApiTemplate
{
    //lcano-01- aso para habilitar la clase startUp en plantilla
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            //Permite limpieza del cliem del token
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            _configuration = configuration;
        }


        public void ConfigurationServices(IServiceCollection services)
        {
            //.Services.AddControllers();
            services.AddControllers( opciones=>
            {
                //Para agregar el filtro de excepcion a modo global.
                opciones.Filters.Add(typeof(MyFilterException));

                //Opcion que permite implementar control de version en las apis
                opciones.Conventions.Add(new SwaggerGroupByVersion());

            }).AddJsonOptions(x => 
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                   _configuration.GetConnectionString("defaultConnection") 
                ));


            //lcano - 07.02 en la configuracion del Identity, para que se reconozca el servicio y trabajar con roles
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters{
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(_configuration["KeyJwt"])),
                    ClockSkew = TimeSpan.Zero
                });


            services.AddTransient<MyFilterAction>();


            //Ambos servicios para almacenar en la base de datos.
            services.AddTransient<IStoreFiles, StoreLocalFiles>();

            services.AddHttpContextAccessor();



            //Implementando IHostedService, para ejecutar codigo recurrente o continuo.
            //Debe crearse el wwwroot
            //services.AddHostedService<ServiceContinue>();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            //builder.Services.AddEndpointsApiExplorer();
            
            services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();



            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApiTest", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "WebApiTest", Version = "v2" });


                // lcano-07.02 Configurando el swagger para que envie el JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name ="Authorization",
                    Type=SecuritySchemeType.ApiKey,
                    Scheme ="Bearer",
                    BearerFormat="JWT",
                    In= ParameterLocation.Header
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id ="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });

            });


            //Habilitando AutoMapper
            services.AddAutoMapper(typeof(Startup));





            //Habilita el servicio de Claims en el usuario.
            services.AddAuthorization(options =>
            {
                options.AddPolicy("IsAdmin", policy => policy.RequireClaim("isAdmin"));
                options.AddPolicy("IsSeller", policy => policy.RequireClaim("isSeller"));
            });


            //Configurando politica de CORS
            //Solo es relevante para aplicciones que se ejecutan desde el navegador.
            services.AddCors(opcions =>
            {
                opcions.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("").AllowAnyMethod().AllowAnyHeader();
                });
            });


            //Habilita el servicio para encriptar
            services.AddDataProtection();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {





            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Para tener habilitado Swagger en produccion solo sacar de la regla que sea de desarrollo.
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApiTest v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "WebApiTest v2");
                });
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            //permite habilitar el uso de politicas CORS
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }

}

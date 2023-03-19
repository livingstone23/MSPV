using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PVM.Services.Security.DbContexts;
using PVM.Services.Security.Services.ActionService;
using PVM.Services.Security.Utility;
using System.Text;
using System.Text.Json.Serialization;
using PVM.Services.Security.Model;

namespace PVM.Services.Security
{
    public class Startup
    {

        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public void ConfigurationServices(IServiceCollection services)
        {


            services.AddControllers(opciones =>
            {
                //Para agregar el filtro de excepcion a modo global.
                //opciones.Filters.Add(typeof(MyFilterException));

                //Opcion que permite implementar control de version en las apis
                opciones.Conventions.Add(new SwaggerGroupByVersion());

            }).AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



            //Conexion a la DB
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection")
                ));

            //lcano - 07.02 en la configuracion del Identity, para que se reconozca el servicio y trabajar con roles
            services.AddIdentity<PolicyUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();





            //Seccion para utilizar las variables definidas en el appsettings.json
            //Esto permite luego utilizar en los controladores necesarios
            var appSettingsSection = _configuration.GetSection("APISettings");
            services.Configure<APISettings>(appSettingsSection);


            //Obtenemos la key para la lectura de la llave
            var apiSettings = appSettingsSection.Get<APISettings>();
            var key = Encoding.ASCII.GetBytes(apiSettings.SecretKey);


            //Habilitando AutoMapper
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IActionService, ActionService>();

            

            //Seccion para Add Autehntication to the API
            services.AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidAudience = apiSettings.ValidAudience,
                        ValidIssuer = apiSettings.ValidIssuer,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "mango");
                });
            });



            services.AddRouting(option => option.LowercaseUrls = true);
            //.Services.AddControllers();


            services.AddHttpContextAccessor();


            services.AddEndpointsApiExplorer();



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PVM.Service.Security", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "PVM.Service.Security", Version = "v2" });

                // lcano-07.02 Configurando el swagger para que envie el JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Please Bearer and then token in the field",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"

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
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(cors => cors
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Para tener habilitado Swagger en produccion solo sacar de la regla que sea de desarrollo.
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PVM.Service.Security v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "PVM.Service.Security v2");
                });
            }


            app.UseHttpsRedirection();


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

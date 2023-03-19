using System.Data;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PVM.Service.Bills.Interface;
using PVM.Service.Bills.Repository;
using PVM.Service.Notifications.DbContexts;
using PVM.Service.Notifications.Services.GeneralOfficeService;
using PVM.Service.Notifications.Services.GeneralOfficeUserService;
using PVM.Service.Notifications.Services.GeneralService;
using PVM.Service.Notifications.Services.GeneralSubservice;
using PVM.Service.Notifications.Utility;

namespace PVM.Service.Notifications
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



            ////lcano - 07.02 en la configuracion del Identity, para que se reconozca el servicio y trabajar con roles
            //services.AddIdentity<PolicyUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();

            //Conexion de la DB
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                _configuration.GetConnectionString("DefaultConnection1")
            ));



            //Seccion para utilizar las variables definidas en el appsettings.json
            //Esto permite luego utilizar en los controladores necesarios
            var appSettingsSection = _configuration.GetSection("APISettings");
            services.Configure<APISettings>(appSettingsSection);


            //Obtenemos la key para la lectura de la llave
            var apiSettings = appSettingsSection.Get<APISettings>();
            var key = Encoding.ASCII.GetBytes(apiSettings.SecretKey);

            //Habilitando AutoMapper
            services.AddAutoMapper(typeof(Startup));

            //Leemos la cadena de conexion
            string dbConnectionString = _configuration.GetConnectionString("DefaultConnection");
            
            //Pasamos la cadena para habilitar la conexion
            services.AddSingleton<IDbConnection>((sp) => new SqlConnection(dbConnectionString));


            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IGeneralOfficeService, GeneralOfficeService>();
            services.AddScoped<IGeneralOfficeUserService, GeneralOfficeUserService>();
            services.AddScoped<IGeneralServiceService, GeneralServiceService>();
            services.AddScoped<IGeneralSubserviceService, GeneralSubserviceService>();


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

            services.AddRouting(option => option.LowercaseUrls = true);


            services.AddHttpContextAccessor();


            services.AddEndpointsApiExplorer();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PVM.Service.Notifications", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "PVM.Service.Notifications", Version = "v2" });


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
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PVM.Service.Notifications v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "PVM.Service.Notifications v2");
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

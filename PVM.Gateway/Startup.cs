using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using PVM.Gateway.Utility;

namespace PVM.Gateway
{


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



            //Esto permite luego utilizar en los controladores necesarios
            var appSettingsSection = _configuration.GetSection("APISettings");
            services.Configure<APISettings>(appSettingsSection);


            //Obtenemos la key para la lectura de la llave
            var apiSettings = appSettingsSection.Get<APISettings>();
            var key = Encoding.ASCII.GetBytes(apiSettings.SecretKey);


            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            services.AddOcelot();


            //.Services.AddControllers();
            services.AddControllers(opciones =>
            {
                //Para agregar el filtro de excepcion a modo global.
                //opciones.Filters.Add(typeof(MyFilterException));

                ////Opcion que permite implementar control de version en las apis
                //opciones.Conventions.Add(new SwaggerGroupByVersion());

            }).AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);



            services.AddHttpContextAccessor();

            
            services.AddEndpointsApiExplorer();


            services.AddSwaggerGen();


        }


        public  async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
                app.UseSwaggerUI();
            }



            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthentication();

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            await app.UseOcelot();


        }


    }

}

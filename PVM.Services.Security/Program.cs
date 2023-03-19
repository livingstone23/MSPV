using PVM.Services.Security;


var builder = WebApplication.CreateBuilder(args);


//lcano-04- Instanciamos la clase
var startup = new Startup(builder.Configuration);
startup.ConfigurationServices(builder.Services);


var app = builder.Build();


#region Comentado



// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//Conexion a la DB
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

//Registro de servicios
//builder.Services.AddScoped<IAuthService, AuthService>();
//builder.Services.AddScoped<IPolicyUserService, PolicyUserService>();
//builder.Services.AddScoped<IPermissionRoleService, PermissionRoleService>();

//var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
//optionBuilder.UseSqlServer(connectionString);


//Vid115-1 Add Authentication Middleware
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
//            ValidateIssuer = false,
//            ValidateAudience = false
//        };
//    });

//builder.Services.AddHttpContextAccessor();


// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    //app.UseSwagger();
//    app.UseSwaggerUI();

//}
//else
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseSwagger();

//app.UseHttpsRedirection();


//app.UseStaticFiles();

//app.UseRouting();

//Vid115-2
//app.UseAuthentication();
//app.UseAuthorization();

//app.MapRazorPages();
//app.MapControllers();
//app.MapFallbackToFile("index.html");


#endregion


startup.Configure(app, app.Environment);

app.Run();

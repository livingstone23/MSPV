using PVM.Gateway;

var builder = WebApplication.CreateBuilder(args);


//lcano-04- Instanciamos la clase
var startup = new Startup(builder.Configuration);
startup.ConfigurationServices(builder.Services);


// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

startup.Configure(app, app.Environment);

app.Run();

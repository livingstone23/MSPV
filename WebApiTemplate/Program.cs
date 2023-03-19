using WebApiTemplate;

var builder = WebApplication.CreateBuilder(args);


//lcano-04- Instanciamos la clase
var startup = new Startup(builder.Configuration);
startup.ConfigurationServices(builder.Services);




//lcano-02- Movemos los servicios al metodo ConfigurationServices en clase startup
//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

//lcano-03- Movemos los servicios al metodo Configure en clase startup
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();

//lcano-05- Brindamos las variables a la clase startup
startup.Configure(app, app.Environment);

app.Run();

using FilterDemoApi.Filters;
using FilterDemoApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    
    options.Filters.Add<CustomExceptionFilter>();
});

builder.Services.AddScoped<CustomActionFilter>(); // used via [ServiceFilter] on controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseRequestLogging();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

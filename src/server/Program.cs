using RCloud.DataAccess;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddSwaggerGen();
services.AddControllers();
services.AddScoped<UserDbContext>();

ApiExtensions.AddApiCors(services, configuration);
ApiExtensions.AddApiAuthentication(services, configuration);

var app = builder.Build();

using var scope = app.Services.CreateScope();


var dbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();
await dbContext.Database.EnsureCreatedAsync();


app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();


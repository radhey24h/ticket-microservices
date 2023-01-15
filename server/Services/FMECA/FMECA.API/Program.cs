
using FMECA.Application;
using FMECA.Infrastructure;
using FMECA.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
var app = builder.Build();
//var context = app.Services.GetRequiredService<FMECAContext>();
//context.Database.Migrate();
//var context = app.Services.GetRequiredService<FMECAContext>();
//context.Database.GetRequiredService<OrderContext>((context, services) =>
// {
//     var logger = services.GetService<ILogger<OrderContextSeed>>();
//     OrderContextSeed
//         .SeedAsync(context, logger)
//         .Wait();
// })
var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<FMECAContext>();
// void SeedDatabase()
//{
//    using (var scope = app.Services.CreateScope())
//        try
//        {
//            var scopedContext = scope.ServiceProvider.GetRequiredService<FMECAContext>();
//            Seeder.Initialize(scopedContext);
//        }
//        catch
//        {
//            throw;
//        }
//}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OrderService.Data;
using OrderService.Repository;
using OrderService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrderDbContext>
    (options => options.UseSqlite(builder.Configuration.GetConnectionString("OrderDb")));
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService.Service.OrderService>();

builder.Services.AddControllers()
.AddJsonOptions(options =>
{
options.JsonSerializerOptions.ReferenceHandler =
System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
var app = builder.Build();

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

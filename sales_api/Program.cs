using sales_api.Interfaces.Articles;
using sales_api.Interfaces.Sales;
using sales_api.Services.Articles;
using sales_api.Services.Sales;
using sales_dll.Data;
using sales_dll.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Services
builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.AddTransient<IArticlesService, ArticlesService>();
builder.Services.AddTransient<ISalesService, SalesService>();

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

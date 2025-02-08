using RealHouzing.BusinessLayer.Abstract;
using RealHouzing.BusinessLayer.Concrete;
using RealHouzing.DataAccessLayer.Abstract;
using RealHouzing.DataAccessLayer.Concrete;
using RealHouzing.DataAccessLayer.Entity_Framewrok;
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<Context>();//Db eriþimi için!
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductDal,EfProductDal>();
builder.Services.AddScoped<IProductService,ProductManager>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

using App.Api.Utils;
using App.Service.SeedWork;
using Domain.Model.Addresses;
using Domain.Model.Orders;
using Domain.Model.Products;
using Domain.Model.ProductsOrdes;
using Domain.Model.Usuarios;
using Infra.DataAccess.Addresses;
using Infra.DataAccess.Context;
using Infra.DataAccess.Orders;
using Infra.DataAccess.Products;
using Infra.DataAccess.ProductsOrders;
using Infra.DataAccess.Usuarios;

var builder = WebApplication.CreateBuilder(args);

//******************* Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Messages>();

builder.Services.AddTransient<IDatabaseContext, DatabaseContext>();
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IProductOrderRepository, ProductOrderRepository>();

builder.Services.AddHandlers();


//****************** Configure the HTTP request pipeline.
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

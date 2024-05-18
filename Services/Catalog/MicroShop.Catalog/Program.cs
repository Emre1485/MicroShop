using MicroShop.Catalog.Services.CategoryServices;
using MicroShop.Catalog.Services.ProductDetailDetailServices;
using MicroShop.Catalog.Services.ProductDetailServices;
using MicroShop.Catalog.Services.ProductImageServices;
using MicroShop.Catalog.Services.ProductServices;
using MicroShop.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceCatalog";
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});
//builder.Services.AddScoped<IDatabaseSettings>(sp =>
//{
//    return new DatabaseSettings
//    {
//        CategoryCollectionName = builder.Configuration["DatabaseSettings:CategoryCollectionName"],
//        ProductCollectionName = builder.Configuration["DatabaseSettings:ProductCollectionName"],
//        ProductDetailCollectionName = builder.Configuration["DatabaseSettings:ProductDetailCollectionName"],
//        ProductImageCollectionName = builder.Configuration["DatabaseSettings:ProductImageCollectionName"],
//        ConnectionString = builder.Configuration["DatabaseSettings:ConnectionString"],
//        DatabaseName = builder.Configuration["DatabaseSettings:DatabaseName"]
//    };
//});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

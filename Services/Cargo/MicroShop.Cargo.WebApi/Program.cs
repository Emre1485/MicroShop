using MicroShop.Cargo.BusinessLayer.Abstract;
using MicroShop.Cargo.BusinessLayer.Concrete;
using MicroShop.Cargo.DataAccessLayer.Abstract;
using MicroShop.Cargo.DataAccessLayer.Concrete;
using MicroShop.Cargo.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.RequireHttpsMetadata = false;
    opt.Audience = "ResourceCargo";
});

builder.Services.AddDbContext<CargoContext>();


builder.Services.AddScoped<ICargoCompanyDal, EFCargoCompanyDal>();
builder.Services.AddScoped<ICargoCustomerDal, EFCargoCustomerDal>();
builder.Services.AddScoped<ICargoDetailDal, EFCargoDetailDal>();
builder.Services.AddScoped<ICargoProgressDal, EFCargoProgressDal>();

// Business Layer registrations
builder.Services.AddScoped<ICargoCompanyService, CargoCompanyManager>();
builder.Services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoProgressService, CargoProgressManager>();




builder.Services.AddControllers();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

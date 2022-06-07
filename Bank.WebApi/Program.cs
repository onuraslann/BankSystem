using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bank.Core.BaseRepository.Abstract;
using Bank.DataAccess.EntityFramework.Context;
using Bank.DataAccess.EntityFramework.Repository;
using Bank.DataAccess.UnitOfWork;
using Bank.Service.ApplicationServices.Abstract;
using Bank.Service.ApplicationServices.Concrete;
using Bank.Service.BaseService;
using Bank.Service.DependenyRegistryModule.Autofac;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModule());
    });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<BankContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"), sqlOptions =>
    {

        sqlOptions.MigrationsAssembly("Bank.DataAccess"); // Dbcontextin hangi katmanda oldugunu belirt
    
    }); //=> veritabaný yolu ver 
});

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

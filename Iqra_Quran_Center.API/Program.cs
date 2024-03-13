using Iqra_Quran_Center.API.DI_Container;
using Iqra_Quran_Center.Application.DI_Container;
using Iqra_Quran_Center.Infratstructure.DI_Container;
using Iqra_Quran_Center.Persistence.DI_Container;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersisitenceServices(builder.Configuration)
    .AddApplicationServices(builder.Environment.WebRootPath)
    .AddApiServices(builder.Configuration)
    .AddInfraStructureServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

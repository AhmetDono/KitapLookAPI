using KitapLookAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repositories.EfCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; // Döngüsel referanslarý kaldýr
        options.SerializerSettings.MaxDepth = 64; // Derinlik sýnýrýný arttýr
        options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented; // JSON çýktýsýný okunabilir yap
    })
    .AddApplicationPart(typeof(Presentation.AssemblyReferance).Assembly);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.ConfigurationRepositoryManager();
builder.Services.ConfigureServiceManager();

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

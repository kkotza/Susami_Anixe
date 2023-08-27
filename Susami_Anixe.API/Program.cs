using Susami_Anixe.Core.DataAccess;
using Susami_Anixe.Core.Services.Interfaces;
using Susami_Anixe.Core.Services;
using Susami_Anixe.Core.Repositories.Interfaces;
using Susami_Anixe.Core.Repositories;
using Susami_Anixe.Core.Model.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<AnixeDbContext>();

var directoryName = System.IO.Directory.GetCurrentDirectory();
var dataSource = $"Data Source={directoryName}//Anixe.sqlite";

builder.Services.AddDbContext<AnixeDbContext>(
                            options => { options.UseSqlite(dataSource); });

//builder.Services.AddDbContext<AnixeDbContext>(options => options.UseSqlite(//"Data Source=InMemoryTest;Mode=Memory;Cache=Shared"));

builder.Services.AddAutoMapper(typeof(AppMapperProfile));

builder.Services.AddTransient<IHotelService, HotelService>();
builder.Services.AddTransient<IBookingService, BookingService>();
builder.Services.AddTransient<IHotelRepository, HotelRepository>();
builder.Services.AddTransient<IBookingRepository, BookingRepository>();


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

//using (var scope = app.Services.CreateScope())
//{
//    var db = scope.ServiceProvider.GetRequiredService<AnixeDbContext>();
    
//    var sql = db.Database.GenerateCreateScript();
    
    
//    db.Database.EnsureCreated();    
//    db.Database.Migrate();
    
//}

app.Run();
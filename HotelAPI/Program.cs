using Susami_Anixe.Core.DataAccess;
using Susami_Anixe.Core.Services.Interfaces;
using Susami_Anixe.Core.Services;
using Susami_Anixe.Core.Repositories.Interfaces;
using Susami_Anixe.Core.Repositories;
using Susami_Anixe.Core.Model.Dto;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AnixeDbContext>();

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

app.Run();

using FoodToOrder_Backend;
using FoodToOrder_Backend.Repositories;
using FoodToOrder_Backend.Services;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();

builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDbContext<FoodToOrderAppContext>(opt =>
{
    Console.WriteLine("running service");
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.MaxDepth = 0;
});

JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
{
    PreserveReferencesHandling = PreserveReferencesHandling.None,
    Formatting = Formatting.Indented
};

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

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

app.UseCors("corsapp");

app.Run();

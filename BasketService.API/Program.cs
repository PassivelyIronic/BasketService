using BasketService.Application.Commands.CreateBasket;
using BasketService.Infrastructure.Persistance;
using BasketService.Infrastructure.ProductService;

var builder = WebApplication.CreateBuilder(args);

// Dodaj kontrolery
builder.Services.AddControllers();

// Dodaj Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CQRS – MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBasketCommand).Assembly));

// Infrastruktura i aplikacja
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddScoped<IBasketRepository, MongoBasketRepository>();
builder.Services.AddScoped<IProductServiceClient, HttpProductServiceClient>();


// HttpClient do serwisu produktowego
builder.Services.AddHttpClient<ProductServiceClient, ProductServiceClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration["ProductService:BaseUrl"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseRouting(); ?

app.UseAuthorization();

app.MapControllers();

app.Run();

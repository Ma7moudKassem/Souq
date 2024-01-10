using BuildingBlocks.EventBus;

var builder = WebApplication.CreateBuilder(args);

BusConfig busConfig = builder.Configuration.GetSection(nameof(BusConfig)).Get<BusConfig>()
    ?? throw new ArgumentNullException(nameof(busConfig));

builder.Services.RegisterMasstTansitServices(busConfig);

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

app.UseAuthorization();

app.MapControllers();

app.Run();

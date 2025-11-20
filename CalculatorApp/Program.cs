using CalculatorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register your Calculator Service (Interface + Implementation)
builder.Services.AddScoped<IAdditionService, AdditionService>();
//builder.Services.AddScoped<ISubtractionService, SubtractionService>();

// Swagger / OpenAPI settings
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

public partial class Program { }
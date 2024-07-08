using AirportDistanceCalculator.Services.Interfaces;
using AirportDistanceCalculator.Services;
using AirportDistanceCalculator.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddScoped<IAirportService, AirportService>();
builder.Services.AddHttpClient<IAirportService, AirportService>(client =>
{
    client.DefaultRequestHeaders.Add("X-Api-Key", "5a9Xvz0XcQUY5M+IM9vOhQ==4dzF4QXrTN1VBd5f");
});
// Add Swagger services using the extension method
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Airport Distance Calculator API V1");
        c.RoutePrefix = string.Empty;
    });
}
else
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

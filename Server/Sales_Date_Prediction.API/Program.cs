using Sales_Date_Prediction.Access;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("Access", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .SetIsOriginAllowed((Host) => true);
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar servicios
builder.Services.AddAccess(connectionString);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())); var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Access");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

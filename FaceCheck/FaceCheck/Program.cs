using FaceCheck.AppConfigure.ApplicationExtensions;
using FaceCheck.AppConfigure.ServicesExtensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.AddSerilogConfiguration(); //Add serilog
builder.Services.AddVersioningConfiguration(); //add api versioning
builder.Services.AddSwaggerConfiguration(); //add swagger configuration

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

try
{
    Log.Information("Application starting...");

    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}

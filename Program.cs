using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication()       
        .AddJwtBearer(options =>
        {         
            options.Audience = "https://kepungapp.auth0.com/api/v2/";
            options.Authority = "https://kepungapp.auth0.com/";          
            //options.RequireHttpsMetadata = false;
        });


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/hello", () => "hello world").RequireAuthorization();

app.Run();

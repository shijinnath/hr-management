using Microsoft.EntityFrameworkCore;
using AuthService.Data;
using AuthService.Interface.Services; 
using MediatR;
using Common.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register MediatR
builder.Services.AddMediatR(typeof(AuthService.Services.AuthService).Assembly);
 

// Register AuthService
builder.Services.AddScoped<IAuthService, AuthService.Services.AuthService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IJWTService, Common.Utilities.JwtHelper>();
builder.Services.AddTransient<Common.Utilities.JwtHelper>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var myPolicyName = "AllowAll"; // you will specify the exact same string in different places, so assigning policy names to variables avoids potential typo mistakes.
builder.Services.AddCors(p => p.AddPolicy(myPolicyName, builder =>
{
    builder.WithOrigins("http://localhost:3002").AllowAnyMethod().AllowAnyHeader();
}));
var app = builder.Build();
app.UseCors(myPolicyName);
// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();

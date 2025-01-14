
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

using Serilog;
using System.Text;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Configure authentication
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:SecretKey"]);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"]
    };
});

// Configure CORS
var myPolicyName = "AllowAll";
builder.Services.AddCors(p => p.AddPolicy(myPolicyName, builder =>
{
    builder.WithOrigins("http://localhost:3002").AllowAnyMethod().AllowAnyHeader();
}));
// Configure health checks
//builder.Services
//    .AddHealthChecks()
//    .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

// Add Ocelot
// Add Ocelot json file configuration

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration);

builder.Host.UseSerilog((context, services, loggerConfiguration) =>
{
    // Configure here Serilog instance...
    loggerConfiguration
        .MinimumLevel.Information()
        .Enrich.WithProperty("ApplicationContext", "Ocelot.APIGateway")
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .ReadFrom.Configuration(context.Configuration);
});



WebApplication app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(_ => { });

// Map health check endpoints
//app.MapHealthChecks("/hc", new HealthCheckOptions()
//{
//    Predicate = _ => true,
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse,
//});

//app.MapHealthChecks("/liveness", new HealthCheckOptions
//{
//    Predicate = r => r.Name.Contains("self")
//});
app.UseCors(myPolicyName);
await app.UseOcelot();
await app.RunAsync();
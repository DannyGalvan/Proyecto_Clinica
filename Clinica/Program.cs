using Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using FluentValidation.AspNetCore;
using System.Text;
using Entities.Models;
using Business.Interfaces;
using Business.Repository;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Obtain the environment current (Development, Production, etc.)
string environment = builder.Environment.EnvironmentName;

// Configure the ConfigurationBuilder y load the configurations del archive appsettings.json
IConfigurationRoot configuration = new ConfigurationBuilder()
                                   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                   .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true) // Load environment-specific file
                                   .AddEnvironmentVariables()
                                   .Build();

// Add services to the container.
IConfigurationSection appSettingsSection = configuration.GetSection("AppSettings");

builder.Services.Configure<AppSettings>(appSettingsSection);

builder.Services.AddMemoryCache();

builder.Services.AddDbContext<ClinicContext>(options => {
                                                     options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
                                                 });
builder.Services.AddDbContext<ClinicContextMySQL>(options =>
{
    options.UseMySql("Server=localhost;Database=ClinicTest;Uid=root;Pwd=andrea2911;", ServerVersion.Parse("8.0.32-mysql"));
});

builder.Services.AddAuthentication(d =>
                                   {
                                       d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                       d.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
                                   })
       .AddJwtBearer(d =>
                     {
                         string secret = configuration["AppSettings:Secret"]!;
                         byte[] key    = Encoding.ASCII.GetBytes(secret);
                         
                         d.RequireHttpsMetadata = false;
                         d.SaveToken            = true;
                         d.TokenValidationParameters = new TokenValidationParameters
                                                       {
                                                           ValidateIssuerSigningKey = true,
                                                           IssuerSigningKey         = new SymmetricSecurityKey(key),
                                                           ValidateIssuer           = false,
                                                           ValidateAudience         = false,
                                                       };
                     });

builder.Services.AddControllers();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// validation services fluent validations
builder.Services.AddFluentValidationClientsideAdapters();

//services injected
builder.Services.AddScoped<IMail, Mail>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

//cache stores in memory
using (var scope = app.Services.CreateScope())
{
    var dbContext    = scope.ServiceProvider.GetRequiredService<ClinicContext>();
    var catalogModules = dbContext.Modules.ToList();

    var cache = scope.ServiceProvider.GetRequiredService<IMemoryCache>();
    cache.Set("Modules", catalogModules);
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
                       name: "default",
                       pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

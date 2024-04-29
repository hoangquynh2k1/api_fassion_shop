using API_FashionShop.Entities;
using API_FashionShop.Services;
using API_FashionShop.Models;
using Microsoft.Extensions.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var config = new ConfigurationBuilder().AddJsonFile("appsettings.json")
    .Build();
// Email services
builder.Services.AddOptions();
var mailsettings = config.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailsettings);
builder.Services.AddScoped<ISendMailService,SendMailService>();
builder.Services.AddScoped<IUserService, UserService>();
//

//DB services
var connectionString = builder.Configuration.GetConnectionString("AppDBConnectionString");
builder.Services.AddDbContext<AppDBContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

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

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

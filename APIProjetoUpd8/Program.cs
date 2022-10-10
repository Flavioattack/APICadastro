using APIProjetoUpd8.Data;
using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbContext = APIProjetoUpd8.Data.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Politica",
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7091")
                          .AllowAnyHeader()
                          .AllowAnyMethod(); ;
                      });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddMvc();








builder.Services.AddDbContext<DbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));



builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCookiePolicy();
app.UseSession();
app.UseCors("Politica");


app.UseAuthorization();

app.MapControllers();

app.Run();


using APIProjetoUpd8.Data;
using FluentAssertions.Common;
using Microsoft.EntityFrameworkCore;
using DbContext = APIProjetoUpd8.Data.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers().AddNewtonsoftJson();



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


app.UseAuthorization();

app.MapControllers();

app.Run();


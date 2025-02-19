using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();
string connection = Environment.GetEnvironmentVariable("SQLite_SRC");
builder.Services.AddDbContext<GraphDbContext>(options =>
    options.UseSqlite(connection));
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<AppUser>()
    .AddEntityFrameworkStores<GraphDbContext>();
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("app-policy", policy =>
    {
        policy
            .WithOrigins("http://localhost:63342")
            .AllowCredentials()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapIdentityApi<AppUser>();
app.UseCors("app-policy");
app.UseAuthorization();
app.MapControllers();
app.Run();
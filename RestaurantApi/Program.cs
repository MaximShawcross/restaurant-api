using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RestoranApi.Models;
using RestoranApi.Services;
using RestoranApi.Services.Interfaces;
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddCors(options =>
// { // MyAllowSpecificOrigins
//     options.AddPolicy(name: MyAllowSpecificOrigins,
//         policy  =>
//         {
//             policy.WithOrigins("http://localhost:3000", "http://127.0.0.1:5500/", "http://127.0.0.1:3000");
//         });
// });

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddDbContext<RestaurantContext>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DB")));
builder.Services.AddCors(options => options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    })
);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
    
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
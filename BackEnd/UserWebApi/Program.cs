using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;
using CourseApplicationWithWebApi.Service;
using CourseApplicationWithWebApi.Context;
using CourseApplicationWithWebApi.Repository;






var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenGenerator,TokenGenerator>();
builder.Services.AddCors();
string localSQLConnectonString = builder.Configuration.GetConnectionString("LocaldatabaseConnection");
builder.Services.AddDbContext<UserDbContext>(p => p.UseSqlServer(localSQLConnectonString));
validateTokenWithParameters(builder.Services, builder.Configuration);
void validateTokenWithParameters(IServiceCollection services, IConfiguration configuration)
{
    var userSecretKey = configuration["JwtValidationParameters:UserSecretKey"];
    var userIssuer = configuration["JwtValidationParameters:UserIssuer"];
    var userAudience = configuration["JwtValidationParameters:UserAudience"];
    var userSecretKeyInBytes = Encoding.UTF8.GetBytes(userSecretKey);
    var userSymmetricSecurityKey = new SymmetricSecurityKey(userSecretKeyInBytes);
    var tokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = userIssuer,

        ValidateAudience = true,
        ValidAudience = userAudience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = userSymmetricSecurityKey,

        ValidateLifetime = true,
    };
    services.AddAuthentication(u =>
    {
        u.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        u.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(u => u.TokenValidationParameters = tokenValidationParameters);
}
        



    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
    
     app.UseStaticFiles();
//    app.Use(async (context, next) =>
//   {
//    var tokenInfo = context.Session.GetString("UserToken");
//    context.Request.Headers.Add("Authorization", "Bearer " + tokenInfo);
//    await next();
//});



app.UseHttpsRedirection();        
    app.UseAuthorization();
    app.UseAuthentication();

app.MapControllers();

    app.Run();

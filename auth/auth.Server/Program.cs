using auth.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlTypes;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddGrpc();

builder.Services.AddAuthorization(option => option.AddPolicy(JwtBearerDefaults.AuthenticationScheme, builder =>
{

    builder.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
    builder.RequireClaim(ClaimTypes.Name);
    
}));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidAudience = "client",
                    ValidIssuer = "server",
                    ValidateLifetime = true,
                    IssuerSigningKey = symmetricSecurityKey
                });

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGet("/login", (context) =>
{
    return context.Response.WriteAsync(generateJwtToken(context.Request.Query["name"]!));
});

string generateJwtToken(string name)
{
    ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
    var claims = new[]
    {
        new Claim(ClaimTypes.Name, name),
        new Claim(ClaimTypes.Role, "Admin"),
        new Claim(JwtRegisteredClaimNames.Name, name)
    };
    var credential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
         issuer: "server",
         audience: "client",
         claims: claims,
         notBefore: DateTime.Now,
         expires: DateTime.Now.AddDays(1),
         signingCredentials: credential

        );

    return jwtSecurityTokenHandler.WriteToken(token);
}

app.Run();


public partial class Program
{
    private static readonly SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("burada-256-bitlik-gizli-bir-ifade-var"));
    private static readonly JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
}
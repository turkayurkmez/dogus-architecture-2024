using Microsoft.AspNetCore.Authentication.BearerToken;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddReverseProxy()
                .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddAuthentication(BearerTokenDefaults.AuthenticationScheme).AddBearerToken();
builder.Services.AddAuthorization(option => option.AddPolicy("product-api", builder => builder.RequireClaim(JwtRegisteredClaimNames.Name)
));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapReverseProxy();

app.MapGet("/login", () =>
{
    return Results.SignIn(new ClaimsPrincipal(
        new ClaimsIdentity(
            [
              new Claim(JwtRegisteredClaimNames.Name,"client")
            ], BearerTokenDefaults.AuthenticationScheme)
        ), authenticationScheme: BearerTokenDefaults.AuthenticationScheme);
});


app.Run();


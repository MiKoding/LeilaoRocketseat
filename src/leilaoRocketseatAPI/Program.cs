using leilaoRocketseatAPI.Contracts;
using leilaoRocketseatAPI.Filters;
using leilaoRocketseatAPI.Repositories;
using leilaoRocketseatAPI.Repositories.DataAccess;
using leilaoRocketseatAPI.Services;
using leilaoRocketseatAPI.UseCases.Leiloes.getCurrent;
using leilaoRocketseatAPI.UseCases.Offers.CreateOffer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.
                        Enter 'Bearer' [space] and then your token in the text input below.
                        Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
               new List<string>()
        }
    }); 
});

builder.Services.AddScoped<AuthenticationUserAttribute>();
builder.Services.AddScoped<ILoggedUser,LoggedUser>();
builder.Services.AddScoped<CreateOfferUseCase>();
builder.Services.AddScoped<GetCurrentAuctionUseCase>();
builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();//quando alguem solicitar a interface(IAuctionRepository) ele devolve a implementação AuctionRepository
builder.Services.AddScoped<IOfferRepository, OfferRepository>(); 
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddDbContext<RocketseatAuctionDbContext>(options => {
    options.UseSqlite(@"Data Source=C:\\Users\\Mikaio Yamada\\source\\repos\\LeilaoRocketseat\\DB\\leilaoDbNLW.db");
});

builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

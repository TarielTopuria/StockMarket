using api.Data;
using api.Models;
using api.Repositories.Implementations;
using api.Repositories.Interfaces;
using api.Services.Implementations;
using api.Services.Interfaces;
using api.UOW.Implementations;
using api.UOW.Interfaces;
using api.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Stock Market API",
        Description = "An ASP.NET Core Web API for managing Stock Market Actions"
    });
});

builder.Services.AddControllers()
.AddNewtonsoftJson(op =>
{
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddDbContext<AppDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Configuring Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(op =>
{
    op.Password.RequireDigit = true;
    op.Password.RequireLowercase = true;
    op.Password.RequireUppercase = true;
    op.Password.RequireNonAlphanumeric = true;
    op.Password.RequiredLength = 8;
})
    .AddEntityFrameworkStores<AppDbContext>();

//Configuring JWT
builder.Services.AddAuthentication(op =>
{
    op.DefaultAuthenticateScheme =
    op.DefaultChallengeScheme =
    op.DefaultForbidScheme =
    op.DefaultScheme =
    op.DefaultSignInScheme =
    op.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(op => {
        op.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["JWT:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey
            (
                System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]
            ))
        };
});

// Registring Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IStockRepository, StockRepository>();

// Registring Services
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IAccountService, AccountService>();

// Registring Helper library services
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddValidatorsFromAssemblyContaining<IdValidator>();

// Registring Unit Of Work
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

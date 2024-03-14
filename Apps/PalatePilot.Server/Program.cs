using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PalatePilot.Server.Configs;
using PalatePilot.Server.Data;
using PalatePilot.Server.ExceptionHandlers;
using PalatePilot.Server.Services;
using PalatePilot.Server.Services.EmailService;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add Configuration file secret.json
builder.Configuration.AddJsonFile("secret.json", optional: false, reloadOnChange: false);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Custom registration of services
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection(nameof(EmailConfig)));

builder.Services.AddDbContext<AuthDbContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configure identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt => 
{   
    // Configure username requirements
    opt.User.RequireUniqueEmail = true;
    opt.SignIn.RequireConfirmedEmail = true;

    // Set password requirements     
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = true;
    opt.Password.RequireUppercase = true;
    opt.Password.RequireLowercase = true;
    opt.Password.RequireNonAlphanumeric = true;
})
    // Connect AuthDbContext to identity service
    .AddEntityFrameworkStores<AuthDbContext>()
    
    // Add built-in token providers
    .AddDefaultTokenProviders();

// Configure lifetime of reset password token
builder.Services.Configure<DataProtectionTokenProviderOptions>(opt =>
opt.TokenLifespan = TimeSpan.FromHours(1));


// Setup JWT Authentication 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    // Expect jwt token in the header
    .AddJwtBearer(options => 
    {
        // set up the necessary validations to ensure the token is valid,
        options.TokenValidationParameters = new TokenValidationParameters 
        {
            // Validate the issuer, audience, lifetime, and signing key
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            // Set the valid issuer, audience, and signing key
            ValidIssuer = builder.Configuration["JwtConfig:Issuer"],
            ValidAudience = builder.Configuration["JwtConfig:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes( builder.Configuration["JwtConfig:SecretKey"]))
        };
    });

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();

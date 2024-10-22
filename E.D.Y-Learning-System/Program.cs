using E.D.Y_Serivce.Implementations;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter the JWT token obtained from the login endpoint",
        Name = "Authorization"
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
                            }
                        },
                        Array.Empty<string>()
                    }
                });
});
builder.Services.AddScoped<IAchivementService, AchivementService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ILessonService, LessonService>();
builder.Services.AddScoped<IUserCourseService, UserCourseService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddAutoMapper(typeof(MappingSetting));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var user = context.User;
            var roleClaim = user.FindFirst("Role");
            if (roleClaim != null && roleClaim.Value == "Admin")
            {
                return true;
            }
            return false;
        });
    });
    options.AddPolicy("Staff", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var user = context.User;
            var roleClaim = user.FindFirst("Role");
            if (roleClaim != null && (roleClaim.Value == "Staff"))
            {
                return true;
            }
            return false;
        });
    });
    options.AddPolicy("Student", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var user = context.User;
            var roleClaim = user.FindFirst("Role");
            if (roleClaim != null && (roleClaim.Value == "Student"))
            {
                return true;
            }
            return false;
        });
    });
    options.AddPolicy("Lecture", policy =>
    {
        policy.RequireAssertion(context =>
        {
            var user = context.User;
            var roleClaim = user.FindFirst("Role");
            if (roleClaim != null && (roleClaim.Value == "Lecture"))
            {
                return true;
            }
            return false;
        });
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
            .AllowAnyOrigin() // or specify allowed origins, e.g., .WithOrigins("https://example.com")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddAuthentication(item =>
{
    item.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    item.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(item =>
{
    item.RequireHttpsMetadata = true;
    item.SaveToken = true;
    item.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("c2VydmVwZXJmZWN0bHljaGVlc2VxdWlja2NvYWNoY29sbGVjdHNsb3Bld2lzZWNhbWU=")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

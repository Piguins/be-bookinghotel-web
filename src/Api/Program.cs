using Api.Exception;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


{
    // Add services to the container.
    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);

    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();
    builder.Services.AddAutoMapper(typeof(Program).Assembly, ApplicationAssembly.Assembly);

    builder
        .Host
        .UseSerilog(
            (context, configuration) => configuration.ReadFrom.Configuration(context.Configuration)
        );
    builder
        .Services
        .AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );
        });
    builder
        .Services
        .AddSwaggerGen(option =>
        {
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Bearer JWT Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement {
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
            }});
        });
}

var app = builder.Build();


{
    // Configure the HTTP request pipeline.
    app.Logger.LogInformation("Using Environment: {Environment}", app.Environment.EnvironmentName);
    app.Logger.LogInformation(
        "Running on Port: {Port}",
        app.Environment.IsDevelopment() ? 5000 : 8080
    );

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SE310-BackEnd v1"));

    app.UseCors();
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/errors");
    app.UseSerilogRequestLogging();

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    await app.UseSeedDataAsync().ConfigureAwait(false);

    app.Run();
}

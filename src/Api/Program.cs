using Api.Exception;
using Api.Commons;
using Application;
using Infrastructure;
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
}

var app = builder.Build();

{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.Logger.LogInformation("Using Environment: {Environment}", app.Environment.EnvironmentName);
    app.Logger.LogInformation("Running on Port: {Port}", 5000);

    app.UseHttpsRedirection();
    app.UseExceptionHandler("/errors");
    app.UseSerilogRequestLogging();

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}

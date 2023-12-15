using Api.Exception;
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
    builder
        .Services
        .AddCors(options =>
        {
            options.AddDefaultPolicy(
                policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            );
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
    app.Logger.LogInformation("----Created a default user with \"Host\" and \"Guest\" Role");
    app.Logger.LogInformation("----Email: {Email}", "host@host.host");
    app.Logger.LogInformation("----FirstName: {FirstName}", "Host");
    app.Logger.LogInformation("----LastName: {LastName}", "Host");
    app.Logger.LogInformation("----Password: {Password}", "host");

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors();
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/errors");
    app.UseSerilogRequestLogging();

    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}

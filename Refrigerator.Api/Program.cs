using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Refrigerator.Api.Domain.Configurations;
using Refrigerator.Api.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Configuration.AddJsonFile("connectionstrings.json", optional: false, reloadOnChange: true);
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();
ConfigureAppMiddlewares(app);
app.Run();

static void ConfigureServices(IServiceCollection services, IConfiguration configuration) 
{
    var connStringsSection = configuration.GetSection(nameof(ConnectionStrings));
    services.Configure<ConnectionStrings>(connStringsSection);

    services.AddAutoMapper(Register.GetAutoMapperProfiles());
    services.AddFluentValidationAutoValidation();
    services.AddFluentValidationClientsideAdapters();
    services.AddHttpContextAccessor();
    services.AddSwaggerGen(c => 
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Refrigerator.Api", Version = "v1" });
        var xmlPath = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
        c.IncludeXmlComments(xmlPath);
    });

    Register.ConfigureServiceLayer(services, configuration);
    services.AddCors(options =>
    {
        options.AddPolicy(name: "DefaultCors",
                          builder =>
                          {
                              builder
                              .AllowAnyOrigin() // Also, We can use .WithOrigins() for specifying allowed origins
                              .AllowAnyMethod() // Also, We can use .WithMethod() for defining allowed Http methods
                              .AllowAnyHeader();
                          });
    });
}

static void ConfigureAppMiddlewares(WebApplication app)
{
    if (app.Environment.IsDevelopment())
        app.UseDeveloperExceptionPage();
    else
        app.UseExceptionHandler("/Error");

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("v1/swagger.json", "Refrigerator API");
        c.DocumentTitle = "Fridge API";
        c.DocExpansion(DocExpansion.List);
        c.DefaultModelsExpandDepth(-1);
    });
    app.UseHttpsRedirection();
    app.UseCors("DefaultCors");
    app.UseRouting();
    app.MapControllers();
}

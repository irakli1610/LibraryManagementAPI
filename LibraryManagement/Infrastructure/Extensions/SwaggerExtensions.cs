using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

namespace LibraryManagement.API.Infrastructure.Extensions;

public static class SwaggerExtensions
{
    public static void AddSwaggerGenExtension(this IServiceCollection services)
    {

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Library Management API v1",
                Version = "v1",
                Description = "Library Management API with global exception handling, versioning, and fluent validation.",
                Contact = new OpenApiContact
                {
                    Name = "LibratyManagementAPI",
                    Email = "LibraryManagerAdmin@gmail.com",
                    Url = new Uri("https://SomeRandomUrl/RandomPath"),
                },
                
            });
            
            options.SwaggerDoc("v2", new OpenApiInfo
            {
                Title = "Library Management API v2",
                Version = "v2",
                Description = "Library management API v2 with global exception handling, versioning, and fluent validation.",
                Contact = new OpenApiContact
                {
                    Name = "LibraryManagementAPI",
                    Email = "LibraryManagerAdmin@gmail.com",
                    Url = new Uri("https://SomeRandomUrl/RandomPath"),
                },
            });


            options.EnableAnnotations();

            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            if (File.Exists(xmlPath))
            {
                options.IncludeXmlComments(xmlPath);
                options.ExampleFilters();
                
            }
            

        });
    }
}

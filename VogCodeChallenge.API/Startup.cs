using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using System;
using System.IO;
using System.Reflection;
using VogCodeChallenge.API.Extensions;
using VogCodeChallenge.API.SwaggerAttributes;
using VogCodeChallenge.BLL;
using VogCodeChallenge.BLL.Config;
using VogCodeChallenge.BLL.Interfaces;
using VogCodeChallenge.BLL.Services;

namespace VogCodeChallenge.API
{
    public class Startup
    {
        private static Version versionNumber;

        public static void Configure(IConfiguration configuration, IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.ConfigureExceptionHandler(logger);
            app.UseHttpsRedirection();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v{versionNumber.Major}/swagger.json", $"VogCodeChallenge.API Version {versionNumber.Major}");
                c.RoutePrefix = "swagger";
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private readonly ILogger<Startup> logger;

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment env,
            ILogger<Startup> logger)
        {
            this.logger = logger;
            this.Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            this.Configuration = builder.Build();

            versionNumber = new Version(configuration.GetSection("DeployVersion").Value);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            this.logger.LogDebug($"Begin ConfigureServices");

            services.AddMvc()
                 .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                 .ConfigureApiBehaviorOptions(options => options.SuppressMapClientErrors = true);
            services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.Converters.Add(new StringEnumConverter());
            })
            .AddFluentValidation();

            services.AddMemoryCache();
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConfiguration(this.Configuration.GetSection("VogCodeChallenge:Logging"));
                loggingBuilder.AddLog4Net();
                loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Debug);
            });

            var apiEnvironment = this.GetEnvironment();
            var version = this.BuildSwaggerVersionString(apiEnvironment);

            Boolean enableDBConnectivity;
            Boolean.TryParse(this.Configuration.GetSection("EnableDBConnectivity").Value, out enableDBConnectivity);

            services.AddSingleton<IVogCodeChallengeConfig>(
                new VogCodeChallengeConfig(enableDBConnectivity));

            services.AddOptions();

            services.AddHttpContextAccessor();

            services.AddTransient<IEmployeeDataServiceFactory, EmployeeDataServiceFactory>();
            services.AddTransient<IVogCodeChallengeAPIHandler, VogCodeChallengeAPIHandler>();
            services.AddHttpClient();
            services.AddSwaggerGen(c =>
            {
                var info = new OpenApiInfo()
                {
                    Title = "VogCodeChallenge Employee API ",
                    Description = "VogCodeChallenge Employee API ",
                    Version = version
                };

                c.SwaggerDoc($"v{versionNumber.Major}", info);

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.OperationFilter<SwaggerParameterAttributeFilter>();


                c.EnableAnnotations();
                c.DescribeAllEnumsAsStrings();
            }).AddSwaggerGenNewtonsoftSupport();

            services.AddControllers();
        }

        private string BuildSwaggerVersionString(string environment)
        {
            return $"{versionNumber}-{environment}";
        }

        private string GetEnvironment()
        {
            var environment = this.Configuration.GetSection("DeployEnvironment").Value;
            if (string.IsNullOrEmpty(environment))
            {
                throw new VogCodeChallengeStartupException("The environment variable 'DeployEnvironment' must be specified for VogCodeChallenge Employee API to start.");
            }

            return environment;
        }
    }
}
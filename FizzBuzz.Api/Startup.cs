using FizzBuzz.Api.Application.Interfaces;
using FizzBuzz.Api.Application.Services;
using FizzBuzz.Api.Domain.Entities;
using FizzBuzz.Api.Domain.Services;
using FizzBuzz.Api.Infrastructure.Data;
using FizzBuzz.Api.Infrastructure.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ILogger = FizzBuzz.Api.Infrastructure.Logging.ILogger;
using IFileRepository = FizzBuzz.Api.Infrastructure.Data.IFileRepository;

namespace FizzBuzz.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<FizzBuzzService>();
            services.AddScoped<IFizzBuzzAppService, FizzBuzzAppService>();
            services.AddScoped<IFileRepository, FileRepository>(provider =>
                new FileRepository(Configuration.GetValue<string>("FilePath")));
            services.AddScoped<ILogger, FileLogger>(provider =>
                new FileLogger(Configuration.GetValue<string>("LogFilePath")));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    internal interface IFileRepository
    {
        Task SaveSeriesAsync(FizzBuzzSeries series);
    }
}

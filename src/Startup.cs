using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;
using TodoApp.Infrastructure.Data;

namespace TodoApp
{
	public class Startup
    {
        private const string SqlConnectionString = "ConnectionStrings:DefaultConnection";

        private readonly IConfiguration _configuration;

		public Startup(IConfiguration configuration)
		{
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connection = _configuration.GetValue<string>(SqlConnectionString);
            services.AddDbContext<ToDoContext>(options => options.UseSqlServer(connection));

            services.AddLogging();
            services.AddMvc();
            services.AddAutoMapper(GetExecutingAssembly());
            services.AddMediatR(GetExecutingAssembly());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });

            InitializeDatabase(app);
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ToDoContext>();
                context.Database.Migrate();

                if (!context.Categories.Any())
                {
                    context.Categories.Add(new Category("Deployment"));
                    context.Categories.Add(new Category("Development"));
                    context.Categories.Add(new Category("Design"));
                    context.Categories.Add(new Category("Integrations"));
                    context.Categories.Add(new Category("Operations"));
                    context.Categories.Add(new Category("UX"));
                    context.SaveChanges();
                }
            }
        }

        private static Assembly GetExecutingAssembly()
        {
            return typeof(Startup).GetTypeInfo().Assembly;
        }
    }
}

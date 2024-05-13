using Microsoft.EntityFrameworkCore;
using NoteAI.Data.Authorization;
using NoteAI.Data.Contexts;
using NoteAI.Data.Entities;
using NoteAI.Data.Repositories;

namespace NoteAI.Init
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<MasterContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"),
                    op => op.EnableRetryOnFailure()
                );
            });

            // Services and repositories
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IFileAttachmentRepository, FileAttachmentRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(setup => { setup.RoutePrefix = "swagger"; });
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            // **Important:** UseAuthentication before UseAuthorization
            app.UseAuthentication();
            app.UseAuthorization();

            // Configure CORS policies
            app.UseCors(builder =>
            {
                builder
                    .WithOrigins("http://localhost:4200",
                        "https://yourappdomain.com") // Replace with your allowed origins
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Define endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Maps requests to your controllers
            });
        }
    }
}
using Microsoft.EntityFrameworkCore;
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
                app.UseSwagger(setup => { });
                app.UseSwaggerUI(setup => { setup.RoutePrefix = "swagger"; });
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseCors();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
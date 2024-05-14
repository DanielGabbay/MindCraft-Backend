using MindCraft.Init;

namespace MindCraft;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build() /*Running*/.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.AddConsole();
            })
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}
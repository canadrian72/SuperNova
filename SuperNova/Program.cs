using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace SuperNova
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            launcher.pwmInit();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

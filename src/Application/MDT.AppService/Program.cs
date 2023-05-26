using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MDT.AppService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string myarg = string.Empty;
            if (args.Length>0)
            {
                myarg = args[0];
            }
            CreateWebHostBuilder(args)                
                .Build()
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

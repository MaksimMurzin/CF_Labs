using CF_Labs.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace CF_Labs
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"C:\Users\Makos_PC\Desktop\CF-Labs\CF-Labs\Data\JsonData.json";
            var host = CreateHostBuilder(args).Build();

            //var mockDb = new JsonTradeDatabase();
            var dataSorter = new DataSorter(host.Services.GetRequiredService<ITradesDatabase>());

            var allBuys = dataSorter.GetAllBuys();
            var allSells = dataSorter.GetAllSells();

            Console.WriteLine( $"Total PNL:  {ProfitCounter.CalculatePNL(allBuys,allSells)}" );
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<ITradesDatabase, JsonTradeDatabase>();
                });
        }


    }
}

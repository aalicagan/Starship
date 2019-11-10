using AutoMapper;
using SimpleInjector;
using Star_Wars.DTO;
using System;
using System.Linq;
namespace Star_Wars
{
    public static class Program
    {

        static StarShipService service;
        static void Main(string[] args)
        {
            Bootstrap.Start();
            service = Bootstrap.container.GetInstance<StarShipService>();
            do
            {
                Console.Clear();
                CreateMenu();
                Console.WriteLine("Press any key to continue or press esc to exit..");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static void CreateMenu()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Please Input distance:");
            while (service.Distance == -1)
            {
                service.Distance = Helper.Helper.ValidInput(Console.ReadLine());
                if (service.Distance == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Please input a valid positive number (valid range: 0 - 9223372036854775807)");
                }
            }
            Console.WriteLine("Please wait we are collecting data..");
            service.GetStarships();
            Console.WriteLine($@"{service.GetCount()} Starship were found..");
            CalculateResupplyFreq();
            service.Distance = -1;
        }

        private static void CalculateResupplyFreq()
        {
            var result = service.CalculateReSupplyFrequence();
            foreach (var item in result)
            {
                Console.WriteLine($@"{item.Name} Mglt: {item.MGLT} ResuppyFreq No.: {(item.ResupplyFrequence == -1 ? "unkonwn" : item.ResupplyFrequence.ToString())}");
            }
            FindMaxResupplyFreq(result);
        }

        private static void FindMaxResupplyFreq(System.Collections.Generic.List<StarshipWithResupplyFrequenceDTO> result)
        {
            var r = result.Where(x => x.ResupplyFrequence == result.Max(x => x.ResupplyFrequence)).First();
            Console.WriteLine($@"{r.Name} have max ResuppltFrequence with({r.ResupplyFrequence})");
        }
    }
}
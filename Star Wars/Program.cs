using System;
namespace Star_Wars
{
    public static class Program
    {
        static IClientService client;
        public static long distance = -1;

        static void Main(string[] args)
        {
            Bootstrap.Start();
            client = Bootstrap.container.GetInstance<IClientService>();
            System.AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            do
            {
                Console.Clear();
                CreateMenu();
                Console.WriteLine("Press any key to continue or press esc to exit..");
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        private static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(((AggregateException)e.ExceptionObject).Message);
            CreateMenu();
        }

        private static void CreateMenu()
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Please Input distance:");
            while (distance == -1)
            {
                distance = Helper.Helper.ValidInput(Console.ReadLine());
                if (distance == -1)
                {
                    Console.Clear();
                    Console.WriteLine("Please input a valid positive number (valid range: 0 - 9223372036854775807)");
                }
            }
            Console.WriteLine("Please wait we are collecting data..");
            client.Execute(distance);
            Console.WriteLine($@"{client.GetCount()} Starship were found..");
            distance = -1;
        }
    }
}
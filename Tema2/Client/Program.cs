using Grpc.Net.Client;
using System;
using System.Globalization;
using System.Threading.Tasks;
using ZodiacSign;

namespace Client
{
    class Program
    {
        static bool ValidateDate(string date)
        {
            DateTime dt;
            if (DateTime.TryParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))
                return true;
            return false;
        }
        static async Task Main(string[] args)
        {
            string date;
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Zodiac.ZodiacClient(channel);

            while (true)
            {
                Console.WriteLine("Introduceti data de nastere:");
                date = Console.ReadLine();
                if (ValidateDate(date))
                {
                    var clientDate = new DateRequest { Date = date };
                    var reply = await client.GetZodiacSignAsync(clientDate);
                    Console.WriteLine("Zodia este: " + reply.Sign);
                    break;
                }
                else
                    Console.WriteLine("Data introdusa nu este valida.");
            }

            Console.WriteLine("Apasati orice tasta pentru a inchide consola.");
            System.Console.ReadKey();
        }
    }
}

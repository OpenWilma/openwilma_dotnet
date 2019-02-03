using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Wilma.Api.Web;
using Wilma.Api.Wilma;

namespace Wilma.Api.Sandbox
{
    public class Program
    {
        private readonly WilmaApiContext _context;

        public Program(Queue<string> args)
        {
            _context = new WilmaApiContext(args.Dequeue(), args.Dequeue());
        }

        public async Task RunAsync(Queue<string> args)
        {
            IList<WilmaServer> servers = await WAPI.GetServersAsync();
            
            var userApi = new UserApi(_context);
            WilmaSession session = await userApi.LoginAsync(args.Dequeue(), args.Dequeue());
            
            if (!session.IsAuthenticated)
            {
                Console.WriteLine("Authentication failed! Quitting..");
                return;
            }
            else Console.WriteLine("Logged in succesfully!");

            foreach (WilmaRole role in session.Roles)
            {
                if (role.Type == RoleType.Username)
                    continue;

                Console.WriteLine($"Fetching messages for {role.Name}");

                var messageApi = new MessageApi(_context, role);
                IList<WilmaMessage> messages = await messageApi.FetchAsync();

                Console.WriteLine($"{messages.Count} messages found!");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Wilma.Api - Sandbox");
            try
            {
                var queue = new Queue<string>(args);

                var program = new Program(queue);
                program.RunAsync(queue).Wait();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception thrown: " + ex);
            }
            Console.WriteLine("Press any key to exit..");
            Console.ReadKey();
        }
    }
}

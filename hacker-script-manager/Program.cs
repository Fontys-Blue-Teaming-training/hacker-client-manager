using System;
using websocket_client;
using System.Threading.Tasks;

namespace hacker_script_manager
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            SocketClient sc = new SocketClient(new HackerMessageHandler<ScenarioMessage>(), "172.16.1.4");
            Console.WriteLine("Setting up client");
            sc.InitClient();
            await sc.StartClient();
            Console.Write("Client started");
            Console.ReadLine();
        }
    }
}

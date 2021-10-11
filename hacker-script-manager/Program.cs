using System;
using websocket_client;
using System.Threading.Tasks;

namespace hacker_script_manager
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            SocketClient sc = new SocketClient(new HackerMessageHandler<ScenarioMessage>());
            Console.WriteLine("Setting up client");
            sc.InitClient();
            await sc.StartClient();
            Console.Write("Client started");
            Console.ReadLine();
        }
    }
}

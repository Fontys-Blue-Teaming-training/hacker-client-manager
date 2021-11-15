using System;
using websocket_client;
using System.Threading.Tasks;
using WatsonWebsocket;
using System.Text.RegularExpressions;

namespace hacker_script_manager
{
     public class Program
    {

        static async Task Main(string[] args)
        {
            
            SocketClient sc = new SocketClient(new HackerMessageHandler<ScenarioMessage>(), "172.16.1.4");
            HackerMessageHandler<ScenarioMessage> hh = new HackerMessageHandler<ScenarioMessage>();
            Console.WriteLine("Setting up client");
            sc.InitClient();
            await sc.StartClient();
            Console.Write("Client started");
            Console.ReadLine();
             

        }

        
    }
}

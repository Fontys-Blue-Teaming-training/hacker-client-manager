using System;
using websocket_client;
using System.Threading.Tasks;
using System.Threading;

namespace hacker_script_manager
{
    public class HackerMessageHandler<T> : MessageHandler<T> where T : ScenarioMessage
    {
        Script script = null;

        public override void HandleMessage(string message)
        {
            var scenarioMessage = ReceiveAsObj(message);
            Console.WriteLine(message);
            Console.WriteLine("------------");

            if (scenarioMessage != null)
            {
                if (scenarioMessage.Action == ScenarioActions.START)
                {
                    if (scenarioMessage.Scenario == Scenarios.LINUX_SSH_ATTACK)
                    {
                        script = new PingScript();
                        Console.Write("Linux SSH attack is starting");
                        Thread t = new Thread(() => script.StartScript());
                        t.Start();
                        Task.Run(() => SendOutput());
                    }
                    else
                    {
                        Console.Write("Other script should start");
                    }
                }
                else
                {
                    Console.Write("Message doesnt want script to start");
                }
            }
            else
            {
                Console.Write("No message given by server");
            }
        }

        public async Task SendOutput()
        {
            int hasRan = 0;
            while(true)
            {
                if(script.Outputs.Count > hasRan)
                {
                    await SendMessage(script.Outputs[hasRan]);
                    hasRan++;
                }
            }
        }
    }
}

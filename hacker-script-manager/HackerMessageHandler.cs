using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using websocket_client;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

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
            if(scenarioMessage != null)
            {
                if(scenarioMessage.Action == ScenarioActions.START)
                {
                    if(scenarioMessage.Scenario == Scenarios.LINUX_SSH_ATTACK)
                    {
                        script = new HydraScript();
                        Console.Write("Linux SSH attack is starting");
                        Thread t = new Thread(() => script.Start_Script());
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
            while (true)
            {
                if(script.Outputs.Count > hasRan)
                {
                    InfoMessage m = new InfoMessage();
                    m.Message = script.Outputs[hasRan];
                    m.Type = InfoMessageType.INFO;
                    await SendMessage(JsonConvert.SerializeObject(m));
                    hasRan++;
                }
            }
        }

     

    }
}

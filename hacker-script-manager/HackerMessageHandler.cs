using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using websocket_client;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Threading;

namespace hacker_script_manager
{
    public class HackerMessageHandler<T> : MessageHandler<T> where T : ScenarioMessage
    {
        public List<string> matchesToSend = new List<string>();
        PingScript pi = new PingScript();

        public override void HandleMessage(string message)
        {
            var bla = ReceiveAsObj(message);
            ScenarioMessage m = bla;
            Console.WriteLine(message);
            Console.WriteLine("------------");
            Thread t = new Thread(() => Anal_Message(m));
            t.Start();
            Task.Run(() => SendSomething());
            
        }

        public async Task Anal_Message(ScenarioMessage m)
        {
            if(m != null)
            {
                if(m.Action == ScenarioActions.START)
                {
                   if(m.Scenario == Scenarios.LINUX_SSH_ATTACK)
                    {
                        Console.Write("Linux SSH attack is starting");
                        pi.Start_Script();
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

        public async Task SendSomething()
        {
            int hasRan = 0;
            while(true)
            {
                if(pi.outputs.Count > hasRan)
                {
                    await SendMessage(pi.outputs[hasRan]);
                    hasRan++;
                }

            }
        }
    }
}

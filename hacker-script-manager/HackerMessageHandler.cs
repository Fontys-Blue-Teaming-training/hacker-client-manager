using System;
using websocket_client;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json;

namespace hacker_script_manager
{
    public class HackerMessageHandler<T> : MessageHandler<T> where T : ScenarioMessage
    {
        Script script = null;
        bool b = false;

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
                        script.Name = "SSH Bruteforcing";
                        Console.Write("Linux SSH attack is starting");
                        Thread t = new Thread(() => script.StartScript());
                        t.Start();
                        Task.Run(() => SendOutput());
                    }
                    else if(scenarioMessage.Scenario == Scenarios.MALWARE)
                    {
                        script = new MalwareScript();
                        script.Name = "Malware";
                        Console.Write("Malware executable is starting");
                        Thread t = new Thread(() => script.StartScript());
                        t.Start();
                        Task.Run(() => SendUpdate());
                    }
                }
                else if(scenarioMessage.Action == ScenarioActions.STOP)
                {
                    Console.Write(script.Name + "attack is stopping");
                    script.StopScript();
                    b = true;
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
            while (b == false)
            {
                if(script.Outputs.Count > hasRan)
                {
                    InfoMessage m = new InfoMessage
                    {
                        Message = script.Outputs[hasRan]
                    };

                    if (m.Message.Contains("#"))
                    {
                        m.Type = InfoMessageType.ERROR;
                    }
                    else
                    {
                        m.Type = InfoMessageType.INFO;
                    }

                    await SendMessage(JsonConvert.SerializeObject(m));
                    hasRan++;
                }
            }
        }



        public async Task SendUpdate()
        {
            InfoMessage m = new InfoMessage();
            try
            {
                m.Type = InfoMessageType.INFO;
                m.Message = "Malware script has started";
                await SendMessage(JsonConvert.SerializeObject(m));
                Thread.Sleep(200000);
                m.Message = "Sensitive Data encrypted";
                await SendMessage(JsonConvert.SerializeObject(m));
                Thread.Sleep(200000);
                m.Message = "Back Up Encrypted";
                await SendMessage(JsonConvert.SerializeObject(m));
            }
            catch(Exception e)
            {
                m.Type = InfoMessageType.ERROR;
                Console.WriteLine(e);
                m.Message = e.ToString();
                await SendMessage(JsonConvert.SerializeObject(m));
            }
        }
    }
}
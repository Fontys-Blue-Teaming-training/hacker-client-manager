using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using websocket_client;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace hacker_script_manager
{
    public class HackerMessageHandler<T> : MessageHandler<T> where T : ScenarioMessage
    {
       

        List<string> outputs = new List<string>();
        public List<string> matchesToSend = new List<string>();
        ScenarioMessage m;
        PingScript pi = new PingScript();
        HydraScript hp = new HydraScript();

        public override void HandleMessage(string message)
        {
            var bla = ReceiveAsObj(message);
            ScenarioMessage m = bla;
            Console.WriteLine(message);
            Console.WriteLine("------------");
            //Anal_Message(m);
            //SendSomething();
            Task.Run(() => Anal_Message(m));
            
           // Task.Run(() => SendSomething());
        }

       

        public ScenarioMessage returnMessageObject()
        {
            return m;
        }



        public async void Anal_Message(ScenarioMessage m)
        {
            if(m != null)
            {
                if(m.Action == ScenarioActions.START)
                {
                   if(m.Scenario == Scenarios.LINUX_SSH_ATTACK)
                    {
                        Console.Write("Linux SSH attack is starting");
                        // Script ping = new Script(2, "ping", @"C:\Users\31640\Desktop\test.bat", "", @"\bt\S*");

                        //PingScript p = new PingScript();
                        hp.Start_Script();
                        foreach(var a in hp.Actualmessages)
                        {
                            var x = a;
                            SendMessage(x);
                            Console.WriteLine(x);
                       
                        } 

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

     
      /*

        public async void SendSomething()
        {
            //  await Task.Delay(1000);

            await Task.Delay(3000);
            while (true)
            {
                
                foreach (string a in pi.Actualmessages)
                {
                    string b = a;
                    pi.Actualmessages.Remove(a);
                    await SendMessage(b);
                    

                } 
            }
           

            
           
        }
      */

    }
}

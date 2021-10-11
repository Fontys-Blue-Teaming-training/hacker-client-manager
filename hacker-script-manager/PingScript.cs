using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace hacker_script_manager
{
    class PingScript
    {
        public List<string> outputs = new List<String>();

        public void ShowMatch(string text, string expr)
        {
            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                Console.WriteLine(m);
                if (m.ToString().Contains("time"))
                {

                    outputs.Add(m.ToString());
                }
            }
        }

        public void Start_Script()
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
    }
}

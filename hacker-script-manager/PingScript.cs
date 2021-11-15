using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace hacker_script_manager
{
    class PingScript : Script
    {


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

        public override void Start_Script()
        {
           
            Process p = new Process();
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = @"C:\Users\31640\Desktop\test.bat";
            p.Start();

            while (!p.StandardOutput.EndOfStream)
            {
                ShowMatch(p.StandardOutput.ReadLine(), @"\bt\S*");
            }
         
        }
    }
}
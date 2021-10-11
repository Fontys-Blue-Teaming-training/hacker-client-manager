using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp6
{
    class hahaha
    {

        List<string> outputs = new List<String>
            {
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aaa' - 1 of 12345679",
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aab' - 2 of 12345679",
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aac' - 3 of 12345679",
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aad' - 4 of 12345679",
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aae' - 5 of 12345679",
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aaf' - 10 of 12345679",
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aag' - 11 of 12345679",
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aah' - 13 of 12345679",
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aai' - 14 of 12345679",
                "[ATTEMPT] target 192.168.188.130 - login 'root' - pass 'aaj' - 15 of 12345679",
                "[ERROR] i just stubbed my toe hehehehe",
                "[ERROR] eloboosting not allowed 69"
            };

        private bool isAttempt = false;


        public List<string> Outputs { get => outputs; }
        public bool IsAttempt { get => isAttempt; set => isAttempt = value; }

        // public List<string> Meomeowadaw { get => meomeowadaw; set => meomeowadaw = value; }

        private List<string> matchesToSend = new List<string>();

        public void ShowMatch(string text, string expr)
        {

            MatchCollection mc = Regex.Matches(text, expr);
            foreach (Match m in mc)
            {
                if (isAttempt == true)
                {
                    string a = m.ToString();
                    string x = a.Substring(0, a.IndexOf("o"));
                    Console.WriteLine("Number of brute force attempts: {0}", x);
                }
                else
                { string a = m.ToString();
                    Console.WriteLine(a);
                    
                }
                
            }

        }


        

    }
}

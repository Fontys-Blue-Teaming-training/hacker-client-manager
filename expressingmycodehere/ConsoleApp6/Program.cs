using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp6
{
    class Program
    {
        static void Main(string[] args)
        {
  

            hahaha haha = new hahaha();
            foreach(var a in haha.Outputs)
            {
                if (a.Contains("[ATTEMPT]"))
                {
                    /*  dit laat alles na [ATTEMPT] zien
                    var pattern = @"\[(\w*)\]";
                    var replaced = Regex.Replace(a, pattern, "?");
                    haha.ShowMatch(replaced, @"(?<=\?).*"); */

                   haha.IsAttempt = true;
                    //Dit laat alleen number of numbers zien (attempts)
                   haha.ShowMatch(a, @"([^\-]+$)");
                   //haha.ShowMatch(a, @"^.*(?=o)");
                    
                    
                 
                    



                }
                else if (a.Contains("[ERROR]"))
                {/*
                    var pattern = @"\[(\w*)\]";
                    var replaced = Regex.Replace(a, pattern, "?");
                    //Console.WriteLine(replaced);
                    haha.ShowMatch(replaced, @"(?<=\?).*"); */

                }
                else
                {

                }
            }
            Console.ReadLine();
        }
    }
}

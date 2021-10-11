﻿using System;
using System.Collections.Generic;
using System.Text;

namespace hacker_script_manager
{
    abstract class Script
    {
    
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract List<String> Actualmessages { get; }

        public abstract List<String> Outputs { get; }

        public abstract List<String> MatchesToSend { get; }

        public abstract void Start_Script();

        public abstract void ShowMatch(string text, string expr);







    }
}
using System;
using System.Collections.Generic;

namespace hacker_script_manager
{
    abstract class Script
    {
        public string Name { get; set; }
        public List<string> Outputs { get; set; } = new List<string>();
        public abstract void StartScript();
        public abstract void StopScript();
    }
}
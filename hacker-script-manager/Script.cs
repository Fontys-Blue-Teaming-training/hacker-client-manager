using System.Collections.Generic;

namespace hacker_script_manager
{
    public abstract class Script
    {
        public List<string> Outputs { get; set; } = new List<string>();
        public abstract void StartScript();
    }
}

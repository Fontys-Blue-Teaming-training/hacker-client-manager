using System;
using System.Collections.Generic;
using System.Text;

namespace hacker_script_manager
{
    class Scripts
    {
        private List<Script> scripts = new List<Script>();

        public Scripts()
        {
            Script hydra = new Script(1, "hydra", "", "", "");
            Script ping = new Script(2, "ping", @"C: \Users\31640\Desktop\test.bat", "", @"\bt\S*");
            scripts.Add(hydra);
            scripts.Add(ping);
        }
    }
}

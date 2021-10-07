using System;
using System.Collections.Generic;
using System.Text;

namespace hacker_script_manager
{
    public class Script
    {
        private int id;
        private string name;
        private string path;
        private string command;
        private string regex;

        public Script(int id, string name, string path, string command, string regex)
        {
            Id = id;
            Name = name;
            Command = command;
            Regex = regex;
            Path = path;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Command { get => command; set => command = value; }
        public string Regex { get => regex; set => regex = value; }
        public string Path { get => path; set => path = value; }
      



    }
}

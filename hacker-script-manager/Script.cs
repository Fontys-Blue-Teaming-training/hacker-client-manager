﻿using System;
using System.Collections.Generic;
using System.Text;

namespace hacker_script_manager
{
    abstract class Script
    {

        //public TuInfoMessageType, List<String>> Outputs { get; set; };
        public List<String> Outputs { get; set; } = new List<string>();

        public abstract void Start_Script();

    }
}

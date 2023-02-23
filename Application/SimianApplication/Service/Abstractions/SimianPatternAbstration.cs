﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Abstractions
{
    public abstract class SimianPatternAbstration
    {
        public abstract string[] DefaultPattern { get; }

        public abstract bool CheckPattern(string[] dna);
    }
}

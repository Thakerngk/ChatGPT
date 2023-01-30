using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class Usage
    {
        //Difficulty of input
        public int prompt_tokens { get; set; }
        //Difficulty of output
        public int completion_tokens { get; set; }
        public int total_tokens { get; set; }
    }
}
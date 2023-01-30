using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class Choice
    {
        //Text response
        public string? text { get; set; }
        public int index { get; set; }
        public object? logprobs { get; set; }
        public string? finish_reason { get; set; }
    }
}
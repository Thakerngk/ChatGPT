using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatGPT
{
    public class OpenAIResponse
    {
        //Target job
        public string? @object { get; set; }     
        public int created { get; set; }
        //Engine used
        public string? model { get; set; }
        //API response
        public List<Choice>? choices { get; set; }
        //Tokens used
        public Usage? usage { get; set; }
    }
}
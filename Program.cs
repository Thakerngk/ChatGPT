// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System.Globalization;
using System.Net.Http.Headers;
using System.Text.Json;
using ChatGPT;
using Microsoft.Extensions.Configuration;

string? asked = "Y";
while (asked.ToUpper() == "Y") {
    Console.Clear();
    Console.Write("Provide a text question: ");
    var question = Console.ReadLine();

    //Call Open AI
    var answer = CallOpenAI(250,question,"text-davinci-002",0.7,1,0,0);
    Console.WriteLine(answer);

    Console.Write("\n\nAsk anymore?(Y/N): ");
    asked = Console.ReadLine();
}
string CallOpenAI(int tokens,string input,string engine,double temperature,int topP,int frequencyPenalty,int presencePenalty)
{
    var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json", optional: false);

    IConfiguration config = builder.Build();

    var openAIKey = config["openAIKey"];

    //Open AI Engine URL
    var apiCall = "https://api.openai.com/v1/engines/"+engine+"/completions";

    using (var httpClient = new HttpClient())
    {
        using (var request = new HttpRequestMessage(new HttpMethod("POST"), apiCall))
        {
            request.Headers.TryAddWithoutValidation("Authorization","Bearer "+ openAIKey);
            request.Content = new StringContent("{\n \"prompt\": \""+ input + "\",\n \"temperature\": "+
                                                temperature.ToString(CultureInfo.InvariantCulture) +
                                                ",\n \"max_tokens\": " +tokens +
                                                ",\n \"top_p\": " + topP +
                                                ",\n \"frequency_penalty\": " + frequencyPenalty +
                                                ",\n \"presence_penalty\": " + presencePenalty + "\n}");

            request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");   

            var response = httpClient.SendAsync(request).Result;
            var json = response.Content.ReadAsStringAsync().Result;

            //Console.WriteLine(json);
            OpenAIResponse myDeserializedClass = JsonSerializer.Deserialize<OpenAIResponse>(json);

            return myDeserializedClass.choices[0].text;                                 
        }
    }
}
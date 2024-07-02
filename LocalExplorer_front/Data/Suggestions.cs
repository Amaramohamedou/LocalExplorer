using System;
namespace LocalExplorer_front.Data
{

    //public class Suggestions
    //{
    //    public string Id { get; set; }
    //    public string Object { get; set; }
    //    public int Created { get; set; }
    //    public string Model { get; set; }
    //    public List<Choice> Choices { get; set; }
    //    public Usage Usage { get; set; }
    //}

    //public class Choice
    //{
    //    public int Index { get; set; }
    //    public Message Message { get; set; }
    //    public object Logprobs { get; set; }
    //    public string FinishReason { get; set; }
    //}

    //public class Message
    //{
    //    public string Role { get; set; }
    //    public string Content { get; set; }
    //}

    //public class Usage
    //{
    //    public int PromptTokens { get; set; }
    //    public int CompletionTokens { get; set; }
    //    public int TotalTokens { get; set; }
    //}

    public class ActivitySuggestion
    {
        public Suggestions Suggestions { get; set; }
        public string City { get; set; }
        public string Weather { get; set; }
        public string Localtime { get; set; }
        public string TempC { get; set; }
        public string Status { get; set; }
    }

    public class Suggestions
    {
        public string Id { get; set; }
        public string Object { get; set; }
        public long Created { get; set; }
        public string Model { get; set; }
        public List<Choice> Choices { get; set; }
        public Usage Usage { get; set; }
        public object SystemFingerprint { get; set; }
    }

    public class Choice
    {
        public int Index { get; set; }
        public Message Message { get; set; }
        public object Logprobs { get; set; }
        public string FinishReason { get; set; }
    }

    public class Message
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

    public class Usage
    {
        public int PromptTokens { get; set; }
        public int CompletionTokens { get; set; }
        public int TotalTokens { get; set; }
    }

}


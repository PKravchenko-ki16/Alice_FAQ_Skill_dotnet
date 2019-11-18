using Alice.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alice
{
    public interface IAnswerWordsStain : IAnswerWords
    {
        string Text { get; set; }
        string Tts { get; set; }
        string[] Surface { get; set; }
    }
}

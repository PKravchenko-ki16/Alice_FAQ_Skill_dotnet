using System;
using System.Collections.Generic;
using System.Text;

namespace Alice.Model
{
    public interface IAnswerWordsManagement 
    {
        string[] Text { get; set; }
        string[] Tts { get; set; }
    }
}

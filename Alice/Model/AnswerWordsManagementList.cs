using System;
using System.Collections.Generic;
using System.Text;

namespace Alice.Model
{
    public class AnswerWordsManagementList : IAnswerWordsManagement
    {
        public string[] Text { get; set; }
        public string[] Tts { get; set; }
    }
}

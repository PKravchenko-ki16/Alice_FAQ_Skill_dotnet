using System;
using System.Collections.Generic;
using System.Text;

namespace Alice.Model
{
    public class AnswerManagement
    {
        public string[] Words_activators { get; set; }
        public AnswerWordsManagementList Answers { get; set; }
        public bool isEnd { get; set; }
    }
}

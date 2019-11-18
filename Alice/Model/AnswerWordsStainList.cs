namespace Alice.Model
{
    public class AnswerWordsStainList : IAnswerWordsStain
    {
        public string Text { get; set; }
        public string Tts { get; set; }
        public string[] Surface { get; set; }
        public bool Оld { get; set; }
    }
}

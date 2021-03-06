﻿using Alice.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alice
{
    public class Replies
    {
        public Response response = new Response() { };

        public bool ContainOneOf(string text, string[] words)
        {
            text.ToLower().Split().ToHashSet();
            foreach (var i in words)
            {
                i.ToLower().Split().ToHashSet();
                if (text.IndexOf(i, StringComparison.OrdinalIgnoreCase) >= 0) return true;
            }
            return false;
        }

        public string[] ConcatArray(List<Position> positions)
        {
            List<string[]> namesList = new List<string[]> { };

            foreach (var i in positions)
            {
                namesList.Add(i.Name);
            }
            return namesList.Aggregate(Enumerable.Empty<string>(),
                (current, next) => current.Concat(next)).ToArray();
        }

        public AliceResponse Match(AliceRequest req)
        {
            Random random = new Random();
            FillingAnswers fillingAnswer = new FillingAnswers();
            var answerManagement = fillingAnswer.FillingManagement();
            var answerStain = fillingAnswer.FillingStain();
            var position = ConcatArray(fillingAnswer.FillingPosition());
            var oldStain = fillingAnswer.FillingOldStain();

            if (req.Session.New) return response.Reply(req, "Долой пятна приветствуют тебя, я помогу тебе избавиться от самых сложных пятен. " +
                "Чтобы начать, спроси меня: Как избавиться от пятна? " +
                "Если нужна помощь в навигации, просто скажи: Что умеешь ? . ");

            foreach (var i in answerManagement)
            {
                if (!ContainOneOf(req.Request.OriginalUtterance, i.Words_activators) || !i.IsEnd)
                {
                    if (!ContainOneOf(req.Request.OriginalUtterance, i.Words_activators))
                    {
                        continue;
                    }
                    return response.Reply(req, i.Answers.Tts.ElementAt(random.Next(0, i.Answers.Tts.Length)));
                }
                return response.Reply(req, i.Answers.Tts.ElementAt(random.Next(0, i.Answers.Tts.Length)), true);
            }

            foreach (var i in answerStain)
            {
                if (ContainOneOf(req.Request.OriginalUtterance, i.Words_activators) && ContainOneOf(req.Request.OriginalUtterance, position) && ContainOneOf(req.Request.OriginalUtterance, oldStain.Name))
                {
                    var answer = i.Answers.Where(u => ContainOneOf(req.Request.OriginalUtterance, u.Surface) == true && u.Оld).First().Text;
                    return response.Reply(req, answer);
                }

                if (ContainOneOf(req.Request.OriginalUtterance, i.Words_activators) && ContainOneOf(req.Request.OriginalUtterance, position))
                {
                    var answer = i.Answers.Where(u => ContainOneOf(req.Request.OriginalUtterance, u.Surface) == true && (u.Оld == false)).First().Text;
                    return response.Reply(req, answer);
                }

                if (ContainOneOf(req.Request.OriginalUtterance, i.Words_activators) && ContainOneOf(req.Request.OriginalUtterance, oldStain.Name))
                {
                    return response.Reply(req, "Повторите запрос добавив на какой ткани появилось пятно? Пример ткани: цветная, белая, замша, ковёр, мебель?");
                }

                if (ContainOneOf(req.Request.OriginalUtterance, i.Words_activators))
                {
                    return response.Reply(req, "Запросу не хватает конкретики, например: Как избавиться от застаревшего пятна крови на белой ткани.");
                }
            }

            return response.Reply(req, "Пример полноценной команды: Как избавиться от застаревшего пятна крови на белой ткани. Или скажи помощь.");
        }
    }
}

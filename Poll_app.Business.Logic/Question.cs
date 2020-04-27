using System;
using System.Collections.Generic;

namespace Poll_app.Business.Logic
{
    public class Question
    {
        public string QuestionTag { get; }
        public string QuestionText { get; }

        public readonly List<Answer> possibleAnswers = new List<Answer>();

        public int QuestionCount { get; set; }
    }
}

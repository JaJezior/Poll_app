using System;
using System.Collections.Generic;

namespace Poll_app.Business.Logic
{
    public class Question
    {
        //public string QuestionTag { get; }
        public string QuestionText { get; set; }

        public List<Answer> possibleAnswers;

        public int QuestionCount { get; set; }
    }
}

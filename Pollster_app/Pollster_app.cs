using System;
using System.Collections.Generic;
using Poll_app.Business.Logic;

namespace Pollster
{
    class Pollster_app
    {
        public DataService dataService = new DataService();
        public PollService pollService = new PollService();
        static void Main()
        {
            //InitData();
            new Pollster_app().Run();
           
        }



        private void Run()
        {
            
            Console.WriteLine("Uruchomiono program Pollster CodeMentos");

            List<Question> loadedQuestions = pollService.LoadQuestions();
            pollService.AskQuestions(loadedQuestions);
            pollService.SaveAnswers(loadedQuestions);



        }

        //private static void InitData()
        //{
        //    List<Question> _list = new List<Question>()
        //    {
        //        new Question()
        //        {
        //            QuestionText = "Tekst pytania",
        //            possibleAnswers = new List<Answer>
        //            {
        //                new Answer
        //                {
        //                    AnswerIndex = 1,
        //                    AnswerCount = 0,
        //                    AnswerText = "Odpowiedź 1"
        //                 },
        //                new Answer
        //                {
        //                    AnswerIndex = 2,
        //                    AnswerCount = 0,
        //                    AnswerText = "Odpowiedź 2"
        //                }
        //            }

        //        },
        //        new Question()
        //        {
        //            QuestionText = "Tekst pytania2",
        //            possibleAnswers = new List<Answer>
        //            {
        //                new Answer
        //                {
        //                    AnswerIndex = 1,
        //                    AnswerCount = 0,
        //                    AnswerText = "Odpowiedź 1"
        //                 },
        //                new Answer
        //                {
        //                    AnswerIndex = 2,
        //                    AnswerCount = 0,
        //                    AnswerText = "Odpowiedź 2"
        //                }
        //            }

        //        }
        //    };
        //    var _dataService = new DataService();
        //    _dataService.Serialize(_list, "questions.json");
        //}
    }
}




using System;
using System.Collections.Generic;
using Poll_app.Business.Logic;

namespace Pollster
{
    class Pollster
    {
        public DataService dataService = new DataService();
        static void Main()
        {
            //InitData();
            new Pollster().Run();
        }



        private void Run()
        {




            Console.WriteLine("Uruchomiono program Pollster CodeMentos");

            //LoadQuestions();
            dataService.AskQuestions(dataService.LoadQuestions());



        }



        


        private static void InitData()
        {
            List<Question> _list = new List<Question>()
            {
                new Question()
                {
                    QuestionText = "Tekst pytania",
                    possibleAnswers = new List<Answer>
                    {
                        new Answer
                        {
                            AnswerIndex = 1,
                            AnswerCount = 0,
                            AnswerText = "Odpowiedź 1"
                         },
                        new Answer
                        {
                            AnswerIndex = 2,
                            AnswerCount = 0,
                            AnswerText = "Odpowiedź 2"
                        }
                    }

                },
                new Question()
                {
                    QuestionText = "Tekst pytania2",
                    possibleAnswers = new List<Answer>
                    {
                        new Answer
                        {
                            AnswerIndex = 1,
                            AnswerCount = 0,
                            AnswerText = "Odpowiedź 1"
                         },
                        new Answer
                        {
                            AnswerIndex = 2,
                            AnswerCount = 0,
                            AnswerText = "Odpowiedź 2"
                        }
                    }

                }
            };
            var _dataService = new DataService();
            _dataService.Serialize(_list, "questions.json");
        }
        

        
    }
}




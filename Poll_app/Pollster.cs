using System;
using System.Collections.Generic;
using Poll_app.Business.Logic;

namespace Pollster
{
    class Pollster
    {
        static void Main()
        {
            //InitData();
            new Pollster().Run();
        }



        private void Run()
        {




            Console.WriteLine("Uruchomiono program Pollster CodeMentos");

            //LoadQuestions();
            AskQuestions(LoadQuestions());



        }



        public DataService dataService = new DataService();


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
        private List<Question> LoadQuestions()
        {



            Console.WriteLine("Aby wczytać pytania podaj ścieżkę pliku *.json: (np. questions.json).");

            var input = Console.ReadLine();



            try
            {
                dataService.Deserialize(input);
                Console.WriteLine($"Pytania z pliku {input} zostały wczytane.");

            }
            catch (ArgumentException ArgException)
            {
                Console.WriteLine(ArgException.Message);

            }
            catch (FormatException FormatException)
            {
                Console.WriteLine(FormatException.Message);
            }
            catch (System.IO.FileNotFoundException FileNFException)
            {
                Console.WriteLine(FileNFException.Message);
            }
            return dataService.Deserialize(input);





        }

        private void AskQuestions(List<Question> loadedQuestions)
        {
            for (int i = 0; i < loadedQuestions.Count; i++)
            {
                Question q = loadedQuestions[i];
                Console.WriteLine($"{loadedQuestions[i].QuestionText}");

                for (int j = 0; j < loadedQuestions[i].possibleAnswers.Count; j++)
                {
                    Console.WriteLine($"{loadedQuestions[i].possibleAnswers[j].AnswerIndex}. {loadedQuestions[i].possibleAnswers[j].AnswerText}");
                }

                Console.WriteLine("Wybierz numer odpowiedzi:");

                try
                {
                    int usersAnswer = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Zapisano. Twoja odpowiedź to: {usersAnswer}.");

                }
                catch (ArgumentException argexception)
                {
                    System.Console.WriteLine(argexception.Message);
                }
                catch (FormatException formatexception)
                {
                    System.Console.WriteLine(formatexception.Message);
                }
                
            }
            
            
        }
    }
}




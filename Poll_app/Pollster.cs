using System;
using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;
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

            LoadQuestions();
            AskQuestions();



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
        private void LoadQuestions()
        {


            while (true)
            {
                Console.WriteLine("Aby wczytać pytania podaj ścieżkę pliku *.json: (np. questions.json) lub 'q' aby zakończyć wczytywanie pytań.");

                var input = Console.ReadLine();
                if (input == "q") { break; }
                else
                {
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
                    //finally
                    //{
                    //    Console.WriteLine("Wczytywanie nie powiodło się.");
                    //}
                }

            }


        }

        private void AskQuestions()
        {
            throw new NotImplementedException();
        }
    }
}




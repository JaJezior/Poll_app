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
            new Pollster().Run();
        }

        private void Run()
        {
            Console.WriteLine("Uruchomiono program Pollster CodeMentos");

            LoadQuestions();


        }


        private readonly DataService dataService = new DataService();

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
                    finally
                    {
                        Console.WriteLine("Wczytywanie nie powiodło się.");
                    }
                }

            }


        }
    }
}




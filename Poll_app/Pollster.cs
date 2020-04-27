using System;
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
        string input;

        private readonly DataService dataService = new DataService();

        private void LoadQuestions()
        {
            Console.WriteLine("Aby wczytać pytania podaj ścieżkę pliku *.json: (np. questions.json");
            input = Console.ReadLine();
            dataService.Deserialize(input);

        }
    }
}

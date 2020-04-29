using System;
using System.Collections.Generic;
using Poll_app.Business.Logic;

namespace Reporter
{
    class Reporter
    {
        public DataService dataService = new DataService();
        static void Main()
        {
            new Reporter().Run();
        }

        private void Run()
        {
            Console.WriteLine("Uruchomiono program Reporter CodeMentos");

            List<Question> loadedQuestion = dataService.LoadQuestions();

        }
    }
}

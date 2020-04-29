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

            List<Question> loadedQuestions = dataService.LoadQuestions();
            dataService.GenerateReport(loadedQuestions);
            Console.WriteLine("Zapisać raport? [Y - tak, dowolny znak - zakończ]");
            string input = Console.ReadLine();
            if (input == "Y")
            {
                dataService.SaveReportToFile(loadedQuestions);
                
                Console.ReadKey();

            }
            if (input != "Y")
            {Environment.Exit(0);}
            
        }
    }
}

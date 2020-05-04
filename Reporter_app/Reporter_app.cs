using System;
using System.Collections.Generic;
using System.Text;
using Poll_app.Business.Logic;

namespace Reporter
{
    class Reporter_app
    {
        public PollService pollService = new PollService();
        public ReportService reportService = new ReportService();
        static void Main()
        {
            new Reporter_app().Run();
        }

        private void Run()
        {
            Console.WriteLine("Uruchomiono program Reporter CodeMentos");

            List<Question> loadedQuestions = pollService.LoadQuestions();
            StringBuilder reportText = reportService.GenerateReport(loadedQuestions);

            Console.WriteLine("Zapisać raport? [Y - tak, dowolny znak - zakończ]");
            string input = Console.ReadLine();
            if (input == "Y")
            {
                reportService.SaveReportToFile(reportText);
                
                Console.ReadKey();

            }
            if (input != "Y")
            {Environment.Exit(0);}
            
        }
    }
}

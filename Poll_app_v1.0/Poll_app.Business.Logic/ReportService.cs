using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Poll_app.Business.Logic
{
    public class ReportService
    {
        public StringBuilder GenerateReport(List<Question> loadedQuestions)
        {
            if (loadedQuestions is null)
            {
                throw new ArgumentNullException(nameof(loadedQuestions));
            }
            StringBuilder reportText = new StringBuilder("");
            reportText.Append("Raport");
            ReportContentGenerator(loadedQuestions, reportText);
            Console.WriteLine(reportText);
            return reportText;
        }

        private static void ReportContentGenerator(List<Question> loadedQuestions, StringBuilder reportText)
        {
            for (int i = 0; i < loadedQuestions.Count; i++)
            {

                reportText.Append($"{loadedQuestions[i].QuestionText}");
                reportText.AppendLine();
                reportText.Append($"To pytanie zadano następującą liczbę razy: {loadedQuestions[i].QuestionCount}");
                reportText.AppendLine();

                for (int j = 0; j < loadedQuestions[i].possibleAnswers.Count; j++)
                {
                    reportText.Append($"{loadedQuestions[i].possibleAnswers[j].AnswerIndex}. {loadedQuestions[i].possibleAnswers[j].AnswerText}");
                    reportText.AppendLine();
                    reportText.Append($"Tę odpowiedź wybrano {loadedQuestions[i].possibleAnswers[j].AnswerCount} raz(-y) na {loadedQuestions[i].QuestionCount} możliwych");
                    reportText.AppendLine();

                    //Pasek procentowy
                    StringBuilder percentageBar = PercentageBarBuilder(loadedQuestions, i, j);
                    reportText.Append(percentageBar);
                    reportText.AppendLine();
                }
            }
        }

        private static StringBuilder PercentageBarBuilder(List<Question> loadedQuestions, int i, int j)
        {
            StringBuilder percentageBar = new StringBuilder("[");

            double thisAnswerPercentage = 100 * loadedQuestions[i].possibleAnswers[j].AnswerCount / loadedQuestions[i].QuestionCount;
            thisAnswerPercentage = Math.Round(thisAnswerPercentage, 0);
            for (int x = 1; x <= 100; x++)
            {
                if (thisAnswerPercentage >= x)
                {
                    percentageBar.Append("█");
                }
                if (thisAnswerPercentage < x)
                {
                    percentageBar.Append("_");
                }

            }
            percentageBar.Append("]");
            return percentageBar;
        }

        public void SaveReportToFile(StringBuilder reportText)
        {
            Console.WriteLine("Podaj ścieżkę gdzie chcesz zapisać plik:");
            string input = Console.ReadLine();
            input += ".txt";
            File.WriteAllText(input, reportText.ToString());

            Console.WriteLine($"Zakończono generowanie raportu. Zapisano {input}.");
        }
    }
}

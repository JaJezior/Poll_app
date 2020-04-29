using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;


namespace Poll_app.Business.Logic
{
    public class DataService
    {
        public void Serialize(List<Question> loadedQuestions, string filePath)
        {
            //Zapis do pliku
            filePath = filePath + ".json";
            var jsonData = JsonConvert.SerializeObject(loadedQuestions, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Zapisano plik {filePath}");

        }
        public List<Question> Deserialize(string filePath)
        {

            //Wczytywanie z pliku
            List<Question> loadedQuestions = new List<Question>();

            var jsonData = File.ReadAllText(filePath);
            loadedQuestions = JsonConvert.DeserializeObject<List<Question>>(jsonData);
            return loadedQuestions;


        }
        public List<Question> AskQuestions(List<Question> loadedQuestions)
        {
            if (loadedQuestions is null)
            {
                throw new ArgumentNullException(nameof(loadedQuestions));
            }

            for (int i = 0; i < loadedQuestions.Count; i++)
            {

                Console.WriteLine($"{loadedQuestions[i].QuestionText}");

                for (int j = 0; j < loadedQuestions[i].possibleAnswers.Count; j++)
                {
                    Console.WriteLine($"{loadedQuestions[i].possibleAnswers[j].AnswerIndex}. {loadedQuestions[i].possibleAnswers[j].AnswerText}");
                }

                bool isAnswerDone = false;

                while (isAnswerDone == false)
                {
                    try
                    {
                        Console.WriteLine("Wybierz numer odpowiedzi:");
                        int usersAnswer = int.Parse(Console.ReadLine());

                        if (loadedQuestions[i].possibleAnswers.Exists(x => x.AnswerIndex == usersAnswer))
                        {

                            foreach (Answer ans in loadedQuestions[i].possibleAnswers)
                            {
                                if (usersAnswer == ans.AnswerIndex)
                                {
                                    ans.AnswerCount++;
                                    Console.WriteLine($"Zapisano. Twoja odpowiedź to: {usersAnswer}.");
                                    isAnswerDone = true;
                                }
                            }
                            loadedQuestions[i].QuestionCount++;
                        }
                        if (!loadedQuestions[i].possibleAnswers.Exists(x => x.AnswerIndex == usersAnswer))
                        {
                            Console.WriteLine($"Odpowiedź '{usersAnswer}' nie istnieje.");
                        }

                    }
                    catch (ArgumentException argexception)
                    {
                        Console.WriteLine(argexception.Message);
                    }
                    catch (FormatException formatexception)
                    {
                        Console.WriteLine(formatexception.Message);
                    }
                }



            }
            Console.WriteLine("Nie ma więcej pytań.");
            return loadedQuestions;


        }
        public List<Question> LoadQuestions()
        {
            var input = "";
            bool isLoadingDone = false;

            while (isLoadingDone == false)
            {

                Console.WriteLine("Aby wczytać pytania podaj ścieżkę pliku *.json: (np. questions.json).");
                input = Console.ReadLine();

                try
                {
                    Deserialize(input);
                    Console.WriteLine($"Pytania z pliku {input} zostały wczytane.");
                    isLoadingDone = true;
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

            }
            return Deserialize(input);
        }
        public void SaveAnswers(List<Question> loadedQuestions)
        {
            if (loadedQuestions is null)
            {
                throw new ArgumentNullException(nameof(loadedQuestions));
            }

            bool isSavingDone = false;

            while (isSavingDone == false)
            {

                Console.WriteLine("Aby zapisać odpowiedzi podaj docelową ścieżkę pliku *.json: (np. 'answers').");
                string input = Console.ReadLine();

                try
                {
                    Serialize(loadedQuestions, input);
                    Console.WriteLine($"Plik {input} został zapisany.");
                    isSavingDone = true;
                }
                catch (ArgumentException ArgException)
                {
                    Console.WriteLine(ArgException.Message);

                }
                catch (FormatException FormatException)
                {
                    Console.WriteLine(FormatException.Message);
                }

            }

        }
        public void GenerateRaport(List<Question> loadedQuestions)
        {
            if (loadedQuestions is null)
            {
                throw new ArgumentNullException(nameof(loadedQuestions));
            }
            Console.WriteLine("Raport");
            for (int i = 0; i < loadedQuestions.Count; i++)
            {
                
                Console.WriteLine($"{loadedQuestions[i].QuestionText}");
                Console.WriteLine($"To pytanie zadano następującą liczbę razy: {loadedQuestions[i].QuestionCount}");

                for (int j = 0; j < loadedQuestions[i].possibleAnswers.Count; j++)
                {
                    Console.WriteLine($"{loadedQuestions[i].possibleAnswers[j].AnswerIndex}. {loadedQuestions[i].possibleAnswers[j].AnswerText}");
                    Console.WriteLine($"Tę odpowiedź wybrano {loadedQuestions[i].possibleAnswers[j].AnswerCount} raz(-y) na {loadedQuestions[i].QuestionCount} możliwych");

                    //Pasek procentowy
                    StringBuilder percentageBar = new StringBuilder("[");

                    double thisAnswerPercentage =  100 * loadedQuestions[i].possibleAnswers[j].AnswerCount / loadedQuestions[i].QuestionCount;
                    thisAnswerPercentage = Math.Round(thisAnswerPercentage, 0);

                }


                bool isAnswerDone = false;

                while (isAnswerDone == false)
                {
                    try
                    {
                        Console.WriteLine("Wybierz numer odpowiedzi:");
                        int usersAnswer = int.Parse(Console.ReadLine());

                        if (loadedQuestions[i].possibleAnswers.Exists(x => x.AnswerIndex == usersAnswer))
                        {

                            foreach (Answer ans in loadedQuestions[i].possibleAnswers)
                            {
                                if (usersAnswer == ans.AnswerIndex)
                                {
                                    ans.AnswerCount++;
                                    Console.WriteLine($"Zapisano. Twoja odpowiedź to: {usersAnswer}.");
                                    isAnswerDone = true;
                                }
                            }
                            loadedQuestions[i].QuestionCount++;
                        }
                        if (!loadedQuestions[i].possibleAnswers.Exists(x => x.AnswerIndex == usersAnswer))
                        {
                            Console.WriteLine($"Odpowiedź '{usersAnswer}' nie istnieje.");
                        }

                    }
                    catch (ArgumentException argexception)
                    {
                        Console.WriteLine(argexception.Message);
                    }
                    catch (FormatException formatexception)
                    {
                        Console.WriteLine(formatexception.Message);
                    }
                }



            }
        }
        public void SaveReportToFile()
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("./Redirect.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);
            Console.WriteLine("This is a line of text");
            Console.WriteLine("Everything written to Console.Write() or");
            Console.WriteLine("Console.WriteLine() will be written to a file");
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
            Console.WriteLine("Done");
        }
    }
}


using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Poll_app;


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

                        if(loadedQuestions[i].possibleAnswers.Exists(x => x.AnswerIndex == usersAnswer))
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
    }
}


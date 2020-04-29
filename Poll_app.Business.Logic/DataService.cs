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
            var jsonData = JsonConvert.SerializeObject(loadedQuestions, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Zapisano plik {filePath}");

        }
        public List<Question> Deserialize(string filePath)
        {

            //Wczytywanie z pliku
            //List<Question> loadedQuestions = new List<Question>();
            var jsonData = File.ReadAllText(filePath);
            var loadedQuestions = JsonConvert.DeserializeObject<List<Question>>(jsonData);
            return loadedQuestions;
            }
        }
    }


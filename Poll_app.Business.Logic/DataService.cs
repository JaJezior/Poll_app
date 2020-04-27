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
        public object JsonConvert { get; private set; }

        public void Serialize()
        {
            //Zapis do pliku
        }
        public List<Question> Deserialize(string filePath)
        {

            //Wczytywanie z pliku
            var jsonData = File.ReadAllText(filePath);
            var loadedQuestions = JsonConvert.DeserializeObject<List<Question>>(jsonData);
            return loadedQuestions;
        }
    }
}

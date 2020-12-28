using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSearch.Model
{
    public static class StateFileHelper
    {              
        public static StateFile ReadConfig()
        {            
            var appdataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "fileSearcher.json");

            if (!File.Exists(appdataPath))
            {
                var result = new StateFile()
                {
                    SearchPath = Directory.GetCurrentDirectory(),
                    SearchPattern = "[\\w*]",
                };

                return result;
            }
            else
            {
                var result = ReadFromFile(appdataPath);
                return result;
            }
            
        }

        public static StateFile ReadFromFile(string appdataPath)
        {
            using (StreamReader file = File.OpenText(appdataPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                var result = (StateFile)serializer.Deserialize(file, typeof(StateFile));
                return result;
            }           
        }  
        
        public static void WriteConfig(StateFile config)
        {
            var appdataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "fileSearcher.json");

            using (StreamWriter file = File.CreateText(appdataPath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, config);
            }
        }
    }
}

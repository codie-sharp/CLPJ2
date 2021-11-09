using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace CLPJ2 
{
    public class ReadWrite
    {
        private static string dir = Directory.GetCurrentDirectory();
        private static string filePath;

        public static T Read<T>(string fileType) where T : class
        {
            filePath = Path.Combine(dir, $"{fileType}.json");
            if(!System.IO.File.Exists(filePath))
            {
                return null;
            }
            var json = System.IO.File.ReadAllText(filePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }

        public static void Write<T>(string fileType, List<T> list)
        {
            filePath = Path.Combine(dir, $"{fileType}.json");
            var json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filePath, json);
        }
    }
}

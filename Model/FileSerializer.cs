using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieApp.Model
{
    internal class FileSerializer
    {
        static string filePath = ConfigurationManager.AppSettings["FileLocation"];
        public static Movies[] DeserializeMovies()
        {
            if (!File.Exists(filePath))
                return new Movies[5];
            using (StreamReader sr = new StreamReader(filePath))
            {
                Movies[] deserialAccounts = JsonSerializer.Deserialize<Movies[]>(sr.ReadToEnd());
                return deserialAccounts;
            }
        }

        public static void SerializeMovies(Movies[] movie)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false))
            {
                sw.WriteLine(JsonSerializer.Serialize(movie));
            }
        }
    }
}

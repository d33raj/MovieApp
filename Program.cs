using MovieApp.Model;
using System.Security.Cryptography;
using System.Threading.Channels;

namespace MovieApp
{
    internal class Program
    {
        static Movies[] movie = new Movies[5];
        static int movieIndex = 0;
        
        static void Main(string[] args)
        {
            
            movie = FileSerializer.DeserializeMovies();
            movieIndex = MovieCount();
            while (true)
            {
                Console.WriteLine("**************************************************************");
                Console.WriteLine("Welcome to Movies App:\n" + "Select an option from below:\n"
                                  + "1. Display a Movie\n" + "2. Add Movie\n" +
                                  "3. Clear All Movies\n" + "4. Exit\n" + "Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                TasktoDo(choice);
            }
        }

        static void TasktoDo(int choice)
        {
            switch (choice)
            {
                case 1:
                    DisplayMovies();
                    break;
                case 2:
                    AddMovies();
                    break;
                case 3:
                    ClearAllMovies();
                    break;
                case 4:
                    FileSerializer.SerializeMovies(movie);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Incorrect Choice");
                    break;
            }
        }
        static int MovieCount()
        {
            int count = 0;
            foreach (var m in movie)
            {
                if (m != null)
                {
                    count++;
                }
            }
            return count;
        }

        static void DisplayMovies()
        {
            Console.WriteLine("Movies in the collection:");
            foreach (var m in movie)
            {
                if (m != null)
                {
                    Console.WriteLine($"ID: {m.MovieID}, Name: {m.MovieTitle}\n ");
                }
            }

            Console.WriteLine("Enter Movie ID: ");
            int mid = Convert.ToInt32(Console.ReadLine());

            bool found = false;
            for (int i = 0; i < movie.Length; i++)
            {
                if (movie[i] != null && movie[i].MovieID == mid)
                {
                    Console.WriteLine(movie[i]);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("No such Movie exists");
            }

        }

        static void AddMovies()
        {
            if (movieIndex < 5)
            {
                Console.WriteLine("Enter Movie ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Movie Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Movie Genre: ");
                string genre = Console.ReadLine();
                Console.WriteLine("Enter Movie Year: ");
                int year = Convert.ToInt32(Console.ReadLine());

                movie[movieIndex] = new Movies(id, name, genre, year);
                movieIndex++;
                Console.WriteLine("Movie added successfully.");
                //Console.WriteLine(movieIndex);
            }
            else
            {
                Console.WriteLine("Movie collection is full. Cannot add more movies.");
            }
        }

        static void ClearAllMovies()
        {
            for (int i = 0; i < movie.Length; i++)
            {
                movie[i] = null;
            }
            movieIndex = 0;
            Console.WriteLine("All movies cleared.");
        }

     
    }
}

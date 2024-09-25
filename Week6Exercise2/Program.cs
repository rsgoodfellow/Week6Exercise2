using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Week6Exercise2
{
    internal class Program
    {
        public class Book //Book class for books
        {
            public string Title { get; set; } // Declares Title string
            public string Author { get; set; } // Declares Author string
            public int Year { get; set; } // Declares Year int
        }

        public static void SerializeToJson(string fileName,  Book book) //method to serialize book into a json file
        {
            string jsonString = JsonConvert.SerializeObject(book, Formatting.Indented); //serializes the book and converts it to a string
            File.WriteAllText(fileName, jsonString); //writes the json string to specified file
        }

        public static Book DeserializeFromJson(string fileName) //method to deserialize json file back into book format
        {
            string jsonString = File.ReadAllText(fileName); //reads json string from file
            return JsonConvert.DeserializeObject<Book>(jsonString); //converts json string into book object
        }
        static void Main(string[] args) //main method
        {
            Book metro = new Book //creates new book
            {
                Title = "Metro 2033", //sets title
                Author = "Dmitry Glukhovsky", //sets author
                Year = 2002 //sets year 
            };

            SerializeToJson("book.json", metro); //calls method to serialize the book

            Book deserializedBook = DeserializeFromJson("book.json"); //calls method to deserialize back into a book

            Console.WriteLine($"Title: {deserializedBook.Title}"); //displays title
            Console.WriteLine($"Author: {deserializedBook.Author}"); //displays author
            Console.WriteLine($"Year: {deserializedBook.Year}"); //displays year

            Console.Read(); //lets the user read the program
        }
    }
}

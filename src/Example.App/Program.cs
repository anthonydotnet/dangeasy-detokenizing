using DangEasy.Detokenizing;
using System;
using System.Collections.Generic;

namespace Example.App
{
    class Program
    {
        static void Main(string[] args)
        {
            string tokenEnd = "%"; // must be on both sides of the item to detokenize
            string template = $"Firstname: {tokenEnd}FirstName{tokenEnd}. Age: {tokenEnd}Age{tokenEnd}. Created: {tokenEnd}Created{tokenEnd}";

            // using model
            Console.WriteLine("Using model");
            var model = new CustomModel
            {
                FirstName = "Anthony",
                Age = 39,
                Created = new DateTime(2019, 1, 1)
            };

            var result = Detokenizer.Detokenize(model, template, tokenEnd);
            Console.WriteLine(result);
            Console.WriteLine();

            // using dictionary
            Console.WriteLine("Using dictionary");
            var dictionary = new Dictionary<string, string>
            {
                { "FirstName", "Anthony" },
                { "Age", "39" },
                { "Created", new DateTime(2019, 1, 1).ToString() }
            };

            result = Detokenizer.Detokenize(dictionary, template, tokenEnd);
            Console.WriteLine(result);
            Console.WriteLine();



            // using dictionary with explicit token as part of dictionary items
            Console.WriteLine("Using dictionary with explicit token as part of dictionary items");
            dictionary = new Dictionary<string, string>
            {
                { $"{tokenEnd}FirstName{tokenEnd}", "Anthony" },
                { $"{tokenEnd}Age{tokenEnd}", "39" },
                { $"{tokenEnd}Created{tokenEnd}", new DateTime(2019, 1, 1).ToString() }
            };

            result = Detokenizer.Detokenize(dictionary, template);
            Console.WriteLine(result);


            Console.ReadLine();
        }
    }



    class CustomModel
    {
        public string FirstName { get; set; }

        public int Age { get; set; }

        public DateTime Created { get; set; }
    }
}

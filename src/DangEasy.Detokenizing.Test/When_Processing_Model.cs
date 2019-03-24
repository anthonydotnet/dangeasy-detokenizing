using System;
using System.Collections.Generic;
using Xunit;

namespace DangEasy.Detokenizing.Test
{
    public class When_Processing_Model
    {
        [Fact]
        public void Template_Is_Detokenized_With_Model()
        {
            string tokenEnd = "%%"; // must be on both sides of the item to detokenize
            string template = $"Firstname: {tokenEnd}FirstName{tokenEnd}. Age: {tokenEnd}Age{tokenEnd}. Created: {tokenEnd}Created{tokenEnd}";

            var model = new CustomModel
            {
                FirstName = "Anthony",
                Age = 39,
                Created = new DateTime(2019, 1, 1)
            };

            var result = Detokenizer.Detokenize(model, template, tokenEnd);

            var expected = $"Firstname: {model.FirstName}. Age: {model.Age}. Created: {model.Created}";

            Assert.Equal(expected, result);
        }



        [Fact]
        public void Template_Is_Detokenized_With_Dictionary()
        {
            string tokenEnd = "%%"; // must be on both sides of the item to detokenize
            string template = $"Firstname: {tokenEnd}FirstName{tokenEnd}. Age: {tokenEnd}Age{tokenEnd}. Created: {tokenEnd}Created{tokenEnd}";

            var dictionary = new Dictionary<string, string>
            {
                { "FirstName", "Anthony" },
                { "Age", "39" },
                { "Created", new DateTime(2019, 1, 1).ToString() }
            };

            var result = Detokenizer.Detokenize(dictionary, template, tokenEnd);

            var expected = $"Firstname: {dictionary["FirstName"]}. Age: {dictionary["Age"]}. Created: {dictionary["Created"]}";

            Assert.Equal(expected, result);
        }



        [Fact]
        public void Template_Is_Detokenized_With_Tokened_Dictionary()
        {
            string tokenEnd = "%%"; // must be on both sides of the item to detokenize
            string template = $"Firstname: {tokenEnd}FirstName{tokenEnd}. Age: {tokenEnd}Age{tokenEnd}. Created: {tokenEnd}Created{tokenEnd}";

            var dictionary = new Dictionary<string, string>
            {
                { $"{tokenEnd}FirstName{tokenEnd}", "Anthony" },
                { $"{tokenEnd}Age{tokenEnd}", "39" },
                { $"{tokenEnd}Created{tokenEnd}", new DateTime(2019, 1, 1).ToString() }
            };

            var result = Detokenizer.Detokenize(dictionary, template);

            var expected = $"Firstname: {dictionary[$"{tokenEnd}FirstName{tokenEnd}"]}. Age: {dictionary[$"{tokenEnd}Age{tokenEnd}"]}. Created: {dictionary[$"{tokenEnd}Created{tokenEnd}"]}";

            Assert.Equal(expected, result);
        }
    }


    class CustomModel
    {
        public string FirstName { get; set; }

        public int Age { get; set; }

        public DateTime Created { get; set; }
    }
}
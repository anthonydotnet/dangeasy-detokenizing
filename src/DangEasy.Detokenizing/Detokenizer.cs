using System.Collections.Generic;
using System.Reflection;

namespace DangEasy.Detokenizing
{
    public static class Detokenizer
    {
        public static string Detokenize<T>(T model, string template, string tokenEnd)
        {
            var properties = typeof(T).GetTypeInfo().DeclaredProperties;

            var detokenized = template;

            foreach (var p in properties)
            {
                var token = $"{tokenEnd}{p.Name}{tokenEnd}";

                detokenized = detokenized.Replace(token, p.GetValue(model).ToString());
            }

            return detokenized;
        }


        public static string Detokenize(Dictionary<string, string> pairs, string template, string tokenEnd)
        {
            var detokenized = template;

            foreach (var p in pairs)
            {
                var token = $"{tokenEnd}{p.Key}{tokenEnd}";

                detokenized = detokenized.Replace(token, p.Value);
            }

            return detokenized;
        }


        public static string Detokenize(Dictionary<string, string> pairs, string template)
        {
            var detokenized = template;

            foreach (var p in pairs)
            {
                detokenized = detokenized.Replace(p.Key, p.Value);
            }

            return detokenized;
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectConsoleApp.FilesClasses
{
    class JsonParser : IParser
    {
        public string FileType => ".json";

        public async Task<List<string>> GetValuesFromFilesAsync(List<string> files, string fieldName)
        {
            var resultList = new List<string>();

            foreach (string file in files)
            {
                resultList.AddRange(await GetValuesFromFileAsync(file, fieldName));
            }

            return resultList;
        }

        private async Task<IEnumerable<string>> GetValuesFromFileAsync(string filePath, string fieldName)
        {
            var jsonString = await File.ReadAllTextAsync(filePath);

            try
            {
                var jobj = JObject.Parse(jsonString);
                return jobj.DescendantsAndSelf()
                   .OfType<JProperty>()
                   .Where(p => p.Name.ToLower() == fieldName)
                   .Select(p => p.Value?.ToString());
            }
            catch
            {
                Console.WriteLine("Error in the file:  " + filePath);
                return Enumerable.Empty<string>();
            }
        }
    }
}

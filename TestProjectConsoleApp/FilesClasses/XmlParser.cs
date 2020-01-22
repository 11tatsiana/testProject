using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestProjectConsoleApp.FilesClasses
{
    class XmlParser: IParser
    {
        public string FileType => ".xml";

        public Task<List<string>> GetValuesFromFilesAsync(List<string> files, string fieldName)
        {
            var resultList = new List<string>();

            foreach (string file in files)
            {
                resultList.AddRange(GetValuesFromFile(file, fieldName));
            }

            return Task.FromResult(resultList);
        }
        private IEnumerable<string> GetValuesFromFile(string filePath, string tagName)
        {
            var listOfValues = new List<string>();

            try
            { 
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(filePath);
                var elementsList = xmlDocument.GetElementsByTagName(tagName);

                for (int i = 0; i < elementsList.Count; i++)
                {
                    listOfValues.Add(elementsList[i].InnerXml);
                }
            }

            catch 
            {
                Console.WriteLine("Error in the file:  " + filePath);
            }

            return listOfValues;
        }
    }
}

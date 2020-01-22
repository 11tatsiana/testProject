using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectConsoleApp
{
    class FileUtil: Validator
    {
        public IEnumerable<string> GetDirectoriesWithoutNested(string directory)
        {
            return Directory.GetDirectories(directory).AsEnumerable();
        }

        public string GetFileNameFromPath(string path)
        {
            return Path.GetFileName(path);
        }

        public List<string> GetDocumentsFromDirectoryByType(string path, string type)
        { 
            return Directory.EnumerateFiles(path, $"*{type}", SearchOption.AllDirectories).ToList();
        }

        public async Task SaveToFileAsync(string path,  IEnumerable<string> listForSave)
        {
            await File.AppendAllLinesAsync(path, listForSave);      
        }

        public void CleanDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }          
            Directory.CreateDirectory(path);
        }

    }
}

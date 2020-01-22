using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProjectConsoleApp.FilesClasses
{
    public interface IParser
    {
        public string FileType { get; }
        public Task<List<string>> GetValuesFromFilesAsync(List<string> files, string fieldName);
    }
}

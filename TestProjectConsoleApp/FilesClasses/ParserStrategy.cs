
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProjectConsoleApp.FilesClasses
{
    class ParserStrategy
    {
        private IParser _parser;

        public ParserStrategy()
        { }

        public ParserStrategy(IParser parser)
        {
            this._parser = parser;
        }

        public async Task<List<string>> GetValuesFromFilesAsync(string directory, string fieldName)
        {
            var fileUtils = new FileUtil();
            var files = fileUtils.GetDocumentsFromDirectoryByType(directory, _parser.FileType);
            return await _parser.GetValuesFromFilesAsync(files, fieldName);
        }

        public void SetStrategy(IParser parser)
        {
            this._parser = parser;
        }
    }
}

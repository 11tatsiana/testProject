using TestProjectConsoleApp.FilesClasses;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace TestProjectConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var fileUtils = new FileUtil();

            fileUtils.CleanDirectory(RunSettings.DirectoryForSave);

            foreach (string directoryPath in fileUtils.GetDirectoriesWithoutNested(RunSettings.DirectoryWithFiles))
            {
                var fileName = fileUtils.GetFileNameFromPath(directoryPath);
                var validDirectories = fileUtils
                    .GetDirectoriesWithoutNested(directoryPath)
                    .Where(directoryPath => fileUtils.IsValid(fileUtils.GetFileNameFromPath(directoryPath)));

                foreach (var directory in validDirectories)
                {
                    var fileParser = new ParserStrategy();
                    fileParser.SetStrategy(new JsonParser());
                    var titlesFromJson = await fileParser.GetValuesFromFilesAsync(directory, RunSettings.FieldName);

                    fileParser.SetStrategy(new XmlParser());
                    var titlesFromXml = await fileParser.GetValuesFromFilesAsync(directory, RunSettings.FieldName);

                    var filePath = Path.Combine(RunSettings.DirectoryForSave, fileName + ".txt");
                    await fileUtils.SaveToFileAsync(filePath, titlesFromJson.Concat(titlesFromXml));
                }
            }

        }
    }
}

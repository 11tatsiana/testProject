using System;
using System.Text.RegularExpressions;

namespace TestProjectConsoleApp
{
    public class Validator
    {
        private const string pattern = @"\b[A-Z][A-Z][\s|-][^\n]{4,8}[\s|-][0-9]{4}$";

        public bool IsValid(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
            {
                return false;
            }
              
            return Regex.Match(fileName,  pattern).Success;
        }
    }
}

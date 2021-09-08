using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FolderJiraState.Utils
{
    public class Validate
    {
        public static bool FolderName(string name)
        {
            string invalidCharacters = new(System.IO.Path.GetInvalidPathChars());
            Regex containsABadCharacter = new("[" + Regex.Escape(invalidCharacters) + "]");
            
            if (containsABadCharacter.IsMatch(name))
                return false;

            if (name.IndexOf("/") != -1)
                return false;

            return true;
        }

        public static bool FileName(string name)
        {
            string invalidCharacters = new string(System.IO.Path.GetInvalidFileNameChars());
            Regex containsABadCharacter = new("[" + Regex.Escape(invalidCharacters) + "]");

            if (containsABadCharacter.IsMatch(name))
                return false;

            return true;
        }
    }
}

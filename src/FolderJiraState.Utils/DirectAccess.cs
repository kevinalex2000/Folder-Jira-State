using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderJiraState.Utils
{
    public class DirectAccess
    {
        public static void CreateAccessToInternet(string directory, string url, string name)
        {
            using (StreamWriter writer = new StreamWriter(directory + "\\"+ name + ".url"))
            {
                writer.WriteLine("[InternetShortcut]");
                writer.WriteLine("URL=" + url);
                writer.Flush();
            }
        }
    }
}

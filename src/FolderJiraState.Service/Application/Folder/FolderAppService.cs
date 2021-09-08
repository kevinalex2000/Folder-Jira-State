using FolderJiraState.Service.Application.Folder;
using FolderJiraState.Utils;
using System;
using System.Diagnostics;
using System.IO;

namespace FolderJiraState.Service
{
    public class FolderAppService : IFolderAppService
    {
        public bool ChangeIcon(string directory, string iconName)
        {
            string pathIcon = 
                Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) 
                + "\\Resources\\" + iconName + ".ico";

            if (!Directory.Exists(directory))
                return false;
            if (!File.Exists(pathIcon))
                return false;

            FolderCustomize.ChangeIcon(directory, pathIcon);

            return true;
        }
    }
}

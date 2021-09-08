using System;
using Microsoft.Win32;
using System.IO;
using FolderJiraState.Service;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            // TEST
            //args = new string[2];
            //args[0] = @"D:\Users\Equipo\Proyectos\Folder Jira State\Test\Prueba";
            //args[1] = "cerrado";

            if (args != null && args.Length >= 2)
            {
                string path = args[0];
                string iconName = args[1];

                FolderAppService folderAppService = new FolderAppService();
                folderAppService.ChangeIcon(path, iconName);
            }
        }
    }
}
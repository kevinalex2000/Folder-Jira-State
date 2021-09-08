using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderJiraState.Service.Application.Folder
{
    public interface IFolderAppService
    {
        bool ChangeIcon(string directory, string iconName);
    }
}

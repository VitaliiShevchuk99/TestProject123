using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.Helpers
{
    static class DirectoryTreeHelper
    {
        public static FolderStructure CreateTree(DirectoryInfo path)
        {
            var folderStructure = new FolderStructure();
            folderStructure.FolderName = path.Name;
            foreach (var folder in path.GetDirectories())
            {
                DirectoryInfo info = new DirectoryInfo(folder.FullName);
                folderStructure.SubFolders.Add(CreateTree(info));
            }

            foreach (var file in path.GetFiles())
            {
                FileStructure fileStructure = new FileStructure();
                fileStructure.FileName = file.Name;
                fileStructure.Content = File.ReadAllBytes(file.FullName);
                folderStructure.Files.Add(fileStructure);
            }

            return folderStructure;
        }
    }
}

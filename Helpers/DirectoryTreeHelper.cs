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
        public static SerializationTree.FolderStructure CreateTree(DirectoryInfo path)
        {
            var folderStructure = new SerializationTree.FolderStructure();
            folderStructure.FolderName = path.Name;
            foreach (var folder in path.GetDirectories())
            {
                //SerializationTree.FolderStructure folderStructure = new SerializationTree.FolderStructure();

                DirectoryInfo info = new DirectoryInfo(folder.FullName);
                folderStructure.SubFolders.Add(CreateTree(info));
            }

            foreach (var fileLeaf in path.GetFiles())
            {
                SerializationTree.FileStructure fileStructure = new SerializationTree.FileStructure();
                fileStructure.FileName = fileLeaf.Name;
                fileStructure.Content = File.ReadAllBytes(fileLeaf.FullName);
                folderStructure.Files.Add(fileStructure);
            }
            return folderStructure;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TestProj.Helpers
{
    static class SerializationHelper
    {
        public static void SerializeFolder(SerializationTree.FolderStructure folder, string filename)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
            {
                binaryFormatter.Serialize(stream, folder);
            }
        }

        public static void DeserializeFolder(string filename, string pathToPlace)
        {
            SerializationTree.FolderStructure folder;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                folder = (SerializationTree.FolderStructure)binaryFormatter.Deserialize(stream);
                //directoryInfo = new DirectoryInfo(folder.ToString());
            }
            DirectoryInfo directoryToReplace = new DirectoryInfo(pathToPlace);
            ReplaceDeserializedFolder(folder, directoryToReplace);
        }

        private static void ReplaceDeserializedFolder(SerializationTree.FolderStructure folder, DirectoryInfo directoryInfo)
        {
            foreach (var file in folder.Files)
            {
                var filePath = Path.Combine(directoryInfo.FullName, file.FileName);
                File.Create(filePath).Close();
                File.WriteAllBytes(filePath, file.Content);


            }

            foreach (var directory in folder.SubFolders)
            {
                DirectoryInfo info = directoryInfo.CreateSubdirectory(directory.FolderName);
                ReplaceDeserializedFolder(directory, info);
            }
        }
    }
}

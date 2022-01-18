
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.Helpers
{
    class SerializationTree
    {
        [Serializable]
        public class FolderStructure
        {
            public string FolderName;
            public List<FolderStructure> SubFolders = new List<FolderStructure>();
            public List<FileStructure> Files = new List<FileStructure>();
        }

        [Serializable]
        public class FileStructure
        {
            public string FileName;
            public byte[] Content;
        }
    }
}
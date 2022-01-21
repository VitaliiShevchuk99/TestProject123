
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj.Helpers
{
    [Serializable]
    public class FolderStructure
    {
        public string FolderName;
        public List<FolderStructure> SubFolders = new List<FolderStructure>();
        public List<FileRepresentation> Files = new List<FileRepresentation>();
    }

    [Serializable]
    public class FileRepresentation
    {
        public string FileName;
        public byte[] Content;
    }
}
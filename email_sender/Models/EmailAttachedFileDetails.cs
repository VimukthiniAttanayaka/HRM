using System;
using System.Collections.Generic;

namespace email_sender.Models
{
    public class EmailAttachedFileDetails
    {
        public List<FileObject> FileObjectList { get; set; }
        public bool HasFilesAttached { get; set; } = false;
    }

    public class FileObject
    {
        public byte[] FileBinary { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
    }

}

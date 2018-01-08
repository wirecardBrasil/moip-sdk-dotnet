using System;
using System.IO;

namespace Moip.Http.Client
{
    public class FileStreamInfo
    {
        public Stream FileStream { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }

        public FileStreamInfo(Stream stream, string fileName = null, string contentType = null)
        {
            FileStream = stream;
            FileName = fileName;
            ContentType = contentType;
        }
    }
}

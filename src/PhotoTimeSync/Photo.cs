using ExifLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    public class Photo
    {
        public IFolderPathProvider ParentPath { get; private set; }
        public string fileName { get; private set; }
        public ImageFile ExifImage 
        {
            get
            {
                if (_exifImage == null)
                {
                    _exifImage = ImageFile.FromFile(FullPath);
                    LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "Photo", "ExifImage", "Property extraction done", "File: {0}", this.FullPath);
                }
                else
                {
                    LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "Photo", "ExifImage", "Reusing existing property", "File: {0}", this.FullPath);
                }
                return _exifImage;
            }
        }
        private ImageFile _exifImage;

        public string FullPath
        {
            get
            {
                return Path.Combine(ParentPath.FolderPath(), fileName);
            }
        }

        public Photo(IFolderPathProvider parentPath, string fileName)
        {
            ParentPath = parentPath;
            this.fileName = fileName;
        }

        private DateTime _initialDateTime;
        public DateTime InitialDateTime
        {
            get
            {
                if (_initialDateTime == new DateTime())
                {
                    ImageFile imageF = ExifImage;
                    if (!imageF.Properties.ContainsKey(ExifTag.DateTime))
                    {
                        if (!imageF.Properties.ContainsKey(ExifTag.DateTimeOriginal))
                        {
                            throw new Exception(String.Format("Both DateTime and DateTimeOriginal are null. Cannot process the photo '{0}'", FullPath));
                        }
                        else
                        {
                            _initialDateTime = (DateTime)imageF.Properties[ExifTag.DateTimeOriginal].Value;
                            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "Photo", "InitialDateTime", "Computed based on DateTimeOriginal", "File: {0}, Value: {1}", this.FullPath, _initialDateTime);
                        }
                    }
                    else
                    {
                        _initialDateTime = (DateTime)imageF.Properties[ExifTag.DateTime].Value;
                        LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "Photo", "InitialDateTime", "Computed based on DateTime", "File: {0}, Value: {1}", this.FullPath, _initialDateTime);
                    }
                }
                return _initialDateTime;
            }
        }
    }
}

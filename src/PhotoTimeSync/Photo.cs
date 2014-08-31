using ExifLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
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
                return ImageFile.FromFile(FullPath);
            }
        }

        public Image Thumbnail
        {
            get
            {
                ImageFile exif = this.ExifImage;
                ExifProperty orientProp = exif.Properties.Where(p => p.Key == ExifTag.Orientation).Select(p => p.Value).SingleOrDefault();
                Orientation orient;
                if (orientProp == null)
                    orient = Orientation.Normal;
                else
                    orient = (Orientation)orientProp.Value;
                Image thumb;
                if (exif.Thumbnail != null)
                {
                    thumb = exif.Thumbnail.ToImage();
                }
                else
                {
                    thumb = Image.FromFile(FullPath);
                }
                if (orient != Orientation.Normal)
                {
                    //we need to rotate/flip
                    //check the orientation and rotate/flip the image
                    switch (orient)
                    {
                        case Orientation.RotatedLeft:
                            thumb.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        case Orientation.RotatedRight:
                            thumb.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case Orientation.RotatedRightAndMirroredVertically:
                            thumb.RotateFlip(RotateFlipType.Rotate90FlipXY);
                            break;
                        case Orientation.MirroredHorizontally:
                            thumb.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            break;
                        case Orientation.Rotated180:
                            thumb.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case Orientation.RotatedLeftAndMirroredVertically:
                            thumb.RotateFlip(RotateFlipType.Rotate270FlipXY);
                            break;
                        case Orientation.MirroredVertically:
                            thumb.RotateFlip(RotateFlipType.RotateNoneFlipY);
                            break;

                    }

                }
                return thumb;
            }

        }

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
            _initialDateTimeRead = false;
        }

        private DateTime _initialDateTime;
        private bool _initialDateTimeRead;
        public DateTime InitialDateTime
        {
            get
            {
                if (!_initialDateTimeRead)
                {
                    _initialDateTimeRead = true;
                    ImageFile imageF = ExifImage;
                    if (imageF.Properties.ContainsKey(ExifTag.DateTimeOriginal))
                    {
                        LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "Photo", "InitialDateTime", "Info -", "File: {0}, DateTimeOriginal: {1}", this.fileName, (DateTime)imageF.Properties[ExifTag.DateTimeOriginal].Value);
                    }
                    if (imageF.Properties.ContainsKey(ExifTag.DateTime))
                    {
                        LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "Photo", "InitialDateTime", "Info -", "File: {0}, DateTime: {1}", this.fileName, (DateTime)imageF.Properties[ExifTag.DateTime].Value);
                    }
                    if (imageF.Properties.ContainsKey(ExifTag.DateTimeDigitized))
                    {
                        LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "Photo", "InitialDateTime", "Info -", "File: {0}, DateTimeDigitized: {1}", this.fileName, (DateTime)imageF.Properties[ExifTag.DateTimeDigitized].Value);
                    }
                    if (!imageF.Properties.ContainsKey(ExifTag.DateTimeOriginal))
                    {
                        if (!imageF.Properties.ContainsKey(ExifTag.DateTime))
                        {
                            throw new Exception(String.Format("Both DateTime and DateTimeOriginal are null. Cannot process the photo '{0}'", FullPath));
                        }
                        else
                        {
                            _initialDateTime = (DateTime)imageF.Properties[ExifTag.DateTime].Value;
                            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "Photo", "InitialDateTime", "Computed based on DateTime", "File: {0}, Value: {1}", this.FullPath, _initialDateTime);
                        }
                    }
                    else
                    {
                        _initialDateTime = (DateTime)imageF.Properties[ExifTag.DateTimeOriginal].Value;
                        LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "Photo", "InitialDateTime", "Computed based on DateTimeOriginal", "File: {0}, Value: {1}", this.FullPath, _initialDateTime);
                    }
                }
                return _initialDateTime;
            }
        }

        public bool AlreadyProcessedPreviously
        {
            get
            {
                char[] fileNameChars = fileName.ToCharArray();
                return (fileNameChars[8] == '_') && (fileNameChars[15] == '_');
            }
        }

    }
}

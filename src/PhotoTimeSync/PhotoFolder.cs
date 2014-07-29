using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    public class PhotoFolder : IFolderPathProvider
    {
        public IFolderPathProvider ParentPath { get; private set; }
        public string FolderName { get; private set; }
        public List<Photo> Photos { get; private set; }
        public TimeSpan Correction { get; set; }
        public bool IsSynced { get; set; }

        public PhotoFolder(IFolderPathProvider parentPath, string folderName)
        {
            ParentPath = parentPath;
            FolderName = folderName;
            Photos = new List<Photo>();
            Correction = TimeSpan.Zero;
            IsSynced = false;
        }

        public string FolderPath()
        {
            return Path.Combine(ParentPath.FolderPath(), FolderName);
        }

        public Photo AddPhoto(string file)
        {
            string fileShortName = Path.GetFileName(file);
            Photo alreadyHere = Photos.Where(p => p.fileName == fileShortName).FirstOrDefault();
            if (alreadyHere == null)
            {
                Photo photo = new Photo(this, fileShortName);
                this.Photos.Add(photo);
                return photo;
            }
            else
            {
                return alreadyHere;
            }
        }

        public string CorrectionToString()
        {
            StringBuilder correctionSB = new StringBuilder();
            if (Correction.TotalSeconds == 0)
                return "no correction";
            if (Correction.Days != 0)
            {
                correctionSB.Append(string.Format("{0} day(s) ", Correction.Days));
            }
            if (Correction.Hours != 0)
            {
                correctionSB.Append(string.Format("{0} hour(s) ", Correction.Hours));
            }
            if (Correction.Minutes != 0)
            {
                correctionSB.Append(string.Format("{0} minute(s) ", Correction.Minutes));
            }
            if (Correction.Seconds != 0)
            {
                correctionSB.Append(string.Format("{0} second(s) ", Correction.Seconds));
            }
            return correctionSB.ToString();
        }
    }
}

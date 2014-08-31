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
        public string PicsPrefix { get; set; }
        public List<Photo> Photos { get; private set; }
        public TimeSpan Correction { get; set; }
        public bool IsSynced { get; set; }

        public PhotoFolder(IFolderPathProvider parentPath, string folderName)
        {
            ParentPath = parentPath;
            FolderName = folderName;
            PicsPrefix = folderName.Replace('_', '-'); // Do not use underscore in pics prefix, they are verbotten for proper multiple time operation of rename
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
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "PhotoFolder", "AddPhoto", "Adding new photo in folder", "Folder: {0}, File: {1}", this.FolderPath(), file);
            string fileShortName = Path.GetFileName(file);
            Photo alreadyHere = Photos.Where(p => p.fileName == fileShortName).FirstOrDefault();
            if (alreadyHere == null)
            {
                Photo photo = new Photo(this, fileShortName);
                this.Photos.Add(photo);
                LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "PhotoFolder", "AddPhoto", "Photo added successfully", "Folder: {0}, File: {1}", this.FolderPath(), file);
                return photo;
            }
            else
            {
                LogManager.Log(System.Diagnostics.TraceLevel.Warning, "PhotoFolder", "AddPhoto", "Photo already present in folder (usually normal if filesystem is not case sensitive)", "Folder: {0}, File: {1}", this.FolderPath(), file);
                return alreadyHere;
            }
        }

        public string CorrectionToString()
        {
            StringBuilder correctionSB = new StringBuilder();
            if (Correction.TotalSeconds == 0)
                return Labels.Labels.Generic_NoCorrection;
            if (Correction.Days != 0)
            {
                correctionSB.Append(string.Format("{0} " + Labels.Labels.Generic_Day  + " ", Correction.Days));
            }
            if (Correction.Hours != 0)
            {
                correctionSB.Append(string.Format("{0} " + Labels.Labels.Generic_Hour + " ", Correction.Hours));
            }
            if (Correction.Minutes != 0)
            {
                correctionSB.Append(string.Format("{0} " + Labels.Labels.Generic_Minute + " ", Correction.Minutes));
            }
            if (Correction.Seconds != 0)
            {
                correctionSB.Append(string.Format("{0} " + Labels.Labels.Generic_Second + " ", Correction.Seconds));
            }
            return correctionSB.ToString();
        }
    }
}

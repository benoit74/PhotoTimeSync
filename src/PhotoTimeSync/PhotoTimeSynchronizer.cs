using ExifLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoTimeSync
{
    public class PhotoTimeSynchronizer : IFolderPathProvider
    {

        public string ParentFolder { get; set; }
        public bool FolderIsOK { get; set; }
        public bool FolderHasBeenChecked { get; set; }
        public List<PhotoFolder> Folders { get; private set; }
        public PhotoFolder CurrentPendingFolder { get; set; }
        public PhotoFolder CurrentSyncFolder { get; set; }

        public PhotoTimeSynchronizer()
        {
            FolderIsOK = false;
            FolderHasBeenChecked = false;
            Folders = new List<PhotoFolder>();
            CurrentPendingFolder = null;
            CurrentSyncFolder = null;
        }
        
        public void CheckAndExploreFolder(StringBuilder infos)
        {
            FolderIsOK = CheckFolder(infos) && ExploreFolder(infos);
        }

        private bool CheckFolder(StringBuilder infos)
        {
            FolderHasBeenChecked = true;
            infos.Append(string.Format("Checking that folder '{0}' exists ...", ParentFolder));
            if (!System.IO.Directory.Exists(ParentFolder))
            {
                infos.AppendLine(" NOK");
                infos.AppendLine("Selected folder does not exist.");
                return false;
            }
            infos.AppendLine(" OK");
            return true;
        }

        private bool ExploreFolder(StringBuilder infos)
        {
            infos.AppendLine(string.Format("Exploring folder '{0}'", ParentFolder));
            string[] childDirectories = Directory.GetDirectories(ParentFolder);
            if (childDirectories.Count() < 2)
            {
                infos.AppendLine("ERROR: At least 2 subfolders representing the collections to synchronise must be present inside the selected folder");
                infos.AppendLine("Exploring folder NOK");
                return false;
            }
            infos.AppendLine(string.Format("\t{0} subfolders found", childDirectories.Count()));
            Folders.Clear();
            foreach (string childDirectory in childDirectories)
            {
                string childDirectoryShortName = Path.GetFileName(childDirectory);

                PhotoFolder childFolder = new PhotoFolder(this, childDirectoryShortName);
                
                infos.AppendLine(string.Format("Exploring subfolder '{0}'", childDirectoryShortName));

                // Check if there is subsubfolders which will be ignored
                string[] subChildDirectories = Directory.GetDirectories(childDirectory);
                if (subChildDirectories.Count() > 0)
                    infos.AppendLine(string.Format("\tWARNING: found {0} subsubfolders in subfolder '{1}', they will not be processed", subChildDirectories.Count(), childDirectoryShortName));

                // List jpg files
                string[] extensions = new string[] { "*.jpg", "*.jpeg", "*.JPG", "*.JPEG" };
                foreach(string extension in extensions)
                {
                    string[] jpgFiles = Directory.GetFiles(childDirectory, extension, SearchOption.TopDirectoryOnly);
                    foreach (string file in jpgFiles)
                    {
                        Photo photo = childFolder.AddPhoto(file);
                        try
                        {
                            DateTime dateAvailable = photo.InitialDateTime;
                        }
                        catch (Exception)
                        {
                                childFolder.Photos.Remove(photo);
                                infos.AppendLine(string.Format("\tWARNING: Photo '' has been ignored since it does not have exif dateTime not dateTimeOriginal", file));
                        }
                    }
                }
                infos.Append(string.Format("\t{0} photos found in subfolder '{1}'.", childFolder.Photos.Count(), childDirectoryShortName));
                if (childFolder.Photos.Count() > 0)
                {
                    infos.AppendLine();
                    Folders.Add(childFolder);
                }
                else
                {
                    infos.AppendLine(string.Format(" Subfolder will be ignored.", childFolder.Photos.Count(), childDirectoryShortName));
                }

            }
            if (Folders.Count() < 2)
            {
                infos.AppendLine("ERROR: At least 2 subfolders representing the collections to synchronise must be present inside the selected folder with photos in them");
                infos.AppendLine("Exploring folder NOK");
                return false;
            }
            // To be continued with building of JPG files list
            infos.AppendLine("Exploring folder OK");
            return true;
        }

        public string FolderPath()
        {
            return ParentFolder;
        }
    }
}

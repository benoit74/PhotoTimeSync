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
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "PhotoTimeSynchronizer", "CheckFolder", "Start", "Folder: {0}", ParentFolder);
            FolderHasBeenChecked = true;
            infos.Append(string.Format(Labels.Labels.CheckFolder_CheckingFolderExists, ParentFolder));
            if (!System.IO.Directory.Exists(ParentFolder))
            {
                LogManager.Log(System.Diagnostics.TraceLevel.Warning, "PhotoTimeSynchronizer", "CheckFolder", "Folder does not exists", "Folder: {0}", ParentFolder);
                infos.AppendLine(" " + Labels.Labels.Generic_NOK);
                infos.AppendLine(Labels.Labels.CheckFolder_SelectedFolderNotExist);
                return false;
            }
            infos.AppendLine(" " + Labels.Labels.Generic_OK);
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "PhotoTimeSynchronizer", "CheckFolder", "OK", "Folder: {0}", ParentFolder);
            return true;
        }

        private bool ExploreFolder(StringBuilder infos)
        {
            LogManager.Log(System.Diagnostics.TraceLevel.Info, "PhotoTimeSynchronizer", "ExploreFolder", "Start", "Folder: {0}", ParentFolder);
            infos.AppendLine(string.Format(Labels.Labels.ExploreFolder_ExploringMainFolder, ParentFolder));
            string[] childDirectories = Directory.GetDirectories(ParentFolder);
            if (childDirectories.Count() < 2)
            {
                LogManager.Log(System.Diagnostics.TraceLevel.Warning, "PhotoTimeSynchronizer", "ExploreFolder", "Not enough subfolders", "NbFoldersFound: {0}", childDirectories.Count());
                infos.AppendLine(Labels.Labels.ExploreFolder_ErrorExplanationInsufficientFolders);
                infos.AppendLine(Labels.Labels.ExploreFolder_ErrorConclusion);
                return false;
            }
            infos.AppendLine(string.Format("\t" + Labels.Labels.ExploreFolder_SubFolderCount, childDirectories.Count()));
            Folders.Clear();
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "PhotoTimeSynchronizer", "ExploreFolder", "", "{0} subfolders found",  childDirectories.Count());
            foreach (string childDirectory in childDirectories)
            {
                string childDirectoryShortName = Path.GetFileName(childDirectory);

                PhotoFolder childFolder = new PhotoFolder(this, childDirectoryShortName);

                infos.AppendLine(string.Format(Labels.Labels.ExploreFolder_ExploringSubFolder, childDirectoryShortName));

                // Check if there is subsubfolders which will be ignored
                string[] subChildDirectories = Directory.GetDirectories(childDirectory);
                if (subChildDirectories.Count() > 0)
                {
                    infos.AppendLine(string.Format("\t" + Labels.Labels.ExploreFolder_SubSubFolderIgnored, subChildDirectories.Count(), childDirectoryShortName));
                    LogManager.Log(System.Diagnostics.TraceLevel.Warning, "PhotoTimeSynchronizer", "ExploreFolder", "Subsubfolders found", "found {0} subsubfolders in subfolder '{1}', they will not be processed", subChildDirectories.Count(), childDirectoryShortName);
                }

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
                            infos.AppendLine(string.Format("\t" + Labels.Labels.ExploreFolder_PhotoIgnored, file));
                            LogManager.Log(System.Diagnostics.TraceLevel.Warning, "PhotoTimeSynchronizer", "ExploreFolder", "Photo ignored", "Folder: {0}, Photo '{1}' has been ignored since it does not have exif dateTime not dateTimeOriginal", ParentFolder, file);
                        }
                    }
                }
                infos.Append(string.Format("\t" + Labels.Labels.ExploreFolder_PhotosCount, childFolder.Photos.Count(), childDirectoryShortName));
                LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "PhotoTimeSynchronizer", "ExploreFolder", "", "{0} photos found in subfolder '{1}'", childFolder.Photos.Count(), childDirectoryShortName);
                if (childFolder.Photos.Count() > 0)
                {
                    infos.AppendLine();
                    Folders.Add(childFolder);
                }
                else
                {
                    infos.AppendLine(" " + Labels.Labels.ExploreFolder_SubFolderIgnored);
                    LogManager.Log(System.Diagnostics.TraceLevel.Warning, "PhotoTimeSynchronizer", "ExploreFolder", "No photo in subfolder '{0}'. It will be ignored.", "", childDirectoryShortName);
                }

            }
            if (Folders.Count() < 2)
            {
                LogManager.Log(System.Diagnostics.TraceLevel.Warning, "PhotoTimeSynchronizer", "ExploreFolder", "Not enough valid subfolders", "NbFoldersFound: {0}", Folders.Count());
                infos.AppendLine(Labels.Labels.ExploreFolder_ErrorExplanationInsufficientPhotos);
                infos.AppendLine(Labels.Labels.ExploreFolder_ErrorConclusion);
                return false;
            }
            // To be continued with building of JPG files list
            infos.AppendLine(Labels.Labels.ExploreFolder_OKConclusion);
            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "PhotoTimeSynchronizer", "ExploreFolder", "OK", "");
            return true;
        }

        public string FolderPath()
        {
            return ParentFolder;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace PhotoTimeSync
{
    public class RotatingFileLogger : ILogger
    {

        const string ArchiveSubDir = "archive";

        public string BaseFilePath { get; private set; }
        public int MaxLogEntriesPendingInMemory { get; set; }
        public int NbRotatingFiles { get; set; }
        public long EachFileMaxSize { get; set; }

        private BackgroundWorker bgdW;

        private Queue<LogEntry> Logs = new Queue<LogEntry>();
        private object Lock = new object();

        private DateTime NextLogOfQueueContent;

        public RotatingFileLogger(string BaseFilePath, int NbRotatingFiles, long EachFileMaxSize, int MaxLogEntriesPendingInMemory)
        {
            if (BaseFilePath.Contains("%%CommonApplicationData%%"))
            {
                BaseFilePath = BaseFilePath.Replace("%%CommonApplicationData%%", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            }
            if (BaseFilePath.Contains("%%ApplicationData%%"))
            {
                BaseFilePath = BaseFilePath.Replace("%%ApplicationData%%", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }
            if (BaseFilePath.Contains("%%LocalApplicationData%%"))
            {
                BaseFilePath = BaseFilePath.Replace("%%LocalApplicationData%%", Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            }
            string folderName = new FileInfo(BaseFilePath).DirectoryName;
            if (!System.IO.Directory.Exists(folderName))
            {
                System.IO.Directory.CreateDirectory(folderName);
            }
            this.BaseFilePath = BaseFilePath;
            this.NbRotatingFiles = NbRotatingFiles;
            this.EachFileMaxSize = EachFileMaxSize;
            this.MaxLogEntriesPendingInMemory = MaxLogEntriesPendingInMemory;
            bgdW = new BackgroundWorker();
            bgdW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgdW_DoWork);
            bgdW.RunWorkerAsync();
        }

        public void Log(DateTime date, int? customerID, int? customerUserID, System.Diagnostics.TraceLevel level, string category, string step, string source, string message, string data)
        {

            LogEntry entry = new LogEntry()
            {
                date = date,
                customerID = customerID,
                customerUserID = customerUserID,
                level = level,
                category = category,
                step = step,
                source = source,
                message = message,
                data = data,
            };

            bool logDone = false;

            while (!logDone)
            {
                logDone = TryToLog(entry);
                if (!logDone)
                {
                    LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "RotatingFileLogger", "Generic", "Throttling, producers are too fast", "");
                    System.Threading.Thread.Sleep(10);
                }
            }

        }

        private bool TryToLog(LogEntry entry)
        {
            // Lock is made around all those operations to 
            // ensure that two threads trying to log at the same
            // time will not result in abnormal behavior
            lock (Lock)
            {
                int nbLogsPending = Logs.Count();
                if (nbLogsPending >= MaxLogEntriesPendingInMemory)
                    return false;
                Logs.Enqueue(entry);
                return true;
            }
        }

        private void bgdW_DoWork(object sender, DoWorkEventArgs e)
        {
            // Do not access the BackgroundWorker reference directly. 
            // Instead, use the reference provided by the sender parameter.
            BackgroundWorker bw = sender as BackgroundWorker;

            LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "RotatingFileLogger", "Generic", "BgdWorker started", "");

            NextLogOfQueueContent = DateTime.Now + new TimeSpan(0, 0, 1);

            int currentPause = 1;

            while (!bw.CancellationPending || Logs.Count > 0)
            {

                while (Logs.Count > 0)
                {
                    LogEntry currentLog;

                    // Lock is made only around dequeuing since
                    // we want to be able to enqueue as fast as possible
                    lock (Lock)
                    {
                        currentLog = Logs.Dequeue();
                    }

                    LogAndRotate(string.Format("{0} [{1}] [{2}] [{3}] [{4}] {5} {6}",
                        currentLog.date, currentLog.source, currentLog.category, currentLog.step,
                        currentLog.level.ToString().ToUpper(), currentLog.message, currentLog.data));

                    // Specific code used to periodically log queue content
                    if (DateTime.Now > NextLogOfQueueContent)
                    {
                        LogManager.Log(System.Diagnostics.TraceLevel.Verbose, "RotatingFileLogger", "QueueContent", "Status:", "{0} messages in queue", Logs.Count);
                        NextLogOfQueueContent = DateTime.Now + new TimeSpan(0, 0, 1);
                    }

                }

                if (!bw.CancellationPending)
                {
                    // Sleep a bit while waiting for new logs to process
                    System.Threading.Thread.Sleep(currentPause);

                    if (Logs.Count == 0)
                    {
                        // If there is still no more log after current pause, we can pause even longer
                        // but maximum is 128 millisecs (we pause by power of 2)
                        currentPause = Math.Min(128, currentPause * 2);
                    }
                    else if (Logs.Count > MaxLogEntriesPendingInMemory)
                    {
                        // If after current pause, we have reached our maximum, we should take a shorter
                        // pause next time, but a minimum pause of 1ms is needed, otherwise we will
                        // use the whole CPU available for looking if there is something to log
                        currentPause = Math.Max(1, currentPause / 2);
                    }
                }

            }

            // If the operation was canceled by the user,  
            // set the DoWorkEventArgs.Cancel property to true. 
            if (bw.CancellationPending)
            {
                e.Cancel = true;
            }

        }

        /// <summary>
        /// Get name of log file with index <paramref name="index"/> (1 = current log file)
        /// The name is composed by replacing the last character with the index.
        /// </summary>
        /// <param name="index">Index of filename to build</param>
        /// <returns></returns>
        private string IndexerNom(int index)
        {
            if (index <= 1)
                return BaseFilePath;
            else
                return string.Format("{0}{1}", BaseFilePath.Substring(0, BaseFilePath.Length - 1), index - 1);
        }

        /// <summary>
        /// Log file shift.
        /// The oldest log file is deleted (or archived if archive path exist).
        /// The other log files are renamed by incrementing the file name index.
        /// </summary>
        private void RotateFilesAndArchive()
        {
            string archive_path;
            string archive_file_path;

            // Logs archiving...
            // Check whether an archive folder exist
            // If exists, archive older file before its removal
            archive_path = Path.Combine(Path.GetDirectoryName(BaseFilePath), ArchiveSubDir);

            if (Directory.Exists(archive_path))
            {
                archive_file_path = Path.Combine(
                    archive_path,
                    string.Format("{0}_{1}.log", Path.GetFileNameWithoutExtension(BaseFilePath), DateTime.Now.ToString("yyyyMMddHHmmss")));
                File.Copy(IndexerNom(NbRotatingFiles), archive_file_path);
            }

            //Logs cycling...
            File.Delete(IndexerNom(NbRotatingFiles));
            for (int i = NbRotatingFiles - 1; i >= 1; i--)
            {
                if (File.Exists(IndexerNom(i)))
                    File.Move(IndexerNom(i), IndexerNom(i + 1));
            }

        }

        /// <summary>
        /// Logs the message in the log file and rotate files if needed
        /// </summary>
        /// <param name="text"></param>
        public void LogAndRotate(string text)
        {
            File.AppendAllText(BaseFilePath, text + Environment.NewLine);
            long size = (new FileInfo(BaseFilePath)).Length;
            if ((size > EachFileMaxSize) && (EachFileMaxSize > 0))
                RotateFilesAndArchive();
        }

    }
}

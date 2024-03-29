﻿using System;
using System.Collections.Generic;
using System.IO;
using Backups.Client.Services;
using Backups.Entities;
using Backups.Entities.JobObjects;
using Backups.Entities.Storages;
using Backups.Interfaces;
using Backups.Services;
using Backups.Tools;
using BackupsExtra.Entities;
using BackupsExtra.Services;

namespace BackupsExtra
{
    internal class Program
    {
        private static void Main()
        {
            string filePath1 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Test1.txt";
            string filePath2 = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Test2.txt";

            File.Create(filePath1).Close();
            File.Create(filePath2).Close();
            Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Test1");
            Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\Test2");

            IJobObject jobObject = new FilesJobObject(new List<string> { filePath1 });
            var archiveService1 = new ServerArchiveService(new SplitZipArchiver(), "127.0.0.1", 8888);
            var backupJob1 = new BackupJob(jobObject, archiveService1, new FileLogger("log.txt", DateTime.Now));

            backupJob1.CreateRestorePoint(
                "Test 1",
                new DirectoryStorage(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Test1"));

            backupJob1.JobObject.AddFile(filePath2);
            backupJob1.CreateRestorePoint(
                "Test 2",
                new DirectoryStorage(
                    Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Test2"));

            var backupJobSerialize = new SerializeBackupJob();

            backupJobSerialize.Serialize(backupJob1, "cfg");
            BackupJob backupJob2 = backupJobSerialize.Deserialize("cfg");

            var restorePointsControl = new RestorePointsControl(new RestorePointsControlCounter(1));
            restorePointsControl.MergeExtraRestorePoints(backupJob2);

            var localRestore = new LocalRestore(backupJob2, new FileLogger("log.txt"));
            localRestore.Restore(backupJob2.RestorePoints[0]);

            File.Delete(filePath1);
            File.Delete(filePath2);
        }
    }
}
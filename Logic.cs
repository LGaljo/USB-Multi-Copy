using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace USB_Multi_Copy
{
    class Logic
    {
        public void Start(Dictionary<String, Boolean> driveLetters, String label, String fileSystem, String sourcePath)
        {
            foreach (KeyValuePair<String, Boolean> obj in driveLetters)
            {
                if (obj.Value == true)
                {
                    if (Directory.Exists(obj.Key + ":"))
                    {
                        FormatDrive(fileSystem, obj.Key, label);
                        Task.Run(() => FileSystem.CopyDirectory(sourcePath, obj.Key + ":", UIOption.AllDialogs));
                    }
                    else
                    {
                        Task.Run(() => System.Windows.MessageBox.Show("Drive " + obj.Key + " doesn't exist", "Abort"));
                    }
                }
            }
        }

        private void FormatDrive(String fileSystem, String driveLetter, String label)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.WorkingDirectory = @"C:\";
            process.StartInfo.Arguments = "/C echo \\n | format " + driveLetter + ": /fs:" + fileSystem + " /q /v:" + label + " && exit";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.WaitForExit();
        }
    }
}

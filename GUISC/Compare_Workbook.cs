﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace GUISC
{
    public partial class Compare
    {
        public int Compare_Workbook(string org_filepath, string conv_filepath)
        {
            // Use Beyond Compare 4 command line for comparison
            Process app = new Process();
            string? dir = null;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // If app is run on Windows
            {
                dir = Environment.GetEnvironmentVariable("BeyondCompare");
            }
            if (dir != null)
            {
                app.StartInfo.FileName = dir;
            }
            else
            {
                app.StartInfo.FileName = "C:\\Program Files\\Beyond Compare 4\\BCompare.exe";
            }
            app.StartInfo.Arguments = $"\"{org_filepath}\" \"{conv_filepath}\" /silent /qc=<crc> /ro";
            app.Start();
            app.WaitForExit();
            int return_code = app.ExitCode;
            app.Close();
            return return_code;
        }
    }
}
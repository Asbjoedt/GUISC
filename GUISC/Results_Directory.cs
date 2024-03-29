﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUISC
{
    public partial class Results
    {
        // Create public data types
        public static string Results_Directory = "";
        public static string CSV_filepath = "";

        // Generate date to use in name of new directory
        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy.MM.dd");
        }
        public string dateStamp = GetTimestamp(DateTime.Now);

        // Create name for new results directory
        public string Create_Results_Directory(string outputdir)
        {
            // Identify available name for results directory
            int results_directory_number = 1;
            Results_Directory = outputdir + "\\CLISC_" + dateStamp;
            while (Directory.Exists(Results_Directory) || File.Exists(Results_Directory + ".zip"))
            {
                results_directory_number++;
                Results_Directory = outputdir + "\\CLISC_" + dateStamp + "_" + results_directory_number;
            }
            // Create results directory
            DirectoryInfo OutputDir = Directory.CreateDirectory(Results_Directory);

            return Results_Directory;
        }
    }
}
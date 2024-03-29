﻿using System;
using System.IO;
using System.IO.Enumeration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace GUISC
{
    public partial class Compare
    {
        // Comparison data types
        public static int numTOTAL_compare = 0;
        public static int numTOTAL_diff = 0;

        // Compare spreadsheets
        public void Compare_Spreadsheets(string function, string Results_Directory, List<fileIndex> File_List, BackgroundWorker worker)
        {
            worker.ReportProgress(Function.compareno, String.Format("COMPARE BEGINS"));

            // Open CSV file to log results
            var csv = new StringBuilder();
            var newLine0 = string.Format($"Original Filepath;XLSX Filepath;Comparison Success;Error message");
            csv.AppendLine(newLine0);

            try
            {
                foreach (fileIndex entry in File_List)
                {
                    // Define data types
                    bool? compare_success = null;
                    string? error_message = null;
                    // Get information from list
                    string org_filepath = entry.Org_Filepath;
                    string copy_filepath = entry.Copy_Filepath;
                    string xlsx_filepath = entry.XLSX_Conv_Filepath;

                    // Compare workbook differences
                    if (File.Exists(xlsx_filepath) && Path.GetExtension(org_filepath).ToLower() != ".xlsb")
                    {
                        // Inform user of comparison
                        worker.ReportProgress(69, String.Format(org_filepath));
                        worker.ReportProgress(69, String.Format($"Comparing to: {xlsx_filepath}"));

                        int return_code;

                        if (function == "CountConvertCompareArchive")
                        {
                            // Compare workbooks using external app Beyond Compare 4
                            return_code = Compare_Workbook(copy_filepath, xlsx_filepath);
                        }
                        else
                        {
                            return_code = Compare_Workbook(org_filepath, xlsx_filepath);
                        }

                        if (return_code == 0 || return_code == 1 || return_code == 2)
                        {
                            numTOTAL_compare++;
                            compare_success = true;
                            worker.ReportProgress(69, String.Format("Cell values identical: " + compare_success));
                        }
                        if (return_code == 12 || return_code == 13 || return_code == 14)
                        {
                            numTOTAL_compare++;
                            numTOTAL_diff++;
                            compare_success = false;
                            worker.ReportProgress(69, String.Format("Cell values identical: " + compare_success));
                        }
                        if (return_code == 11)
                        {
                            compare_success = null;
                            error_message = "Original file cannot be compared";
                            worker.ReportProgress(69, String.Format(error_message));
                        }
                        if (return_code == 100)
                        {
                            compare_success = null;
                            error_message = "Unknown error";
                            worker.ReportProgress(69, String.Format(error_message));
                        }
                        if (return_code == 104)
                        {
                            compare_success = null;
                            error_message = "Beyond Compare 4 trial period expired";
                            worker.ReportProgress(69, String.Format(error_message));
                        }

                        // Output result in open CSV file
                        var newLine1 = string.Format($"{org_filepath};{xlsx_filepath};{compare_success};{error_message}");
                        csv.AppendLine(newLine1);
                    }
                }
            }
            catch (Win32Exception)
            {
                worker.ReportProgress(69, String.Format("Beyond Compare 4 is not installed"));
                worker.ReportProgress(69, String.Format("Comparison ended"));
            }

            // Close CSV file to log results
            Results.CSV_filepath = Results_Directory + "\\3_Compare_Results.csv";
            File.WriteAllText(Results.CSV_filepath, csv.ToString(), Encoding.UTF8);

            worker.ReportProgress(Function.compareno, String.Format("COMPARE FINISHED"));
            worker.ReportProgress(Function.compareno, String.Format("---"));
        }
    }
}
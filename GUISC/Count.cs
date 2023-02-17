using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2019.Excel.ThreadedComments;

namespace GUISC
{
    public partial class Count
    {
        // Public data types
        public static int numTOTAL, numXLSX_Strict;

        // Count spreadsheets
        public string Count_Spreadsheets(string inputdir, string outputdir, bool recurse)
        {
            Function f = new Function();

            f.echoLog("COUNT");
            f.echoLog("---");

            //Object reference
            DirectoryInfo count = new DirectoryInfo(inputdir);
            fileFormatIndex index = new fileFormatIndex();
            List<fileFormatIndex> fileformats = index.Create_fileFormatIndex();

            // Search recursively or not
            SearchOption searchoption = SearchOption.TopDirectoryOnly;
            if (recurse == true)
            {
                searchoption = SearchOption.AllDirectories;
            }

            foreach (fileFormatIndex fileformat in fileformats)
            {
                // Count
                int total = count.GetFiles($"*{fileformat.Extension}", searchoption).Length;

                // Detect OOXML conformance
                if (fileformat.Extension == ".xlsx")
                {
                    int xlsx_total = total;
                    int strict_total = Count_Strict(inputdir, recurse);
                    int transitional_total = xlsx_total - strict_total;

                    if (fileformat.Conformance == "transitional")
                    {
                        total = transitional_total;
                    }
                    else if (fileformat.Conformance == "strict")
                    {
                        total = strict_total;
                    }
                }

                // Change value in list
                fileformat.Count = total;

                // Create sum of all counts
                numTOTAL = numTOTAL + total;

                // Subtract if OOXML conformance was counted
                if (fileformat.Conformance == "transitional" || fileformat.Conformance == "strict")
                {
                    numTOTAL = numTOTAL - total;
                }
            }

            // Inform user if no spreadsheets identified
            if (numTOTAL == 0)
            {
                f.echoLog("No spreadsheets identified");
                f.echoLog("CLISC ended");
                f.echoLog("---");
                throw new Exception();
            }
            else
            {
                // Show count to user
                f.echoLog("# Extension - Name");
                foreach (fileFormatIndex fileformat in fileformats)
                {
                    if (fileformat.Conformance == null)
                    {
                        f.echoLine($"{fileformat.Count} {fileformat.Extension} - {fileformat.Description}");
                    }
                    else if (fileformat.Conformance != null)
                    {
                        f.echoLine($"--> {fileformat.Count} {fileformat.Extension} have {fileformat.Conformance} conformance");
                    }
                }
                f.echoLog($"{numTOTAL} spreadsheets in total");

                // Create new directory to output results in CSV
                Results res = new Results();
                string Results_Directory = res.Create_Results_Directory(outputdir);

                // Output results in CSV
                var csv = new StringBuilder();
                var newLine0 = string.Format("#;Extension;Name");
                csv.AppendLine(newLine0);
                foreach (fileFormatIndex fileformat in fileformats)
                {
                    var newLine1 = string.Format($"{fileformat.Count};{fileformat.Extension};{fileformat.Description}");
                    csv.AppendLine(newLine1);
                }
                var newLine2 = string.Format($"{numTOTAL};spreadshets in total;");
                csv.AppendLine(newLine2);

                // Close CSV
                Results.CSV_filepath = Results_Directory + "\\1_Count_Results.csv";
                File.WriteAllText(Results.CSV_filepath, csv.ToString(), Encoding.UTF8);

                return Results_Directory;
            }
        }
    }
}
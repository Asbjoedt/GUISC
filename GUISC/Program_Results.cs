using GUISC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUISC
{
    public partial class Results
    {
        // Methods for results reporting
        public void Count_Results()
        {
            Function f = new Function();

            f.echoLog("---");
            f.echoLog("CLISC SUMMARY");
            f.echoLog("---");
            f.echoLog($"COUNT: {Count.numTOTAL} spreadsheet files in total");
            f.echoLog($"Results saved to CSV log in filepath: {Results.CSV_filepath}");
        }

        public void Convert_Results()
        {
            Function f = new Function();

            // Calculate fails
            int fail_conversion = Count.numTOTAL - Conversion.numCOMPLETE;

            f.echoLog("---");
            f.echoLog("CLISC SUMMARY");
            f.echoLog("---");
            f.echoLog($"COUNT: {Count.numTOTAL} spreadsheet files in total");
            f.echoLog($"CONVERT: {fail_conversion} of {Count.numTOTAL} spreadsheets failed conversion");
            f.echoLog($"Results saved to CSV log in filepath: {Results.CSV_filepath}");
        }
        public void Compare_Results()
        {
            Function f = new Function();

            // Calculate fails
            int fail_conversion = Count.numTOTAL - Conversion.numCOMPLETE;
            int fail_comparison = Conversion.numCOMPLETE - Compare.numTOTAL_compare;

            f.echoLog("---");
            f.echoLog("CLISC SUMMARY");
            f.echoLog("---");
            f.echoLog($"COUNT: {Count.numTOTAL} spreadsheet files in total");
            f.echoLog($"CONVERT: {fail_conversion} of {Count.numTOTAL} spreadsheets failed conversion");
            f.echoLog($"COMPARE: {fail_comparison} of {Conversion.numCOMPLETE} converted spreadsheets failed comparison");
            f.echoLog($"COMPARE: {Compare.numTOTAL_diff} of {Compare.numTOTAL_compare} compared spreadsheets have cell value differences");

        }
        public void Archive_Results()
        {
            Function f = new Function();

            // Calculate fails
            int fail_conversion = Count.numTOTAL - Conversion.numCOMPLETE;
            int fail_comparison = Conversion.numCOMPLETE - Compare.numTOTAL_compare;

            f.echoLog("---");
            f.echoLog("CLISC SUMMARY");
            f.echoLog("---");
            f.echoLog($"COUNT: {Count.numTOTAL} spreadsheets");
            f.echoLog($"CONVERT: {fail_conversion} of {Count.numTOTAL} spreadsheets failed conversion");
            f.echoLog($"COMPARE: {fail_comparison} of {Conversion.numCOMPLETE} converted spreadsheets failed comparison");
            f.echoLog($"COMPARE: {Compare.numTOTAL_diff} of {Compare.numTOTAL_compare} compared spreadsheets have cell value differences");
            f.echoLog($"ARCHIVE: {Archive.invalid_files} of {Conversion.numCOMPLETE} converted spreadsheets have invalid file formats");
            f.echoLog($"ARCHIVE: {Archive.cellvalue_files} of {Conversion.numCOMPLETE} converted spreadsheets had no cell values");
            f.echoLog($"ARCHIVE: {Archive.connections_files} of {Conversion.numCOMPLETE} converted spreadsheets had data connections - Data connections were removed");
            f.echoLog($"ARCHIVE: {Archive.cellreferences_files} of {Conversion.numCOMPLETE} converted spreadsheets had external cell references - External cell references were removed");
            f.echoLog($"ARCHIVE: {Archive.rtdfunctions_files} of {Conversion.numCOMPLETE} converted spreadsheets had RTD functions - RTD functions were removed");
            f.echoLog($"ARCHIVE: {Archive.extobj_files} of {Conversion.numCOMPLETE} converted spreadsheets had external object references - External object references were removed");
            f.echoLog($"ARCHIVE: {Archive.embedobj_files} of {Conversion.numCOMPLETE} converted spreadsheets have embedded objects  - Embedded IMAGE objects were converted to .tiff");
            f.echoLog($"ARCHIVE: {Archive.printersettings_files} of {Conversion.numCOMPLETE} converted spreadsheets had printer settings - Printer settings were removed");
            f.echoLog($"ARCHIVE: {Archive.activesheet_files} of {Conversion.numCOMPLETE} converted spreadsheets did not have active first sheet - Active sheet was changed");
            f.echoLog($"ARCHIVE: {Archive.metadata_files} of {Conversion.numCOMPLETE} converted spreadsheets have metadata  - Metadata were NOT removed");
            f.echoLog($"ARCHIVE: {Archive.hyperlinks_files} of {Conversion.numCOMPLETE} converted spreadsheets have hyperlinks - Hyperlinks were NOT removed");
        }
    }
}
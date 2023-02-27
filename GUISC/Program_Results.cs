using GUISC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUISC
{
    public partial class Results
    {
        // Methods for results reporting
        public void Count_Results(BackgroundWorker worker)
        {
            worker.ReportProgress(100, String.Format("SUMMARY"));
            worker.ReportProgress(100, String.Format("---"));
            worker.ReportProgress(100, String.Format($"COUNT: {Count.numTOTAL} spreadsheet files in total"));
            worker.ReportProgress(100, String.Format("---"));
        }

        public void Convert_Results(BackgroundWorker worker)
        {
            // Calculate fails
            int fail_conversion = Count.numTOTAL - Conversion.numCOMPLETE;

            worker.ReportProgress(100, String.Format("SUMMARY"));
            worker.ReportProgress(100, String.Format("---"));
            worker.ReportProgress(100, String.Format($"COUNT: {Count.numTOTAL} spreadsheet files in total"));
            worker.ReportProgress(100, String.Format($"CONVERT: {fail_conversion} of {Count.numTOTAL} spreadsheets failed conversion"));
            worker.ReportProgress(100, String.Format("---"));
        }
        public void Compare_Results(BackgroundWorker worker)
        {
            // Calculate fails
            int fail_conversion = Count.numTOTAL - Conversion.numCOMPLETE;
            int fail_comparison = Conversion.numCOMPLETE - Compare.numTOTAL_compare;

            worker.ReportProgress(100, String.Format("SUMMARY"));
            worker.ReportProgress(100, String.Format("---"));
            worker.ReportProgress(100, String.Format($"COUNT: {Count.numTOTAL} spreadsheet files in total"));
            worker.ReportProgress(100, String.Format($"CONVERT: {fail_conversion} of {Count.numTOTAL} spreadsheets failed conversion"));
            worker.ReportProgress(100, String.Format($"COMPARE: {fail_comparison} of {Conversion.numCOMPLETE} converted spreadsheets failed comparison"));
            worker.ReportProgress(100, String.Format($"COMPARE: {Compare.numTOTAL_diff} of {Compare.numTOTAL_compare} compared spreadsheets have cell value differences"));
            worker.ReportProgress(100, String.Format("---"));
        }
        public void Archive_Results(BackgroundWorker worker)
        {
            // Calculate fails
            int fail_conversion = Count.numTOTAL - Conversion.numCOMPLETE;
            int fail_comparison = Conversion.numCOMPLETE - Compare.numTOTAL_compare;

            worker.ReportProgress(100, String.Format("SUMMARY"));
            worker.ReportProgress(100, String.Format("---"));
            worker.ReportProgress(100, String.Format($"COUNT: {Count.numTOTAL} spreadsheet files in total"));
            worker.ReportProgress(100, String.Format($"CONVERT: {fail_conversion} of {Count.numTOTAL} spreadsheets failed conversion"));
            worker.ReportProgress(100, String.Format($"COMPARE: {fail_comparison} of {Conversion.numCOMPLETE} converted spreadsheets failed comparison"));
            worker.ReportProgress(100, String.Format($"COMPARE: {Compare.numTOTAL_diff} of {Compare.numTOTAL_compare} compared spreadsheets have cell value differences"));
            worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.invalid_files} of {Conversion.numCOMPLETE} converted spreadsheets have invalid file formats"));
            worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.connections_files} of {Conversion.numCOMPLETE} converted spreadsheets had data connections - Data connections were removed"));
            worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.cellreferences_files} of {Conversion.numCOMPLETE} converted spreadsheets had external cell references - External cell references were removed"));
            worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.rtdfunctions_files} of {Conversion.numCOMPLETE} converted spreadsheets had RTD functions - RTD functions were removed"));
            worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.extobj_files} of {Conversion.numCOMPLETE} converted spreadsheets had external object references - External object references were removed"));
            worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.embedobj_files} of {Conversion.numCOMPLETE} converted spreadsheets have embedded objects  - Embedded IMAGE objects were converted to .tiff"));
            worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.cellvalue_files} of {Conversion.numCOMPLETE} converted spreadsheets had no cell values"));
            if (Function.fullcompliance)
            {
                worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.printersettings_files} of {Conversion.numCOMPLETE} converted spreadsheets had printer settings - Printer settings were removed"));
                worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.activesheet_files} of {Conversion.numCOMPLETE} converted spreadsheets did not have active first sheet - Active sheet was changed"));
                worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.metadata_files} of {Conversion.numCOMPLETE} converted spreadsheets have metadata  - Metadata were extracted and removed"));
                worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.hyperlinks_files} of {Conversion.numCOMPLETE} converted spreadsheets have hyperlinks - Hyperlinks were extracted"));
            }
            else
            {
                worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.printersettings_files} of {Conversion.numCOMPLETE} converted spreadsheets had printer settings - Nothing was done"));
                worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.activesheet_files} of {Conversion.numCOMPLETE} converted spreadsheets did not have active first sheet - Nothing was done"));
                worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.metadata_files} of {Conversion.numCOMPLETE} converted spreadsheets have metadata - Nothing was done"));
                worker.ReportProgress(100, String.Format($"ARCHIVE: {Archive.hyperlinks_files} of {Conversion.numCOMPLETE} converted spreadsheets have hyperlinks - Nothing was done"));
            }
            worker.ReportProgress(100, String.Format("---"));
        }
    }
}
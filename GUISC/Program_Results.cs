using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUISC
{
    public class Program_Results
    {
        // Methods for results reporting
        public void Count_Results()
        {
            Console.WriteLine("---");
            Console.WriteLine("CLISC SUMMARY");
            Console.WriteLine("---");
            Console.WriteLine($"COUNT: {Count.numTOTAL} spreadsheet files in total");
            Console.WriteLine($"Results saved to CSV log in filepath: {Spreadsheet.CSV_filepath}");
        }

        public void Convert_Results()
        {
            Console.WriteLine("---");
            Console.WriteLine("CLISC SUMMARY");
            Console.WriteLine("---");
            Console.WriteLine($"COUNT: {Count.numTOTAL} spreadsheet files in total");
            Console.WriteLine($"CONVERT: {Conversion.numCOMPLETE} of {Count.numTOTAL} spreadsheets completed conversion");
            Console.WriteLine($"Results saved to CSV log in filepath: {Spreadsheet.CSV_filepath}");
        }
        public void Compare_Results()
        {
            Console.WriteLine("---");
            Console.WriteLine("CLISC SUMMARY");
            Console.WriteLine("---");
            Console.WriteLine($"COUNT: {Count.numTOTAL} spreadsheet files in total");
            Console.WriteLine($"CONVERT: {Conversion.numCOMPLETE} of {Count.numTOTAL} spreadsheets completed conversion");
            Console.WriteLine($"COMPARE: {Compare.numTOTAL_compare} of {Conversion.numCOMPLETE} converted spreadsheets completed comparison");
            Console.WriteLine($"COMPARE: {Compare.numTOTAL_diff} of {Compare.numTOTAL_compare} compared spreadsheets have cell value differences");

        }
        public void Archive_Results()
        {
            Console.WriteLine("---");
            Console.WriteLine("CLISC SUMMARY");
            Console.WriteLine("---");
            Console.WriteLine($"COUNT: {Count.numTOTAL} spreadsheets");
            Console.WriteLine($"CONVERT: {Conversion.numCOMPLETE} of {Count.numTOTAL} spreadsheets completed conversion");
            Console.WriteLine($"COMPARE: {Compare.numTOTAL_compare} of {Conversion.numCOMPLETE} converted spreadsheets completed comparison");
            Console.WriteLine($"COMPARE: {Compare.numTOTAL_diff} of {Compare.numTOTAL_compare} compared spreadsheets have cell value differences");
            Console.WriteLine($"ARCHIVE: {Archive.invalid_files} of {Conversion.numCOMPLETE} converted spreadsheets have invalid file formats");
            Console.WriteLine($"ARCHIVE: {Archive.cellvalue_files} of {Conversion.numCOMPLETE} converted spreadsheets had no cell values - Handle manually!");
            Console.WriteLine($"ARCHIVE: {Archive.connections_files} of {Conversion.numCOMPLETE} converted spreadsheets had data connections - Data connections were removed");
            Console.WriteLine($"ARCHIVE: {Archive.cellreferences_files} of {Conversion.numCOMPLETE} converted spreadsheets had external cell references - External cell references were removed");
            Console.WriteLine($"ARCHIVE: {Archive.rtdfunctions_files} of {Conversion.numCOMPLETE} converted spreadsheets had RTD functions - RTD functions were removed");
            Console.WriteLine($"ARCHIVE: {Archive.printersettings_files} of {Conversion.numCOMPLETE} converted spreadsheets had printer settings - Printer settings were removed");
            Console.WriteLine($"ARCHIVE: {Archive.activesheet_files} of {Conversion.numCOMPLETE} converted spreadsheets had not first sheet as active sheet - Active sheet was changed");
            Console.WriteLine($"ARCHIVE: {Archive.extobj_files} of {Conversion.numCOMPLETE} converted spreadsheets had external object references - External object references were removed");
            Console.WriteLine($"ARCHIVE: {Archive.embedobj_files} of {Conversion.numCOMPLETE} converted spreadsheets have embedded objects - Embedded objects were NOT removed. Handle manually!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.CustomXmlSchemaReferences;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUISC
{
    public partial class Conversion
    {
        // Convert to .xlsx Transitional - DOES NOT SUPPORT STRICT TO TRANSITIONAL
        public bool Convert_to_OOXML_Transitional(string input_filepath, string output_filepath)
        {
            bool convert_success = false;

            // Convert spreadsheet
            byte[] byteArray = File.ReadAllBytes(input_filepath);
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, (int)byteArray.Length);
                using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(stream, true))
                {
                    Handle_Protection(spreadsheet, input_filepath); // Try to remove read-only and filesharing protection
                    spreadsheet.ChangeDocumentType(SpreadsheetDocumentType.Workbook); // Convert to different file format
                }
                File.WriteAllBytes(output_filepath, stream.ToArray());
            }

            // Repair spreadsheet
            Repair rep = new Repair();
            rep.Repair_OOXML(output_filepath);

            // Return success
            return convert_success = true;
        }

        // Work in progress
        // Convert .xlsx Strict to Transitional conformance
        public void Convert_Strict_to_Transitional(string input_filepath)
        {
            // Create list of namespaces
            List<namespaceIndex> namespaces = namespaceIndex.Create_Namespaces_Index();

            using (var spreadsheet = SpreadsheetDocument.Open(input_filepath, true))
            {
                WorkbookPart wbPart = spreadsheet.WorkbookPart;
                Workbook workbook = wbPart.Workbook;
                // If Strict
                if (workbook.Conformance != null || workbook.Conformance != "transitional")
                {
                    // Change conformance class
                    workbook.Conformance.Value = ConformanceClass.Enumtransitional;

                    // Remove vml urn namespace from workbook.xml
                    workbook.RemoveNamespaceDeclaration("v");
                }
            }
        }

        // Work in progress
        // Remove write or filesharing protection from spreadsheet in cases of no password
        public void Handle_Protection(SpreadsheetDocument spreadsheet, string input_filepath)
        {
            if (spreadsheet.WorkbookPart.Workbook.WorkbookProtection != null || spreadsheet.WorkbookPart.Workbook.FileSharing != null)
            {
                // Use Excel Interop to convert the spreadsheet
                Convert_ExcelInterop(input_filepath, input_filepath);
            }
        }
    }
}
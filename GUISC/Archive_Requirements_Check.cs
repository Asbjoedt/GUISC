using System;
using System.IO;
using System.IO.Packaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2013.ExcelAc;
using System.ComponentModel;

namespace GUISC
{
    public partial class Archive_Requirements
    {
        public bool Data { get; set; } = false;

        public bool Metadata { get; set; } = false;

        public bool Conformance { get; set; } = false;

        public int Connections { get; set; } = 0;

        public int CellReferences { get; set; } = 0;

        public int RTDFunctions { get; set; } = 0;

        public int PrinterSettings { get; set; } = 0;

        public int ExternalObj { get; set; } = 0;

        public int EmbedObj { get; set; } = 0;

        public int Hyperlinks { get; set; } = 0;

        public bool ActiveSheet { get; set; } = false;

        public bool AbsolutePath { get; set; } = false;

        // Perform check of archival requirements
        public List<Archive_Requirements> Check_XLSX_Requirements(string filepath, BackgroundWorker worker)
        {
            bool conformance = Check_Conformance(filepath);
            if (conformance == false)
            {
                worker.ReportProgress(69, String.Format("Check: Strict conformance detected"));
            }
            else if (conformance == true)
            {
                worker.ReportProgress(69, String.Format("Check: Transitional conformance detected"));
            }

            int connections = Check_DataConnections(filepath);
            if (connections > 0)
            {
                worker.ReportProgress(69, String.Format($"Check: {connections} data connections detected"));
            }

            int cellreferences = Check_ExternalCellReferences(filepath);
            if (cellreferences > 0)
            {
                worker.ReportProgress(69, String.Format($"Check: {cellreferences} external cell references detected"));
            }

            int rtdfunctions = Check_RTDFunctions(filepath);
            if (rtdfunctions > 0)
            {
                worker.ReportProgress(69, String.Format($"Check: {rtdfunctions} RealTimeData functions detected"));
            }

            int extobjects = Check_ExternalObjects(filepath);
            if (extobjects > 0)
            {
                worker.ReportProgress(69, String.Format($"Check: {extobjects} external objects detected"));
            }

            int embedobj = Check_EmbeddedObjects(filepath);
            if (embedobj > 0)
            {
                worker.ReportProgress(69, String.Format($"Check: {embedobj} embedded objects detected"));
            }

            int printersettings = Check_PrinterSettings(filepath);
            if (printersettings > 0)
            {
                worker.ReportProgress(69, String.Format($"Check: {printersettings} printer settings detected"));
            }

            bool activesheet = Check_ActiveSheet(filepath);
            if (activesheet)
            {
                worker.ReportProgress(69, String.Format("Check: First sheet is not active detected"));
            }

            bool absolutepath = Check_AbsolutePath(filepath);
            if (absolutepath)
            {
                worker.ReportProgress(69, String.Format("Check: Absolute path to local directory detected"));
            }

            bool data = Check_Value(filepath);
            if (data)
            {
                worker.ReportProgress(69, String.Format("Check: No cell values detected"));
            }

            bool metadata = Check_Metadata(filepath);
            if (data)
            {
                worker.ReportProgress(69, String.Format("Check: File property information detected"));
            }

            int hyperlinks = Check_Hyperlinks(filepath);
            if (hyperlinks > 0)
            {
                worker.ReportProgress(69, String.Format($"Check: {hyperlinks} hyperlinks detected"));
            }

            // Add information to list and return it
            List<Archive_Requirements> Arc_Req = new List<Archive_Requirements>();
            Arc_Req.Add(new Archive_Requirements { Data = data, Conformance = conformance, Connections = connections, CellReferences = cellreferences, RTDFunctions = rtdfunctions, PrinterSettings = printersettings, ExternalObj = extobjects, ActiveSheet = activesheet, AbsolutePath = absolutepath, Metadata = metadata, EmbedObj = embedobj, Hyperlinks = hyperlinks });
            return Arc_Req;
        }

        // Check for Strict conformance
        public bool Check_Conformance(string filepath)
        {
            bool conformance = false;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                Workbook workbook = spreadsheet.WorkbookPart.Workbook;
                if (workbook.Conformance == null || workbook.Conformance == "transitional")
                {
                    conformance = true;
                }
                else if (workbook.Conformance == "strict")
                {
                    conformance = false;
                }
            }
            return conformance;
        }

        // Check for data connections
        public int Check_DataConnections(string filepath)
        {
            int conn_count = 0;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                ConnectionsPart conn = spreadsheet.WorkbookPart.ConnectionsPart;
                if (conn != null)
                {
                    conn_count = conn.Connections.Count();
                }
            }
            return conn_count;
        }

        // Check for external cell references
        public int Check_ExternalCellReferences(string filepath)
        {
            int ext_cellrefs_count = 0;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                IEnumerable<WorksheetPart> worksheetParts = spreadsheet.WorkbookPart.WorksheetParts;
                foreach (WorksheetPart part in worksheetParts)
                {
                    Worksheet worksheet = part.Worksheet;
                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Elements<Row>(); // Find all rows
                    foreach (var row in rows)
                    {
                        IEnumerable<Cell> cells = row.Elements<Cell>();
                        foreach (Cell cell in cells)
                        {
                            if (cell.CellFormula != null)
                            {
                                string formula = cell.CellFormula.InnerText;
                                if (formula.Length > 1)
                                {
                                    string hit = formula.Substring(0, 1); // Transfer first 1 characters to string
                                    string hit2 = formula.Substring(0, 2); // Transfer first 2 characters to string
                                    if (hit == "[" || hit2 == "'[")
                                    {
                                        ext_cellrefs_count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return ext_cellrefs_count;
        }

        // Check for external object references
        public int Check_ExternalObjects(string filepath)
        {
            int extobj_count = 0;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                IEnumerable<ExternalWorkbookPart> extWbParts = spreadsheet.WorkbookPart.ExternalWorkbookParts;
                foreach (ExternalWorkbookPart extWbPart in extWbParts)
                {
                    extobj_count++;
                }
            }
            return extobj_count;
        }

        // Check for RTD functions
        public static int Check_RTDFunctions(string filepath) // Check for RTD functions
        {
            int rtd_functions_count = 0;

            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                IEnumerable<WorksheetPart> worksheetParts = spreadsheet.WorkbookPart.WorksheetParts;
                foreach (WorksheetPart part in worksheetParts)
                {
                    Worksheet worksheet = part.Worksheet;
                    IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Elements<Row>(); // Find all rows
                    foreach (var row in rows)
                    {
                        IEnumerable<Cell> cells = row.Elements<Cell>();
                        foreach (Cell cell in cells)
                        {
                            if (cell.CellFormula != null)
                            {
                                string formula = cell.CellFormula.InnerText;
                                if (formula.Length > 2)
                                {
                                    string hit = formula.Substring(0, 3); // Transfer first 3 characters to string
                                    if (hit == "RTD")
                                    {
                                        rtd_functions_count++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return rtd_functions_count;
        }

        public int Check_EmbeddedObjects(string filepath)
        {
            int count_embedobj = 0;
            int embedobj_number = 0;
            List<EmbeddedObjectPart> ole = new List<EmbeddedObjectPart>();
            List<EmbeddedPackagePart> packages = new List<EmbeddedPackagePart>();
            List<ImagePart> emf = new List<ImagePart>();
            List<ImagePart> images = new List<ImagePart>();
            List<Model3DReferenceRelationshipPart> threeD = new List<Model3DReferenceRelationshipPart>();

            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                IEnumerable<WorksheetPart> worksheetParts = spreadsheet.WorkbookPart.WorksheetParts;

                // Perform check
                foreach (WorksheetPart worksheetPart in worksheetParts)
                {
                    ole = worksheetPart.EmbeddedObjectParts.Distinct().ToList();
                    packages = worksheetPart.EmbeddedPackageParts.Distinct().ToList();
                    emf = worksheetPart.ImageParts.Distinct().ToList();
                    if (worksheetPart.DrawingsPart != null) // DrawingsPart needs a null check
                    {
                        images = worksheetPart.DrawingsPart.ImageParts.Distinct().ToList();
                    }
                    threeD = worksheetPart.Model3DReferenceRelationshipParts.Distinct().ToList();
                }

                // Count number of embeddings
                count_embedobj = ole.Count() + packages.Count() + emf.Count() + images.Count() + threeD.Count();

                // Inform user of detected embedded objects
                if (count_embedobj > 0)
                {
                    // Inform user of each OLE object
                    foreach (EmbeddedObjectPart part in ole)
                    {
                        embedobj_number++;
                    }
                    // Inform user of each package object
                    foreach (EmbeddedPackagePart part in packages)
                    {
                        embedobj_number++;
                    }
                    // Inform user of each 3D object
                    foreach (Model3DReferenceRelationshipPart part in threeD)
                    {
                        embedobj_number++;
                    }
                    // Inform user of each .emf image object
                    foreach (ImagePart part in emf)
                    {
                        embedobj_number++;
                    }
                    // Inform user of each image object
                    foreach (ImagePart part in images)
                    {
                        embedobj_number++;
                    }
                }
            }
            return count_embedobj;
        }

        // Check for any values by checking if sheets and cell values exist
        public bool Check_Value(string filepath)
        {
            bool nocellvalues = true;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                if (spreadsheet.WorkbookPart.WorksheetParts != null)
                {
                    IEnumerable<WorksheetPart> worksheetparts = spreadsheet.WorkbookPart.WorksheetParts;
                    foreach (WorksheetPart part in worksheetparts)
                    {
                        Worksheet worksheet = part.Worksheet;
                        IEnumerable<Row> rows = worksheet.GetFirstChild<SheetData>().Elements<Row>(); // Find all rows
                        if (rows.Count() > 0) // If any rows exist, this means cells exist
                        {
                            nocellvalues = false;
                        }
                    }
                }
            }
            return nocellvalues;
        }

        // Check for hyperlinks
        public int Check_Hyperlinks(string filepath)
        {
            int hyperlinks_count = 0;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                List<HyperlinkRelationship> hyperlinks = spreadsheet
                    .GetAllParts()
                    .SelectMany(p => p.HyperlinkRelationships)
                    .ToList();

                hyperlinks_count = hyperlinks.Count;
            }
            return hyperlinks_count;
        }

        // Check for printer settings
        public int Check_PrinterSettings(string filepath)
        {
            int printersettings_count = 0;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                IEnumerable<WorksheetPart> worksheetParts = spreadsheet.WorkbookPart.WorksheetParts;
                List<SpreadsheetPrinterSettingsPart> printers = new List<SpreadsheetPrinterSettingsPart>();
                foreach (WorksheetPart worksheetPart in worksheetParts)
                {
                    printers = worksheetPart.SpreadsheetPrinterSettingsParts.ToList();
                }
                foreach (SpreadsheetPrinterSettingsPart printer in printers)
                {
                    printersettings_count++;
                }
            }
            return printersettings_count;
        }

        // Check for active sheet
        public bool Check_ActiveSheet(string filepath)
        {
            bool activeSheet = false;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                if (spreadsheet.WorkbookPart.Workbook.BookViews != null)
                {
                    BookViews bookViews = spreadsheet.WorkbookPart.Workbook.BookViews;
                    if (bookViews.ChildElements.Where(p => p.OuterXml == "workbookView") != null)
                    {
                        WorkbookView workbookView = bookViews.GetFirstChild<WorkbookView>();
                        if (workbookView.ActiveTab != null)
                        {
                            if (workbookView.ActiveTab.Value > 0)
                            {
                                activeSheet = true;
                            }
                        }
                    }
                }
            }
            return activeSheet;
        }

        // Check for absolute path
        public bool Check_AbsolutePath(string filepath)
        {
            bool absolutepath = false;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                if (spreadsheet.WorkbookPart.Workbook.AbsolutePath != null)
                {
                    absolutepath = true;
                }
            }
            return absolutepath;
        }

        // Check for metadata in file properties
        public bool Check_Metadata(string filepath)
        {
            bool metadata = false;

            // Perform check
            using (SpreadsheetDocument spreadsheet = SpreadsheetDocument.Open(filepath, false))
            {
                PackageProperties property = spreadsheet.Package.PackageProperties;

                if (property.Creator != null)
                {
                    metadata = true;
                }
                if (property.Title != null)
                {
                    metadata = true;
                }
                if (property.Subject != null)
                {
                    metadata = true;
                }
                if (property.Description != null)
                {
                    metadata = true;
                }
                if (property.Keywords != null)
                {
                    metadata = true;
                }
                if (property.Category != null)
                {
                    metadata = true;
                }
                if (property.LastModifiedBy != null)
                {
                    metadata = true;
                }
            }
            return metadata;
        }
    }
}
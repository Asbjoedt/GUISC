using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Reflection.Metadata.Ecma335;

namespace GUISC
{
    public partial class Validation
    {
        public bool? Validate_OpenDocument(string filepath)
        {
            bool? valid = null;
            Function f = new Function();

            try
            {
                // Use ODF Validator for validation of OpenDocument spreadsheets
                Process app = new Process();
                app.StartInfo.UseShellExecute = false;
                app.StartInfo.FileName = "javaw";
                string normal_dir = "C:\\Program Files\\ODF Validator\\odfvalidator-0.10.0-jar-with-dependencies.jar";
                string? environ_dir = null;
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) // If app is run on Windows
                {
                    environ_dir = Environment.GetEnvironmentVariable("ODFValidator");
                }
                if (environ_dir != null)
                {
                    app.StartInfo.Arguments = $"-jar \"{environ_dir}\" \"{filepath}\"";
                }
                else
                {
                    app.StartInfo.Arguments = $"-jar \"{normal_dir}\" \"{filepath}\"";
                }
                app.Start();
                app.WaitForExit();
                int return_code = app.ExitCode;
                app.Close();

                // Inform user of validation results
                if (return_code == 0)
                {
                    f.echoLine("Validate: File format is invalid. Spreadsheet has no cell values");
                }
                if (return_code == 1)
                {
                    f.echoLine("Validate: File format validation could not be completed");
                }
                if (return_code == 2)
                {
                    f.echoLine("Validate: File format is valid");
                    valid = true;
                }
                return valid;
            }
            catch (Win32Exception)
            {
                f.echoLine("Validate: File format validation requires ODF Validator and Java Development Kit");
                return valid;
            }
        }
    }
}
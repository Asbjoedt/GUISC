using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Reflection.Emit;
using DocumentFormat.OpenXml.Math;
using System.Timers;

namespace GUISC
{
    public partial class Function : Form
    {
        // data types
        public static string resultsDirectory = "";
        public static string inputdir = "";
        public static string outputdir = "";
        public static string function = "";
        public static bool recurse = false;

        public Function()
        {
            InitializeComponent();
        }

        private void Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Asbjoedt/GUISC");
        }

        private void InputDir_button_Click(object sender, EventArgs e)
        {
            if (inputDir_prompt.ShowDialog() == DialogResult.OK)
            {
                inputDir.Text = inputDir_prompt.SelectedPath;
                inputdir = inputDir.Text;
            }
        }
        private void OutputDir_button_Click(object sender, EventArgs e)
        {
            if (outputDir_prompt.ShowDialog() == DialogResult.OK)
            {
                outputDir.Text = outputDir_prompt.SelectedPath;
                outputdir = outputDir.Text;
            }
        }
        private void Recurse_CheckedChanged(object sender, EventArgs e)
        {
            recurse = true;
        }

        private void Function_picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string function = (string)Function_picker.SelectedItem;
            Console.WriteLine(function);
            if (function == "1. Count")
            {
                function = "Count";
            }
            else if (function == "2. Count & Convert")
            {
                function = "CountConvert";
            }
            else if (function == "3. Count, Convert & Compare")
            {
                function = "CountConvertCompare";
            }
            else if (function == "4. Count, Convert, Compare & Archive")
            {
                function = "CountConvertCompareArchive";
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            // Disable Run button
            Run.Enabled = false;

            // Begin process timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Create object instance
            Count cou = new Count();
            Conversion con = new Conversion();
            Compare com = new Compare();
            Archive arc = new Archive();
            Program_Results app = new Program_Results();

            // Method references
            switch (function)
            {
                case "Count":
                    cou.Count_Spreadsheets(inputdir, outputdir, recurse);
                    app.Count_Results();
                    break;

                case "CountConvert":
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse);
                    con.Convert_Spreadsheets(function, inputdir, recurse, resultsDirectory);
                    app.Convert_Results();
                    break;

                case "CountConvertCompare":
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse);
                    List<fileIndex> fileList = con.Convert_Spreadsheets(function, inputdir, recurse, resultsDirectory);
                    com.Compare_Spreadsheets(function, resultsDirectory, fileList);
                    app.Compare_Results();
                    break;

                case "CountConvertCompareArchive":
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse);
                    fileList = con.Convert_Spreadsheets(function, inputdir, recurse, resultsDirectory);
                    com.Compare_Spreadsheets(function, resultsDirectory, fileList);
                    arc.Archive_Spreadsheets(resultsDirectory, fileList);
                    app.Archive_Results();
                    break;

                default:
                    Console.WriteLine("Invalid function argument. Function argument must be one these: Count, CountConvert, CountConvertCompare, CountConvertCompareArchive");
                    break;
            }

            // Stop process timer
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            string elapsedTime = String.Format($"{time:dd\\:hh\\:mm\\:ss} (days:hrs:min:sec)");
            Console.WriteLine("Total process time: " + elapsedTime);
            Console.WriteLine("CLISC ended");
            Console.WriteLine("---");

            // Enable Run button
            Run.Enabled = true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void ResultsDir_open_Click(object sender, EventArgs e)
        {
            if (outputdir != "")
            {
                System.Diagnostics.Process.Start(outputdir);
            }
        }
    }
}
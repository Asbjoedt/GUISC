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

        private void Link_LinkClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/Asbjoedt/GUISC");
            // LinkLabelLinkClickedEventArgs
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

        private void functionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            string function = functionPicker.GetItemText(functionPicker.SelectedItem);
            if (function == "Count")
            {
                function = "Count";
            }
            else if (function == "Count & Convert")
            {
                function = "CountConvert";
            }
            else if (function == "Count, Convert & Compare")
            {
                function = "CountConvertCompare";
            }
            else if (function == "Count, Convert, Compare & Archive")
            {
                function = "CountConvertCompareArchive";
            }
        }

        private void Run_Click(object sender, EventArgs e)
        {
            // Disable Run button
            Run.Enabled = false;

            // Clear results window
            resultsWindow.Clear();

            // Begin process timer
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Create object instance
            Count cou = new Count();
            Conversion con = new Conversion();
            Compare com = new Compare();
            Archive arc = new Archive();
            Program_Results app = new Program_Results();

            resultsWindow.AppendText(function);
            // Method references
            switch (function)
            {
                case "Count":
                    resultsWindow.AppendText(outputdir);
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
            }

            // Stop process timer
            timer.Stop();
            TimeSpan time = timer.Elapsed;
            string elapsedTime = String.Format($"{time:dd\\:hh\\:mm\\:ss} (days:hrs:min:sec)");
            resultsWindow.AppendText("CLISC ended" + Environment.NewLine);

            // Enable Run button
            Run.Enabled = true;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void ResultsDir_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(resultsDirectory))
            {
                System.Diagnostics.Process.Start(resultsDirectory);
            }
        }
    }
}
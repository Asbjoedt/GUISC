using System;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Reflection.Emit;

namespace GUISC
{
    public partial class Function : Form
    {
        // Data types
        public static string resultsDirectory = "";
        public static string inputdir = "";
        public static string outputdir = "";
        public static string function = "";
        public static bool recurse = false;
        public static int countno = 0;
        public static int convertno;
        public static int compareno;
        public static int archiveno;
        TimeSpan time = new TimeSpan();

        // Primary Windows Forms method
        public Function()
        {
            InitializeComponent();
        }

        // Run GUISC methods on click
        private void Run_Click(object sender, EventArgs e)
        {
            // Begin process timer
            timer.Start();

            // Clear textboxes
            currentLine.Clear();
            resultsWindow.Clear();

            // Inform user of start
            resultsWindow.AppendText("GUISC started");

            // Disable input buttons
            Disable_Input_Buttons();

            // Calculate progress percentage based on input function
            ProgressPercentage();

            // Run the code
            backgroundWorker1.RunWorkerAsync();
        }

        // Run primary methods in backgroundworker
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Get the BackgroundWorker that raised this event
            BackgroundWorker worker = sender as BackgroundWorker;

            // Do backgroundwork
            Run_Switch();

            // Check if there is a request to cancel the process
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            // Return if backgroundwork is cancelled
            if (e.Cancel)
            {
                return;
            }
        }

        // Inform user when application ends in backgroundworker
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                resultsWindow.AppendText(Environment.NewLine + "GUISC was cancelled");
            }
            else if (e.Error != null)
            {
                resultsWindow.AppendText(Environment.NewLine + "Error. Details: " + (e.Error as Exception).ToString());
            }
            else
            {
                resultsWindow.AppendText(Environment.NewLine + "GUISC finished");
            }

            // Clear process line
            currentLine.Clear();

            // Enable buttons
            Enable_Input_Buttons();
            resultsDir_open.Enabled = true;

            // Stop the timer
            timer.Stop();
        }

        // Receive console inputs from backgroundworker by using ProgressChanged
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
            string message = e.UserState as string;
            resultsWindow.AppendText(Environment.NewLine + message);
        }

        // Switch for methods to run
        private void Run_Switch()
        {
            // Create object instances
            Count cou = new Count();
            Conversion con = new Conversion();
            Compare com = new Compare();
            Archive arc = new Archive();
            Results res = new Results();

            // Method references
            switch (function)
            {
                case "Count":
                    cou.Count_Spreadsheets(inputdir, outputdir, recurse);
                    res.Count_Results();
                    break;

                case "CountConvert":
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse);
                    con.Convert_Spreadsheets(function, inputdir, recurse, resultsDirectory);
                    res.Convert_Results();
                    break;

                case "CountConvertCompare":
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse);
                    List<fileIndex> fileList = con.Convert_Spreadsheets(function, inputdir, recurse, resultsDirectory);
                    com.Compare_Spreadsheets(function, resultsDirectory, fileList);
                    res.Compare_Results();
                    break;

                case "CountConvertCompareArchive":
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse);
                    fileList = con.Convert_Spreadsheets(function, inputdir, recurse, resultsDirectory);
                    com.Compare_Spreadsheets(function, resultsDirectory, fileList);
                    arc.Archive_Spreadsheets(resultsDirectory, fileList);
                    res.Archive_Results();
                    break;
            }
        }

        // Link to GitHub
        private void Link_LinkClicked(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Asbjoedt/GUISC");
        }

        // Open results directory
        private void ResultsDir_open_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(resultsDirectory))
            {
                Process.Start(resultsDirectory);
            }
        }

        // Set input directory
        private void InputDir_button_Click(object sender, EventArgs e)
        {
            if (inputDir_prompt.ShowDialog() == DialogResult.OK)
            {
                inputDir.Text = inputDir_prompt.SelectedPath;
                inputdir = inputDir.Text;
            }
            Enable_Run_Button();
        }

        // Set output directory
        private void OutputDir_button_Click(object sender, EventArgs e)
        {
            if (outputDir_prompt.ShowDialog() == DialogResult.OK)
            {
                outputDir.Text = outputDir_prompt.SelectedPath;
                outputdir = outputDir.Text;
            }
            Enable_Run_Button();
        }

        // Set recurse
        private void Recurse_CheckedChanged(object sender, EventArgs e)
        {
            recurse = true;
        }

        // Set function
        public void functionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            function = functionPicker.GetItemText(functionPicker.SelectedItem);
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
            Enable_Run_Button();
        }

        // Enable run button
        private void Enable_Run_Button()
        {
            Run.Enabled = inputdir != "" && outputdir != "" && function != "";
        }

        // Disable input buttons
        private void Disable_Input_Buttons()
        {
            Run.Enabled = false;
            inputDir_button.Enabled = false;
            outputDir_button.Enabled = false;
            functionPicker.Enabled = false;
            Recurse.Enabled = false;
        }

        // Enable input buttons
        private void Enable_Input_Buttons()
        {
            Enable_Run_Button();
            inputDir_button.Enabled = true;
            outputDir_button.Enabled = true;
            functionPicker.Enabled = true;
            Recurse.Enabled = true;
        }

        // Cancel button
        private void Cancel_Click(Object sender, EventArgs e)
        {
            // Cancel the asynchronous operation
            this.backgroundWorker1.CancelAsync();

            // Disable the cancel button
            cancelButton.Enabled = false;
        }

        // Advance and show time
        private void timer_Elapsed(object sender, EventArgs e)
        {
            time = time.Add(TimeSpan.FromSeconds(1));
            timeWindow.Text = String.Format($"{time:dd\\:hh\\:mm\\:ss}");
        }

        // Update process line
        public void echoLine(string text)
        { 
            currentLine.Text = text;
        }

        // Update process log
        public void echoLog(string text)
        {
            resultsWindow.AppendText(Environment.NewLine + text);
        }

        public void ProgressPercentage()
        {
            if (function == "CountConvert")
            {
                convertno = 50;
            }
            else if (function == "CountConvertCompare")
            {
                convertno = 33;
                compareno = 66;
            }
            else if (function == "CountConvertCompareArchive")
            {
                convertno = 25;
                compareno = 50;
                archiveno = 75;
            }
        }
    }
}
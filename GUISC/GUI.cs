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
        public static bool fullcompliance = false;
        public static int countno;
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
            // Clear textboxes
            resultsWindow.Clear();
            currentLine.Clear();

            // Begin process timer
            timer.Start();

            // Inform user of start
            resultsWindow.AppendText("---");
            resultsWindow.AppendText(Environment.NewLine + "GUISC started");
            resultsWindow.AppendText(Environment.NewLine + "---");

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
            Run_Switch(worker);

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
                resultsWindow.AppendText(Environment.NewLine + "---");
                resultsWindow.AppendText(Environment.NewLine + "GUISC was cancelled");
            }
            else if (e.Error != null)
            {
                resultsWindow.AppendText(Environment.NewLine + "---");
                resultsWindow.AppendText(Environment.NewLine + "Error. Details: " + (e.Error as Exception).ToString());
            }
            else
            {
                resultsWindow.AppendText(Environment.NewLine + "GUISC finished");
                resultsWindow.AppendText(Environment.NewLine + "---");
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
            string message = e.UserState as string;
            if (e.ProgressPercentage == 69)
            {
                currentLine.Text = message;
            }
            else
            {
                progressBar.Value = e.ProgressPercentage;
                resultsWindow.AppendText(Environment.NewLine + message);
            }
        }

        // Switch for methods to run
        private void Run_Switch(BackgroundWorker worker)
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
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse, worker);
                    break;

                case "CountConvert":
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse, worker);
                    if (resultsDirectory == "No spreadsheets identified")
                    {
                        break;
                    }
                    con.Convert_Spreadsheets(function, inputdir, recurse, resultsDirectory, worker);
                    res.Convert_Results(worker);
                    break;

                case "CountConvertCompare":
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse, worker);
                    if (resultsDirectory == "No spreadsheets identified")
                    {
                        break;
                    }
                    List<fileIndex> fileList = con.Convert_Spreadsheets(function, inputdir, recurse, resultsDirectory, worker);
                    com.Compare_Spreadsheets(function, resultsDirectory, fileList, worker);
                    res.Compare_Results(worker);
                    break;

                case "CountConvertCompareArchive":
                    resultsDirectory = cou.Count_Spreadsheets(inputdir, outputdir, recurse, worker);
                    if (resultsDirectory == "No spreadsheets identified")
                    {
                        break;
                    }
                    fileList = con.Convert_Spreadsheets(function, inputdir, recurse, resultsDirectory, worker);
                    com.Compare_Spreadsheets(function, resultsDirectory, fileList, worker);
                    arc.Archive_Spreadsheets(resultsDirectory, fileList, worker);
                    res.Archive_Results(worker);
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
            if (!recurse)
            {
                recurse = true;
            }
            else if (recurse)
            {
                recurse = false;
            }
        }

        // Set function
        public void functionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            function = functionPicker.GetItemText(functionPicker.SelectedItem);
            if (function == "Count")
            {
                function = "Count";
                fullCompliance.Visible = false;
            }
            else if (function == "Count & Convert")
            {
                function = "CountConvert";
                fullCompliance.Visible = false;
            }
            else if (function == "Count, Convert & Compare")
            {
                function = "CountConvertCompare";
                fullCompliance.Visible = false;
            }
            else if (function == "Count, Convert, Compare & Archive")
            {
                function = "CountConvertCompareArchive";
                fullCompliance.Visible = true;
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

        // Set progress percentage based on function
        public void ProgressPercentage()
        {
            if (function == "Count")
            {
                countno = 100;
            }
            if (function == "CountConvert")
            {
                countno = 10;
                convertno = 50;
            }
            else if (function == "CountConvertCompare")
            {
                countno = 10;
                convertno = 50;
                compareno = 75;
            }
            else if (function == "CountConvertCompareArchive")
            {
                countno = 10;
                convertno = 40;
                compareno = 60;
                archiveno = 80;
            }
        }

        // Set if all archival requirements are to be complied
        private void fullCompliance_CheckedChanged(object sender, EventArgs e)
        {
            fullcompliance = true;
        }
    }
}
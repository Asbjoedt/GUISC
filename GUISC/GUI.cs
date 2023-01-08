using System;
using System.Diagnostics;
using System.Threading;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using System.Runtime.CompilerServices;

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
            
            // Clear results window
            resultsWindow.Clear();

            // Inform user of start
            resultsWindow.AppendText("GUISC started" + Environment.NewLine);

            // Disable input buttons
            Disable_Input_Buttons();

            // Run the code
            backgroundworker.RunWorkerCompleted += backgroundworker_RunWorkerCompleted;
            backgroundworker.RunWorkerAsync();

            // Stop process timer
            timer.Stop();
        }

        // Run primary methods through backgroundworker
        private void backgroundworker_DoWork(object sender, DoWorkEventArgs e)
        {
            //Check if there is a request to cancel the process
            if (backgroundworker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            // Do backgroundwork
            while (!e.Cancel)
            {
                Run_Switch();

                // Enable open results dir button
                resultsDir_open.Enabled = true;
            }

            // Return if backgroundwork is cancelled
            if (e.Cancel)
            {
                return;
            }
        }

        // Inform user when application ends through backgroundworker
        private void backgroundworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                resultsWindow.AppendText("GUISC was cancelled");
            }
            else if (e.Error != null)
            {
                resultsWindow.AppendText("Error. Details: " + (e.Error as Exception).ToString());
            }
            else
            {
                resultsWindow.AppendText("GUISC ended");
            }
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
            System.Diagnostics.Process.Start("https://github.com/Asbjoedt/GUISC");
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
            functionPicker.Enabled= false;
            Recurse.Enabled= false;
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
        private void Cancel_Click(object sender, EventArgs e)
        {
            // Stop the process
            backgroundworker.CancelAsync();
            backgroundworker.Dispose();

            // Clear results window
            resultsWindow.Clear();
            timeWindow.Clear();

            // Enable input buttons
            Enable_Input_Buttons();
        }

        // Advance and show time
        private void timer_Tick(object sender, EventArgs e)
        {
            time = time.Add(TimeSpan.FromSeconds(1));
            timeWindow.Text = String.Format($"{time:dd\\:hh\\:mm\\:ss}");
        }

        // Update process line
        public void echoLine(string text)
        {
            this.currentLine.AppendText(text + Environment.NewLine);
        }

        // Update process log
        public void echoLog(string text)
        {
            this.resultsWindow.AppendText(text + Environment.NewLine);
        }
    }
}
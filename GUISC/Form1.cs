using System.Windows.Forms;
using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Reflection.Emit;

namespace GUISC
{
    public partial class Function : Form
    {
        // data types
        public static string inputDir_string = "";
        public static string outputDir_string = "";
        public static int function_pick;
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
                inputDir_string = inputDir.Text;
            }
        }
        private void OutputDir_button_Click(object sender, EventArgs e)
        {
            if (outputDir_prompt.ShowDialog() == DialogResult.OK)
            {
                outputDir.Text = outputDir_prompt.SelectedPath;
                outputDir_string = outputDir.Text;
            }
        }
        private void Recurse_CheckedChanged(object sender, EventArgs e)
        {
            recurse = true;
        }

        private void Function_picker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Run_Click(object sender, EventArgs e)
        {
            // Start timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Stopwatch_Tick(sender, e);

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void ResultsDir_open_Click(object sender, EventArgs e)
        {
            if (outputDir_string != "")
            {
                System.Diagnostics.Process.Start(outputDir_string);
            }
        }

        private void Stopwatch_Tick(object sender, EventArgs e)
        {
            timeWindow.Text = stopwatch.Elapsed.Seconds.ToString();
        }
    }
}
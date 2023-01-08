namespace GUISC
{
    partial class Function
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Run = new System.Windows.Forms.Button();
            this.inputDir = new System.Windows.Forms.TextBox();
            this.outputDir = new System.Windows.Forms.TextBox();
            this.resultsWindow = new System.Windows.Forms.RichTextBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Link = new System.Windows.Forms.LinkLabel();
            this.resultsLog_label = new System.Windows.Forms.Label();
            this.Function_label = new System.Windows.Forms.Label();
            this.Recurse = new System.Windows.Forms.CheckBox();
            this.inputDir_button = new System.Windows.Forms.Button();
            this.outputDir_button = new System.Windows.Forms.Button();
            this.currentLine = new System.Windows.Forms.TextBox();
            this.currentProcessLine_label = new System.Windows.Forms.Label();
            this.resultsDir_open = new System.Windows.Forms.Button();
            this.timeWindow = new System.Windows.Forms.TextBox();
            this.timeWindow_label = new System.Windows.Forms.Label();
            this.functionPicker = new System.Windows.Forms.ComboBox();
            this.inputDir_prompt = new System.Windows.Forms.FolderBrowserDialog();
            this.outputDir_prompt = new System.Windows.Forms.FolderBrowserDialog();
            this.backgroundworker = new System.ComponentModel.BackgroundWorker();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Run.Enabled = false;
            this.Run.Location = new System.Drawing.Point(12, 188);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(75, 23);
            this.Run.TabIndex = 0;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // inputDir
            // 
            this.inputDir.Location = new System.Drawing.Point(12, 40);
            this.inputDir.Name = "inputDir";
            this.inputDir.ReadOnly = true;
            this.inputDir.Size = new System.Drawing.Size(404, 23);
            this.inputDir.TabIndex = 1;
            this.inputDir.Text = "Choose input directory";
            // 
            // outputDir
            // 
            this.outputDir.Location = new System.Drawing.Point(12, 69);
            this.outputDir.Name = "outputDir";
            this.outputDir.ReadOnly = true;
            this.outputDir.Size = new System.Drawing.Size(404, 23);
            this.outputDir.TabIndex = 2;
            this.outputDir.Text = "Choose output directory";
            // 
            // resultsWindow
            // 
            this.resultsWindow.Location = new System.Drawing.Point(12, 261);
            this.resultsWindow.Name = "resultsWindow";
            this.resultsWindow.ReadOnly = true;
            this.resultsWindow.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.resultsWindow.Size = new System.Drawing.Size(458, 210);
            this.resultsWindow.TabIndex = 3;
            this.resultsWindow.Text = "";
            // 
            // cancelButton
            // 
            this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelButton.Location = new System.Drawing.Point(93, 188);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 10;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Location = new System.Drawing.Point(12, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(404, 15);
            this.Title.TabIndex = 11;
            this.Title.Text = "Graphical User Interface Spreadsheet Count, Convert, Compare and Archive";
            // 
            // Link
            // 
            this.Link.AutoSize = true;
            this.Link.Location = new System.Drawing.Point(425, 9);
            this.Link.Name = "Link";
            this.Link.Size = new System.Drawing.Size(45, 15);
            this.Link.TabIndex = 12;
            this.Link.TabStop = true;
            this.Link.Text = "GitHub";
            this.Link.Click += new System.EventHandler(this.Link_LinkClicked);
            // 
            // resultsLog_label
            // 
            this.resultsLog_label.AutoSize = true;
            this.resultsLog_label.Location = new System.Drawing.Point(403, 243);
            this.resultsLog_label.Name = "resultsLog_label";
            this.resultsLog_label.Size = new System.Drawing.Size(67, 15);
            this.resultsLog_label.TabIndex = 14;
            this.resultsLog_label.Text = "Process log";
            // 
            // Function_label
            // 
            this.Function_label.AutoSize = true;
            this.Function_label.Location = new System.Drawing.Point(12, 105);
            this.Function_label.Name = "Function_label";
            this.Function_label.Size = new System.Drawing.Size(95, 15);
            this.Function_label.TabIndex = 15;
            this.Function_label.Text = "Choose function";
            // 
            // Recurse
            // 
            this.Recurse.AutoSize = true;
            this.Recurse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Recurse.Location = new System.Drawing.Point(12, 152);
            this.Recurse.Name = "Recurse";
            this.Recurse.Size = new System.Drawing.Size(144, 19);
            this.Recurse.TabIndex = 16;
            this.Recurse.Text = "Recurse subdirectories";
            this.Recurse.UseVisualStyleBackColor = true;
            this.Recurse.CheckedChanged += new System.EventHandler(this.Recurse_CheckedChanged);
            // 
            // inputDir_button
            // 
            this.inputDir_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inputDir_button.Location = new System.Drawing.Point(425, 40);
            this.inputDir_button.Name = "inputDir_button";
            this.inputDir_button.Size = new System.Drawing.Size(45, 23);
            this.inputDir_button.TabIndex = 17;
            this.inputDir_button.Text = "...";
            this.inputDir_button.UseVisualStyleBackColor = true;
            this.inputDir_button.Click += new System.EventHandler(this.InputDir_button_Click);
            // 
            // outputDir_button
            // 
            this.outputDir_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outputDir_button.Location = new System.Drawing.Point(425, 69);
            this.outputDir_button.Name = "outputDir_button";
            this.outputDir_button.Size = new System.Drawing.Size(45, 23);
            this.outputDir_button.TabIndex = 18;
            this.outputDir_button.Text = "...";
            this.outputDir_button.UseVisualStyleBackColor = true;
            this.outputDir_button.Click += new System.EventHandler(this.OutputDir_button_Click);
            // 
            // currentLine
            // 
            this.currentLine.Location = new System.Drawing.Point(12, 217);
            this.currentLine.Name = "currentLine";
            this.currentLine.ReadOnly = true;
            this.currentLine.Size = new System.Drawing.Size(458, 23);
            this.currentLine.TabIndex = 19;
            // 
            // currentProcessLine_label
            // 
            this.currentProcessLine_label.AutoSize = true;
            this.currentProcessLine_label.Location = new System.Drawing.Point(358, 199);
            this.currentProcessLine_label.Name = "currentProcessLine_label";
            this.currentProcessLine_label.Size = new System.Drawing.Size(112, 15);
            this.currentProcessLine_label.TabIndex = 20;
            this.currentProcessLine_label.Text = "Current process line";
            // 
            // resultsDir_open
            // 
            this.resultsDir_open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resultsDir_open.Enabled = false;
            this.resultsDir_open.Location = new System.Drawing.Point(174, 188);
            this.resultsDir_open.Name = "resultsDir_open";
            this.resultsDir_open.Size = new System.Drawing.Size(105, 23);
            this.resultsDir_open.TabIndex = 21;
            this.resultsDir_open.Text = "Results directory";
            this.resultsDir_open.UseVisualStyleBackColor = true;
            this.resultsDir_open.Click += new System.EventHandler(this.ResultsDir_open_Click);
            // 
            // timeWindow
            // 
            this.timeWindow.Location = new System.Drawing.Point(395, 173);
            this.timeWindow.Name = "timeWindow";
            this.timeWindow.ReadOnly = true;
            this.timeWindow.Size = new System.Drawing.Size(75, 23);
            this.timeWindow.TabIndex = 22;
            this.timeWindow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timeWindow_label
            // 
            this.timeWindow_label.AutoSize = true;
            this.timeWindow_label.Location = new System.Drawing.Point(405, 155);
            this.timeWindow_label.Name = "timeWindow_label";
            this.timeWindow_label.Size = new System.Drawing.Size(65, 15);
            this.timeWindow_label.TabIndex = 23;
            this.timeWindow_label.Text = "Time spent";
            // 
            // functionPicker
            // 
            this.functionPicker.FormattingEnabled = true;
            this.functionPicker.Items.AddRange(new object[] {
            "Count",
            "Count & Convert",
            "Count, Convert & Compare",
            "Count, Convert, Compare & Archive"});
            this.functionPicker.Location = new System.Drawing.Point(12, 123);
            this.functionPicker.Name = "functionPicker";
            this.functionPicker.Size = new System.Drawing.Size(267, 23);
            this.functionPicker.TabIndex = 25;
            this.functionPicker.Text = "...";
            this.functionPicker.SelectedIndexChanged += new System.EventHandler(this.functionPicker_SelectedIndexChanged);
            // 
            // backgroundworker
            // 
            this.backgroundworker.WorkerSupportsCancellation = true;
            this.backgroundworker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundworker_DoWork);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Function
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(482, 483);
            this.Controls.Add(this.functionPicker);
            this.Controls.Add(this.timeWindow_label);
            this.Controls.Add(this.timeWindow);
            this.Controls.Add(this.resultsDir_open);
            this.Controls.Add(this.currentProcessLine_label);
            this.Controls.Add(this.currentLine);
            this.Controls.Add(this.outputDir_button);
            this.Controls.Add(this.inputDir_button);
            this.Controls.Add(this.Recurse);
            this.Controls.Add(this.Function_label);
            this.Controls.Add(this.resultsLog_label);
            this.Controls.Add(this.Link);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.resultsWindow);
            this.Controls.Add(this.outputDir);
            this.Controls.Add(this.inputDir);
            this.Controls.Add(this.Run);
            this.Name = "Function";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Run;
        private TextBox inputDir;
        private TextBox outputDir;
        private RichTextBox resultsWindow;
        private Button cancelButton;
        private Label Title;
        private LinkLabel Link;
        private Label resultsLog_label;
        private Label Function_label;
        private CheckBox Recurse;
        private Button inputDir_button;
        private Button outputDir_button;
        private TextBox currentLine;
        private Label currentProcessLine_label;
        private Button resultsDir_open;
        private TextBox timeWindow;
        private Label timeWindow_label;
        private ComboBox functionPicker;
        private FolderBrowserDialog inputDir_prompt;
        private FolderBrowserDialog outputDir_prompt;
        private System.ComponentModel.BackgroundWorker backgroundworker;
        private System.Windows.Forms.Timer timer;
    }
}
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
            components = new System.ComponentModel.Container();
            Run = new Button();
            inputDir = new TextBox();
            outputDir = new TextBox();
            resultsWindow = new RichTextBox();
            cancelButton = new Button();
            Title = new Label();
            Link = new LinkLabel();
            resultsLog_label = new Label();
            Function_label = new Label();
            Recurse = new CheckBox();
            inputDir_button = new Button();
            outputDir_button = new Button();
            currentLine = new TextBox();
            currentProcessLine_label = new Label();
            resultsDir_open = new Button();
            timeWindow = new TextBox();
            timeWindow_label = new Label();
            functionPicker = new ComboBox();
            inputDir_prompt = new FolderBrowserDialog();
            outputDir_prompt = new FolderBrowserDialog();
            timer = new System.Windows.Forms.Timer(components);
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            progressBar = new ProgressBar();
            prgoressBarLabel = new Label();
            fullCompliance = new CheckBox();
            SuspendLayout();
            // 
            // Run
            // 
            Run.Cursor = Cursors.Hand;
            Run.Enabled = false;
            Run.Location = new Point(12, 188);
            Run.Name = "Run";
            Run.Size = new Size(75, 23);
            Run.TabIndex = 0;
            Run.Text = "Run";
            Run.UseVisualStyleBackColor = true;
            Run.Click += Run_Click;
            // 
            // inputDir
            // 
            inputDir.Location = new Point(12, 40);
            inputDir.Name = "inputDir";
            inputDir.ReadOnly = true;
            inputDir.Size = new Size(404, 23);
            inputDir.TabIndex = 1;
            inputDir.Text = "Choose input directory";
            inputDir.WordWrap = false;
            // 
            // outputDir
            // 
            outputDir.Location = new Point(12, 69);
            outputDir.Name = "outputDir";
            outputDir.ReadOnly = true;
            outputDir.Size = new Size(404, 23);
            outputDir.TabIndex = 2;
            outputDir.Text = "Choose output directory";
            outputDir.WordWrap = false;
            // 
            // resultsWindow
            // 
            resultsWindow.Location = new Point(12, 261);
            resultsWindow.Name = "resultsWindow";
            resultsWindow.ReadOnly = true;
            resultsWindow.ScrollBars = RichTextBoxScrollBars.Vertical;
            resultsWindow.Size = new Size(458, 210);
            resultsWindow.TabIndex = 3;
            resultsWindow.Text = "";
            // 
            // cancelButton
            // 
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.Location = new Point(204, 188);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(75, 23);
            cancelButton.TabIndex = 10;
            cancelButton.Text = "Quit";
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += Cancel_Click;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Location = new Point(12, 9);
            Title.Name = "Title";
            Title.Size = new Size(404, 15);
            Title.TabIndex = 11;
            Title.Text = "Graphical User Interface Spreadsheet Count, Convert, Compare and Archive";
            // 
            // Link
            // 
            Link.AutoSize = true;
            Link.Location = new Point(425, 9);
            Link.Name = "Link";
            Link.Size = new Size(45, 15);
            Link.TabIndex = 12;
            Link.TabStop = true;
            Link.Text = "GitHub";
            Link.Click += Link_LinkClicked;
            // 
            // resultsLog_label
            // 
            resultsLog_label.AutoSize = true;
            resultsLog_label.Location = new Point(403, 243);
            resultsLog_label.Name = "resultsLog_label";
            resultsLog_label.Size = new Size(67, 15);
            resultsLog_label.TabIndex = 14;
            resultsLog_label.Text = "Process log";
            // 
            // Function_label
            // 
            Function_label.AutoSize = true;
            Function_label.Location = new Point(12, 105);
            Function_label.Name = "Function_label";
            Function_label.Size = new Size(95, 15);
            Function_label.TabIndex = 15;
            Function_label.Text = "Choose function";
            // 
            // Recurse
            // 
            Recurse.AutoSize = true;
            Recurse.Cursor = Cursors.Hand;
            Recurse.Location = new Point(12, 152);
            Recurse.Name = "Recurse";
            Recurse.Size = new Size(144, 19);
            Recurse.TabIndex = 16;
            Recurse.Text = "Recurse subdirectories";
            Recurse.UseVisualStyleBackColor = true;
            Recurse.CheckedChanged += Recurse_CheckedChanged;
            // 
            // inputDir_button
            // 
            inputDir_button.Cursor = Cursors.Hand;
            inputDir_button.Location = new Point(425, 40);
            inputDir_button.Name = "inputDir_button";
            inputDir_button.Size = new Size(45, 23);
            inputDir_button.TabIndex = 17;
            inputDir_button.Text = "...";
            inputDir_button.UseVisualStyleBackColor = true;
            inputDir_button.Click += InputDir_button_Click;
            // 
            // outputDir_button
            // 
            outputDir_button.Cursor = Cursors.Hand;
            outputDir_button.Location = new Point(425, 69);
            outputDir_button.Name = "outputDir_button";
            outputDir_button.Size = new Size(45, 23);
            outputDir_button.TabIndex = 18;
            outputDir_button.Text = "...";
            outputDir_button.UseVisualStyleBackColor = true;
            outputDir_button.Click += OutputDir_button_Click;
            // 
            // currentLine
            // 
            currentLine.Location = new Point(12, 217);
            currentLine.Name = "currentLine";
            currentLine.ReadOnly = true;
            currentLine.Size = new Size(458, 23);
            currentLine.TabIndex = 19;
            currentLine.WordWrap = false;
            // 
            // currentProcessLine_label
            // 
            currentProcessLine_label.AutoSize = true;
            currentProcessLine_label.Location = new Point(358, 199);
            currentProcessLine_label.Name = "currentProcessLine_label";
            currentProcessLine_label.Size = new Size(112, 15);
            currentProcessLine_label.TabIndex = 20;
            currentProcessLine_label.Text = "Current process line";
            // 
            // resultsDir_open
            // 
            resultsDir_open.Cursor = Cursors.Hand;
            resultsDir_open.Enabled = false;
            resultsDir_open.Location = new Point(93, 188);
            resultsDir_open.Name = "resultsDir_open";
            resultsDir_open.Size = new Size(105, 23);
            resultsDir_open.TabIndex = 21;
            resultsDir_open.Text = "Results directory";
            resultsDir_open.UseVisualStyleBackColor = true;
            resultsDir_open.Click += ResultsDir_open_Click;
            // 
            // timeWindow
            // 
            timeWindow.Location = new Point(395, 127);
            timeWindow.Name = "timeWindow";
            timeWindow.ReadOnly = true;
            timeWindow.Size = new Size(75, 23);
            timeWindow.TabIndex = 22;
            timeWindow.TextAlign = HorizontalAlignment.Center;
            // 
            // timeWindow_label
            // 
            timeWindow_label.AutoSize = true;
            timeWindow_label.Location = new Point(405, 109);
            timeWindow_label.Name = "timeWindow_label";
            timeWindow_label.Size = new Size(65, 15);
            timeWindow_label.TabIndex = 23;
            timeWindow_label.Text = "Time spent";
            // 
            // functionPicker
            // 
            functionPicker.FormattingEnabled = true;
            functionPicker.Items.AddRange(new object[] { "Count", "Count & Convert", "Count, Convert & Compare", "Count, Convert, Compare & Archive" });
            functionPicker.Location = new Point(12, 123);
            functionPicker.Name = "functionPicker";
            functionPicker.Size = new Size(267, 23);
            functionPicker.TabIndex = 25;
            functionPicker.Text = "...";
            functionPicker.SelectedIndexChanged += functionPicker_SelectedIndexChanged;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Elapsed;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(370, 173);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(100, 23);
            progressBar.TabIndex = 26;
            // 
            // prgoressBarLabel
            // 
            prgoressBarLabel.AutoSize = true;
            prgoressBarLabel.Location = new Point(398, 153);
            prgoressBarLabel.Name = "prgoressBarLabel";
            prgoressBarLabel.Size = new Size(72, 15);
            prgoressBarLabel.TabIndex = 27;
            prgoressBarLabel.Text = "Progress bar";
            // 
            // fullCompliance
            // 
            fullCompliance.AutoSize = true;
            fullCompliance.Location = new Point(162, 152);
            fullCompliance.Name = "fullCompliance";
            fullCompliance.Size = new Size(110, 19);
            fullCompliance.TabIndex = 28;
            fullCompliance.Text = "Full compliance";
            fullCompliance.UseVisualStyleBackColor = true;
            fullCompliance.Visible = false;
            fullCompliance.CheckedChanged += fullCompliance_CheckedChanged;
            // 
            // Function
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new Size(482, 483);
            Controls.Add(fullCompliance);
            Controls.Add(prgoressBarLabel);
            Controls.Add(progressBar);
            Controls.Add(functionPicker);
            Controls.Add(timeWindow_label);
            Controls.Add(timeWindow);
            Controls.Add(resultsDir_open);
            Controls.Add(currentProcessLine_label);
            Controls.Add(currentLine);
            Controls.Add(outputDir_button);
            Controls.Add(inputDir_button);
            Controls.Add(Recurse);
            Controls.Add(Function_label);
            Controls.Add(resultsLog_label);
            Controls.Add(Link);
            Controls.Add(Title);
            Controls.Add(cancelButton);
            Controls.Add(resultsWindow);
            Controls.Add(outputDir);
            Controls.Add(inputDir);
            Controls.Add(Run);
            Name = "Function";
            ResumeLayout(false);
            PerformLayout();
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
        private Label timeWindow_label;
        private ComboBox functionPicker;
        private FolderBrowserDialog inputDir_prompt;
        private FolderBrowserDialog outputDir_prompt;
        private System.Windows.Forms.Timer timer;
        public TextBox timeWindow;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ProgressBar progressBar;
        private Label prgoressBarLabel;
        private CheckBox fullCompliance;
    }
}
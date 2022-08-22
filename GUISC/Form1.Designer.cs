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
            this.Run = new System.Windows.Forms.Button();
            this.inputDir = new System.Windows.Forms.TextBox();
            this.outputDir = new System.Windows.Forms.TextBox();
            this.resultsWindow = new System.Windows.Forms.RichTextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Cancel = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.Link = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Recurse = new System.Windows.Forms.CheckBox();
            this.inputDir_button = new System.Windows.Forms.Button();
            this.outputDir_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.outputDir_open = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Stopwatch = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.inputDir_prompt = new System.Windows.Forms.FolderBrowserDialog();
            this.outputDir_prompt = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.inputDir.Size = new System.Drawing.Size(404, 23);
            this.inputDir.TabIndex = 1;
            this.inputDir.Text = "Choose input directory";
            // 
            // outputDir
            // 
            this.outputDir.Location = new System.Drawing.Point(12, 69);
            this.outputDir.Name = "outputDir";
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
            // progressBar
            // 
            this.progressBar.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.progressBar.Location = new System.Drawing.Point(395, 173);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(75, 23);
            this.progressBar.TabIndex = 9;
            // 
            // Cancel
            // 
            this.Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Cancel.Location = new System.Drawing.Point(93, 188);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 10;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
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
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Results log";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "Choose function";
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
            this.inputDir_button.Click += new System.EventHandler(this.inputDir_button_Click);
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
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 217);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(458, 23);
            this.textBox1.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(358, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Current process line";
            // 
            // outputDir_open
            // 
            this.outputDir_open.Cursor = System.Windows.Forms.Cursors.Hand;
            this.outputDir_open.Location = new System.Drawing.Point(174, 188);
            this.outputDir_open.Name = "outputDir_open";
            this.outputDir_open.Size = new System.Drawing.Size(105, 23);
            this.outputDir_open.TabIndex = 21;
            this.outputDir_open.Text = "Open results dir";
            this.outputDir_open.UseVisualStyleBackColor = true;
            this.outputDir_open.Click += new System.EventHandler(this.outputDir_open_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(395, 129);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(75, 23);
            this.textBox2.TabIndex = 22;
            // 
            // Stopwatch
            // 
            this.Stopwatch.AutoSize = true;
            this.Stopwatch.Location = new System.Drawing.Point(405, 111);
            this.Stopwatch.Name = "Stopwatch";
            this.Stopwatch.Size = new System.Drawing.Size(65, 15);
            this.Stopwatch.TabIndex = 23;
            this.Stopwatch.Text = "Time spent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(398, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 24;
            this.label4.Text = "Progress bar";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Count",
            "Count and convert",
            "Count, convert and compre",
            "Count, convert, compare and archive"});
            this.comboBox1.Location = new System.Drawing.Point(12, 123);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 23);
            this.comboBox1.TabIndex = 25;
            // 
            // Function
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 483);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Stopwatch);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.outputDir_open);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.outputDir_button);
            this.Controls.Add(this.inputDir_button);
            this.Controls.Add(this.Recurse);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Link);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.resultsWindow);
            this.Controls.Add(this.outputDir);
            this.Controls.Add(this.inputDir);
            this.Controls.Add(this.Run);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Function";
            this.Text = "Choose                                                                           " +
    "                     ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Run;
        private TextBox inputDir;
        private TextBox outputDir;
        private RichTextBox resultsWindow;
        private ProgressBar progressBar;
        private Button Cancel;
        private Label Title;
        private LinkLabel Link;
        private Label label2;
        private Label label3;
        private CheckBox Recurse;
        private Button inputDir_button;
        private Button outputDir_button;
        private TextBox textBox1;
        private Label label1;
        private Button outputDir_open;
        private TextBox textBox2;
        private Label Stopwatch;
        private Label label4;
        private ComboBox comboBox1;
        private FolderBrowserDialog inputDir_prompt;
        private FolderBrowserDialog outputDir_prompt;
    }
}
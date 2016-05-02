namespace FileKiller
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_NumOfFiles = new System.Windows.Forms.Label();
            this.label_NumOfFilesTitle = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Btn_CancelAction = new System.Windows.Forms.Button();
            this.button_SelectDirs = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button_ClearGrid = new System.Windows.Forms.Button();
            this.button_SelectFiles = new System.Windows.Forms.Button();
            this.button_Quit = new System.Windows.Forms.Button();
            this.Button_KillFiles = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FileDir = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Processed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1_excludeLine = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_SaveParams = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_includeSubDirs = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_DataBuffer = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_letter = new System.Windows.Forms.Label();
            this.radioButton_ASCII = new System.Windows.Forms.RadioButton();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.radioButton_RandomData = new System.Windows.Forms.RadioButton();
            this.radioButton_Blanks = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Select Files to be killed";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_NumOfFiles);
            this.panel2.Controls.Add(this.label_NumOfFilesTitle);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 327);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(885, 38);
            this.panel2.TabIndex = 2;
            // 
            // label_NumOfFiles
            // 
            this.label_NumOfFiles.AutoSize = true;
            this.label_NumOfFiles.Location = new System.Drawing.Point(143, 10);
            this.label_NumOfFiles.Name = "label_NumOfFiles";
            this.label_NumOfFiles.Size = new System.Drawing.Size(13, 13);
            this.label_NumOfFiles.TabIndex = 1;
            this.label_NumOfFiles.Text = "0";
            // 
            // label_NumOfFilesTitle
            // 
            this.label_NumOfFilesTitle.AutoSize = true;
            this.label_NumOfFilesTitle.Location = new System.Drawing.Point(16, 10);
            this.label_NumOfFilesTitle.Name = "label_NumOfFilesTitle";
            this.label_NumOfFilesTitle.Size = new System.Drawing.Size(123, 13);
            this.label_NumOfFilesTitle.TabIndex = 0;
            this.label_NumOfFilesTitle.Text = "Number of selected files:";
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.Description = "Choose the temporary directory";
            this.folderBrowserDialog1.SelectedPath = "c:\\temp";
            // 
            // tabPage1
            // 
            this.tabPage1.AllowDrop = true;
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(877, 301);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 295);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Btn_CancelAction);
            this.splitContainer1.Panel1.Controls.Add(this.button_SelectDirs);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.button_ClearGrid);
            this.splitContainer1.Panel1.Controls.Add(this.button_SelectFiles);
            this.splitContainer1.Panel1.Controls.Add(this.button_Quit);
            this.splitContainer1.Panel1.Controls.Add(this.Button_KillFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(871, 295);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 0;
            // 
            // Btn_CancelAction
            // 
            this.Btn_CancelAction.Location = new System.Drawing.Point(29, 129);
            this.Btn_CancelAction.Name = "Btn_CancelAction";
            this.Btn_CancelAction.Size = new System.Drawing.Size(86, 24);
            this.Btn_CancelAction.TabIndex = 8;
            this.Btn_CancelAction.Text = "Cancel Action";
            this.Btn_CancelAction.UseVisualStyleBackColor = true;
            this.Btn_CancelAction.Click += new System.EventHandler(this.Btn_CancelAction_Click);
            // 
            // button_SelectDirs
            // 
            this.button_SelectDirs.Location = new System.Drawing.Point(12, 41);
            this.button_SelectDirs.Name = "button_SelectDirs";
            this.button_SelectDirs.Size = new System.Drawing.Size(127, 23);
            this.button_SelectDirs.TabIndex = 7;
            this.button_SelectDirs.Text = "Select Directories";
            this.button_SelectDirs.UseVisualStyleBackColor = true;
            this.button_SelectDirs.Click += new System.EventHandler(this.button_SelectDirs_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 235);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_ClearGrid
            // 
            this.button_ClearGrid.Location = new System.Drawing.Point(12, 206);
            this.button_ClearGrid.Name = "button_ClearGrid";
            this.button_ClearGrid.Size = new System.Drawing.Size(127, 23);
            this.button_ClearGrid.TabIndex = 4;
            this.button_ClearGrid.Text = "Clear Grid";
            this.button_ClearGrid.UseVisualStyleBackColor = true;
            this.button_ClearGrid.Click += new System.EventHandler(this.button_ClearGrid_Click);
            // 
            // button_SelectFiles
            // 
            this.button_SelectFiles.Location = new System.Drawing.Point(12, 12);
            this.button_SelectFiles.Name = "button_SelectFiles";
            this.button_SelectFiles.Size = new System.Drawing.Size(127, 23);
            this.button_SelectFiles.TabIndex = 0;
            this.button_SelectFiles.Text = "Select Files";
            this.button_SelectFiles.UseVisualStyleBackColor = true;
            this.button_SelectFiles.Click += new System.EventHandler(this.button_Select_Click);
            // 
            // button_Quit
            // 
            this.button_Quit.Location = new System.Drawing.Point(12, 264);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(127, 23);
            this.button_Quit.TabIndex = 6;
            this.button_Quit.Text = "Quit";
            this.button_Quit.UseVisualStyleBackColor = true;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // Button_KillFiles
            // 
            this.Button_KillFiles.ForeColor = System.Drawing.Color.Red;
            this.Button_KillFiles.Location = new System.Drawing.Point(12, 88);
            this.Button_KillFiles.Name = "Button_KillFiles";
            this.Button_KillFiles.Size = new System.Drawing.Size(127, 23);
            this.Button_KillFiles.TabIndex = 1;
            this.Button_KillFiles.Text = "KILL Files on Grid >>";
            this.Button_KillFiles.UseVisualStyleBackColor = true;
            this.Button_KillFiles.Click += new System.EventHandler(this.Button_KillFiles_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FileDir,
            this.Column_Filename,
            this.Info,
            this.Processed});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(696, 295);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsRemoved);
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragOver += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragOver);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // FileDir
            // 
            this.FileDir.HeaderText = "File/Dir";
            this.FileDir.Name = "FileDir";
            this.FileDir.ReadOnly = true;
            this.FileDir.Width = 50;
            // 
            // Column_Filename
            // 
            this.Column_Filename.FillWeight = 500F;
            this.Column_Filename.HeaderText = "FILES TO BE KILLED";
            this.Column_Filename.MinimumWidth = 10;
            this.Column_Filename.Name = "Column_Filename";
            this.Column_Filename.ReadOnly = true;
            this.Column_Filename.Width = 300;
            // 
            // Info
            // 
            this.Info.HeaderText = "INFO";
            this.Info.MinimumWidth = 10;
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            this.Info.Width = 300;
            // 
            // Processed
            // 
            this.Processed.HeaderText = "Processed";
            this.Processed.Name = "Processed";
            this.Processed.ReadOnly = true;
            this.Processed.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1_excludeLine});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(187, 26);
            // 
            // toolStripMenuItem1_excludeLine
            // 
            this.toolStripMenuItem1_excludeLine.Name = "toolStripMenuItem1_excludeLine";
            this.toolStripMenuItem1_excludeLine.Size = new System.Drawing.Size(186, 22);
            this.toolStripMenuItem1_excludeLine.Text = "Exclude Selected Line";
            this.toolStripMenuItem1_excludeLine.Click += new System.EventHandler(this.toolStripMenuItem1_excludeLine_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.AllowDrop = true;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(885, 327);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_SaveParams);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(877, 301);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_SaveParams
            // 
            this.btn_SaveParams.Location = new System.Drawing.Point(15, 192);
            this.btn_SaveParams.Name = "btn_SaveParams";
            this.btn_SaveParams.Size = new System.Drawing.Size(97, 23);
            this.btn_SaveParams.TabIndex = 12;
            this.btn_SaveParams.Text = "Save Params";
            this.btn_SaveParams.UseVisualStyleBackColor = true;
            this.btn_SaveParams.Click += new System.EventHandler(this.btn_SaveParams_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_includeSubDirs);
            this.groupBox3.Location = new System.Drawing.Point(202, 58);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 106);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "When selecting directories...";
            // 
            // checkBox_includeSubDirs
            // 
            this.checkBox_includeSubDirs.AutoSize = true;
            this.checkBox_includeSubDirs.Checked = true;
            this.checkBox_includeSubDirs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_includeSubDirs.Location = new System.Drawing.Point(20, 42);
            this.checkBox_includeSubDirs.Name = "checkBox_includeSubDirs";
            this.checkBox_includeSubDirs.Size = new System.Drawing.Size(129, 17);
            this.checkBox_includeSubDirs.TabIndex = 0;
            this.checkBox_includeSubDirs.Text = "Incude Subdirectories";
            this.checkBox_includeSubDirs.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbx_DataBuffer);
            this.groupBox2.Location = new System.Drawing.Point(389, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 106);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Data Buffer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "KBytes";
            // 
            // tbx_DataBuffer
            // 
            this.tbx_DataBuffer.Location = new System.Drawing.Point(23, 42);
            this.tbx_DataBuffer.Mask = "000000";
            this.tbx_DataBuffer.Name = "tbx_DataBuffer";
            this.tbx_DataBuffer.Size = new System.Drawing.Size(65, 20);
            this.tbx_DataBuffer.TabIndex = 0;
            this.tbx_DataBuffer.Text = "1024";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_letter);
            this.groupBox1.Controls.Add(this.radioButton_ASCII);
            this.groupBox1.Controls.Add(this.numericUpDown2);
            this.groupBox1.Controls.Add(this.radioButton_RandomData);
            this.groupBox1.Controls.Add(this.radioButton_Blanks);
            this.groupBox1.Location = new System.Drawing.Point(15, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 108);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fill the file with...";
            // 
            // label_letter
            // 
            this.label_letter.AutoSize = true;
            this.label_letter.Enabled = false;
            this.label_letter.ForeColor = System.Drawing.Color.Blue;
            this.label_letter.Location = new System.Drawing.Point(126, 73);
            this.label_letter.Name = "label_letter";
            this.label_letter.Size = new System.Drawing.Size(14, 13);
            this.label_letter.TabIndex = 9;
            this.label_letter.Text = "A";
            // 
            // radioButton_ASCII
            // 
            this.radioButton_ASCII.AutoSize = true;
            this.radioButton_ASCII.Location = new System.Drawing.Point(6, 69);
            this.radioButton_ASCII.Name = "radioButton_ASCII";
            this.radioButton_ASCII.Size = new System.Drawing.Size(52, 17);
            this.radioButton_ASCII.TabIndex = 8;
            this.radioButton_ASCII.Text = "ASCII";
            this.radioButton_ASCII.UseVisualStyleBackColor = true;
            this.radioButton_ASCII.CheckedChanged += new System.EventHandler(this.radioButton_ASCII_CheckedChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.AccessibleDescription = "";
            this.numericUpDown2.Enabled = false;
            this.numericUpDown2.Location = new System.Drawing.Point(75, 69);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(45, 20);
            this.numericUpDown2.TabIndex = 7;
            this.numericUpDown2.Tag = "";
            this.numericUpDown2.Value = new decimal(new int[] {
            65,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // radioButton_RandomData
            // 
            this.radioButton_RandomData.AutoSize = true;
            this.radioButton_RandomData.Checked = true;
            this.radioButton_RandomData.Location = new System.Drawing.Point(6, 19);
            this.radioButton_RandomData.Name = "radioButton_RandomData";
            this.radioButton_RandomData.Size = new System.Drawing.Size(91, 17);
            this.radioButton_RandomData.TabIndex = 0;
            this.radioButton_RandomData.TabStop = true;
            this.radioButton_RandomData.Text = "Random Data";
            this.radioButton_RandomData.UseVisualStyleBackColor = true;
            // 
            // radioButton_Blanks
            // 
            this.radioButton_Blanks.AutoSize = true;
            this.radioButton_Blanks.Location = new System.Drawing.Point(6, 44);
            this.radioButton_Blanks.Name = "radioButton_Blanks";
            this.radioButton_Blanks.Size = new System.Drawing.Size(57, 17);
            this.radioButton_Blanks.TabIndex = 1;
            this.radioButton_Blanks.Text = "Blanks";
            this.radioButton_Blanks.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Number of Delete Iterations (1 to 100)";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.AccessibleDescription = "";
            this.numericUpDown1.Location = new System.Drawing.Point(202, 22);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(44, 20);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Tag = "";
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AcceptButton = this.button_SelectFiles;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 365);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileKiller v. 2.0 - (c) A.Venieris";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_NumOfFiles;
        private System.Windows.Forms.Label label_NumOfFilesTitle;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_SelectDirs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_ClearGrid;
        private System.Windows.Forms.Button button_SelectFiles;
        private System.Windows.Forms.Button button_Quit;
        private System.Windows.Forms.Button Button_KillFiles;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox_includeSubDirs;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbx_DataBuffer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_letter;
        private System.Windows.Forms.RadioButton radioButton_ASCII;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.RadioButton radioButton_RandomData;
        private System.Windows.Forms.RadioButton radioButton_Blanks;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1_excludeLine;
        private System.Windows.Forms.Button Btn_CancelAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileDir;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn Processed;
        private System.Windows.Forms.Button btn_SaveParams;
    }
}


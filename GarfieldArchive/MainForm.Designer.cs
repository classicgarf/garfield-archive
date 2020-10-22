namespace GarfieldArchive
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.outputDir = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.convertChoose = new System.Windows.Forms.CheckBox();
            this.chooseISO = new System.Windows.Forms.CheckBox();
            this.monthFolders = new System.Windows.Forms.CheckBox();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.dateLabel = new System.Windows.Forms.Label();
            this.optionsBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.optionsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(387, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ChooseOutputDir_Click);
            // 
            // outputDir
            // 
            this.outputDir.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outputDir.Location = new System.Drawing.Point(3, 3);
            this.outputDir.Name = "outputDir";
            this.outputDir.Size = new System.Drawing.Size(378, 20);
            this.outputDir.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 45);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save downloaded strips to:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.outputDir, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(421, 26);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(427, 133);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download progress";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(9, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(409, 98);
            this.dataGridView1.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(12, 330);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(427, 32);
            this.button2.TabIndex = 4;
            this.button2.Text = "Start download";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.StartDownload_Click);
            // 
            // convertChoose
            // 
            this.convertChoose.AccessibleName = "Convert all strips to PNG format.";
            this.convertChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.convertChoose.AutoSize = true;
            this.convertChoose.Checked = true;
            this.convertChoose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.convertChoose.Location = new System.Drawing.Point(6, 19);
            this.convertChoose.Name = "convertChoose";
            this.convertChoose.Size = new System.Drawing.Size(235, 17);
            this.convertChoose.TabIndex = 5;
            this.convertChoose.Text = "Convert strips from GIF format to PNG format";
            this.convertChoose.UseVisualStyleBackColor = true;
            this.convertChoose.CheckedChanged += new System.EventHandler(this.ConvertChoose_CheckedChanged);
            // 
            // chooseISO
            // 
            this.chooseISO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseISO.AutoSize = true;
            this.chooseISO.Checked = true;
            this.chooseISO.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chooseISO.Location = new System.Drawing.Point(6, 42);
            this.chooseISO.Name = "chooseISO";
            this.chooseISO.Size = new System.Drawing.Size(266, 17);
            this.chooseISO.TabIndex = 6;
            this.chooseISO.Text = "Convert names from gaYYMMDD to YYYY-MM-DD";
            this.chooseISO.UseVisualStyleBackColor = true;
            this.chooseISO.CheckedChanged += new System.EventHandler(this.chooseISO_CheckedChanged);
            // 
            // monthFolders
            // 
            this.monthFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monthFolders.AutoSize = true;
            this.monthFolders.Checked = true;
            this.monthFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.monthFolders.Location = new System.Drawing.Point(6, 65);
            this.monthFolders.Name = "monthFolders";
            this.monthFolders.Size = new System.Drawing.Size(181, 17);
            this.monthFolders.TabIndex = 7;
            this.monthFolders.Text = "Sort comics into folders by month";
            this.monthFolders.UseVisualStyleBackColor = true;
            this.monthFolders.CheckedChanged += new System.EventHandler(this.monthFolders_CheckedChanged);
            // 
            // startDate
            // 
            this.startDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDate.Location = new System.Drawing.Point(6, 99);
            this.startDate.MinDate = new System.DateTime(1978, 6, 19, 0, 0, 0, 0);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(104, 20);
            this.startDate.TabIndex = 8;
            this.startDate.Value = new System.DateTime(1978, 6, 19, 0, 0, 0, 0);
            this.startDate.ValueChanged += new System.EventHandler(this.startDate_ValueChanged);
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(3, 85);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(55, 13);
            this.dateLabel.TabIndex = 9;
            this.dateLabel.Text = "Start Date";
            this.dateLabel.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // optionsBox
            // 
            this.optionsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.optionsBox.Controls.Add(this.convertChoose);
            this.optionsBox.Controls.Add(this.dateLabel);
            this.optionsBox.Controls.Add(this.chooseISO);
            this.optionsBox.Controls.Add(this.startDate);
            this.optionsBox.Controls.Add(this.monthFolders);
            this.optionsBox.Location = new System.Drawing.Point(12, 198);
            this.optionsBox.Name = "optionsBox";
            this.optionsBox.Size = new System.Drawing.Size(427, 126);
            this.optionsBox.TabIndex = 10;
            this.optionsBox.TabStop = false;
            this.optionsBox.Text = "Options";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 374);
            this.Controls.Add(this.optionsBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaximumSize = new System.Drawing.Size(467, 99999);
            this.MinimumSize = new System.Drawing.Size(467, 375);
            this.Name = "MainForm";
            this.Text = "Garfield Downloader";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.optionsBox.ResumeLayout(false);
            this.optionsBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox outputDir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox convertChoose;
        private System.Windows.Forms.CheckBox chooseISO;
        private System.Windows.Forms.CheckBox monthFolders;
        private System.Windows.Forms.GroupBox optionsBox;
        private System.Windows.Forms.Label dateLabel;
        public System.Windows.Forms.DateTimePicker startDate;
    }
}


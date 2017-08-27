namespace BarcodeAttendance
{
    partial class AddStudent
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
            this.labelStdId = new System.Windows.Forms.Label();
            this.labelCourse = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pbStudentImage = new System.Windows.Forms.PictureBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.cmbCourse = new System.Windows.Forms.ComboBox();
            this.rbFirst = new System.Windows.Forms.RadioButton();
            this.rbThird = new System.Windows.Forms.RadioButton();
            this.rbSecond = new System.Windows.Forms.RadioButton();
            this.rbFour = new System.Windows.Forms.RadioButton();
            this.grpBoxYear = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.maskedStdId = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentImage)).BeginInit();
            this.grpBoxYear.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelStdId
            // 
            this.labelStdId.AutoSize = true;
            this.labelStdId.Location = new System.Drawing.Point(62, 114);
            this.labelStdId.Name = "labelStdId";
            this.labelStdId.Size = new System.Drawing.Size(58, 13);
            this.labelStdId.TabIndex = 0;
            this.labelStdId.Text = "Student ID";
            // 
            // labelCourse
            // 
            this.labelCourse.AutoSize = true;
            this.labelCourse.Location = new System.Drawing.Point(65, 166);
            this.labelCourse.Name = "labelCourse";
            this.labelCourse.Size = new System.Drawing.Size(40, 13);
            this.labelCourse.TabIndex = 1;
            this.labelCourse.Text = "Course";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(68, 212);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Name";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Rosewood Std Regular", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblTitle.Location = new System.Drawing.Point(193, 51);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(105, 19);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Add Student";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(177, 212);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(210, 20);
            this.txtName.TabIndex = 3;
            // 
            // pbStudentImage
            // 
            this.pbStudentImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbStudentImage.Location = new System.Drawing.Point(413, 106);
            this.pbStudentImage.Name = "pbStudentImage";
            this.pbStudentImage.Size = new System.Drawing.Size(114, 126);
            this.pbStudentImage.TabIndex = 7;
            this.pbStudentImage.TabStop = false;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(68, 255);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(29, 13);
            this.labelYear.TabIndex = 8;
            this.labelYear.Text = "Year";
            // 
            // cmbCourse
            // 
            this.cmbCourse.FormattingEnabled = true;
            this.cmbCourse.Items.AddRange(new object[] {
            "B.Tech",
            "Bio.Tech",
            "M.B.A.",
            "B.Pharm"});
            this.cmbCourse.Location = new System.Drawing.Point(177, 166);
            this.cmbCourse.Name = "cmbCourse";
            this.cmbCourse.Size = new System.Drawing.Size(211, 21);
            this.cmbCourse.TabIndex = 2;
            // 
            // rbFirst
            // 
            this.rbFirst.AutoSize = true;
            this.rbFirst.Location = new System.Drawing.Point(6, 19);
            this.rbFirst.Name = "rbFirst";
            this.rbFirst.Size = new System.Drawing.Size(64, 17);
            this.rbFirst.TabIndex = 4;
            this.rbFirst.TabStop = true;
            this.rbFirst.Text = "1st Year";
            this.rbFirst.UseVisualStyleBackColor = true;
            // 
            // rbThird
            // 
            this.rbThird.AutoSize = true;
            this.rbThird.Location = new System.Drawing.Point(6, 42);
            this.rbThird.Name = "rbThird";
            this.rbThird.Size = new System.Drawing.Size(63, 17);
            this.rbThird.TabIndex = 6;
            this.rbThird.TabStop = true;
            this.rbThird.Text = "3rd year";
            this.rbThird.UseVisualStyleBackColor = true;
            // 
            // rbSecond
            // 
            this.rbSecond.AutoSize = true;
            this.rbSecond.Location = new System.Drawing.Point(109, 19);
            this.rbSecond.Name = "rbSecond";
            this.rbSecond.Size = new System.Drawing.Size(66, 17);
            this.rbSecond.TabIndex = 5;
            this.rbSecond.TabStop = true;
            this.rbSecond.Text = "2nd year";
            this.rbSecond.UseVisualStyleBackColor = true;
            // 
            // rbFour
            // 
            this.rbFour.AutoSize = true;
            this.rbFour.Location = new System.Drawing.Point(109, 42);
            this.rbFour.Name = "rbFour";
            this.rbFour.Size = new System.Drawing.Size(65, 17);
            this.rbFour.TabIndex = 7;
            this.rbFour.TabStop = true;
            this.rbFour.Text = "4th Year";
            this.rbFour.UseVisualStyleBackColor = true;
            // 
            // grpBoxYear
            // 
            this.grpBoxYear.Controls.Add(this.rbFirst);
            this.grpBoxYear.Controls.Add(this.rbSecond);
            this.grpBoxYear.Controls.Add(this.rbFour);
            this.grpBoxYear.Controls.Add(this.rbThird);
            this.grpBoxYear.Location = new System.Drawing.Point(177, 255);
            this.grpBoxYear.Name = "grpBoxYear";
            this.grpBoxYear.Size = new System.Drawing.Size(211, 75);
            this.grpBoxYear.TabIndex = 14;
            this.grpBoxYear.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(413, 255);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(113, 23);
            this.btnBrowse.TabIndex = 8;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(308, 407);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(183, 407);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // maskedStdId
            // 
            this.maskedStdId.Location = new System.Drawing.Point(177, 106);
            this.maskedStdId.Mask = "0000000000";
            this.maskedStdId.Name = "maskedStdId";
            this.maskedStdId.Size = new System.Drawing.Size(210, 20);
            this.maskedStdId.TabIndex = 1;
            // 
            // AddStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 505);
            this.Controls.Add(this.maskedStdId);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.grpBoxYear);
            this.Controls.Add(this.cmbCourse);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.pbStudentImage);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelCourse);
            this.Controls.Add(this.labelStdId);
            this.Name = "AddStudent";
            this.Text = "New Student";
            this.Load += new System.EventHandler(this.AddStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentImage)).EndInit();
            this.grpBoxYear.ResumeLayout(false);
            this.grpBoxYear.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStdId;
        private System.Windows.Forms.Label labelCourse;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.PictureBox pbStudentImage;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.ComboBox cmbCourse;
        private System.Windows.Forms.RadioButton rbFirst;
        private System.Windows.Forms.RadioButton rbThird;
        private System.Windows.Forms.RadioButton rbSecond;
        private System.Windows.Forms.RadioButton rbFour;
        private System.Windows.Forms.GroupBox grpBoxYear;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.MaskedTextBox maskedStdId;
    }
}
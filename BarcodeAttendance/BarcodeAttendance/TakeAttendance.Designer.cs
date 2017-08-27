namespace BarcodeAttendance
{
    partial class TakeAttendance
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
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.qrWebcam = new WebcamQRCodeScanner.QRWebCamControl();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.lblStudentName = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.pbStudentPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSource
            // 
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(169, 12);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(206, 21);
            this.cmbSource.TabIndex = 0;
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.cmbSource_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Camera Source";
            // 
            // qrWebcam
            // 
            this.qrWebcam.Location = new System.Drawing.Point(12, 39);
            this.qrWebcam.Name = "qrWebcam";
            this.qrWebcam.Size = new System.Drawing.Size(444, 203);
            this.qrWebcam.Status = "";
            this.qrWebcam.TabIndex = 1;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Location = new System.Drawing.Point(12, 258);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(34, 13);
            this.lblStudentID.TabIndex = 4;
            this.lblStudentID.Text = "         ";
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Location = new System.Drawing.Point(12, 289);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(34, 13);
            this.lblStudentName.TabIndex = 4;
            this.lblStudentName.Text = "         ";
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Location = new System.Drawing.Point(12, 319);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(34, 13);
            this.lblCourse.TabIndex = 4;
            this.lblCourse.Text = "         ";
            // 
            // pbStudentPicture
            // 
            this.pbStudentPicture.Location = new System.Drawing.Point(308, 289);
            this.pbStudentPicture.Name = "pbStudentPicture";
            this.pbStudentPicture.Size = new System.Drawing.Size(108, 108);
            this.pbStudentPicture.TabIndex = 5;
            this.pbStudentPicture.TabStop = false;
            // 
            // TakeAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 454);
            this.Controls.Add(this.pbStudentPicture);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.lblStudentID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qrWebcam);
            this.Controls.Add(this.cmbSource);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TakeAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Take Attendance";
            this.Load += new System.EventHandler(this.TakeAttendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbStudentPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.Label label1;
        private WebcamQRCodeScanner.QRWebCamControl qrWebcam;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.Label lblStudentName;
        private System.Windows.Forms.Label lblCourse;
        private System.Windows.Forms.PictureBox pbStudentPicture;
    }
}
namespace C969Rebekah
{
    partial class AppointmentForm
    {
        /// <summary>
        /// Required designer variable
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources
        /// </summary>
        /// <param name="disposing">true if managed resource should cleaned up and if not then false</param>
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
            this.apptEndTxt = new System.Windows.Forms.RichTextBox();
            this.apptCustNameLbl = new System.Windows.Forms.Label();
            this.apptTypeLbl = new System.Windows.Forms.Label();
            this.apptStartLbl = new System.Windows.Forms.Label();
            this.apptEndLbl = new System.Windows.Forms.Label();
            this.cancelApptBtn = new System.Windows.Forms.Button();
            this.saveApptBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.custCB = new System.Windows.Forms.ComboBox();
            this.typeCB = new System.Windows.Forms.ComboBox();
            this.startTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endTimePicker = new System.Windows.Forms.DateTimePicker();
            this.errorLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // apptEndTxt
            // 
            this.apptEndTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptEndTxt.Location = new System.Drawing.Point(191, 228);
            this.apptEndTxt.Name = "apptEndTxt";
            this.apptEndTxt.Size = new System.Drawing.Size(1, 1);
            this.apptEndTxt.TabIndex = 6;
            this.apptEndTxt.Text = "";
            // 
            // apptCustNameLbl
            // 
            this.apptCustNameLbl.AutoSize = true;
            this.apptCustNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptCustNameLbl.Location = new System.Drawing.Point(20, 111);
            this.apptCustNameLbl.Name = "apptCustNameLbl";
            this.apptCustNameLbl.Size = new System.Drawing.Size(154, 25);
            this.apptCustNameLbl.TabIndex = 12;
            this.apptCustNameLbl.Text = "Customer Name";
            // 
            // apptTypeLbl
            // 
            this.apptTypeLbl.AutoSize = true;
            this.apptTypeLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptTypeLbl.Location = new System.Drawing.Point(128, 148);
            this.apptTypeLbl.Name = "apptTypeLbl";
            this.apptTypeLbl.Size = new System.Drawing.Size(57, 25);
            this.apptTypeLbl.TabIndex = 17;
            this.apptTypeLbl.Text = "Type";
            // 
            // apptStartLbl
            // 
            this.apptStartLbl.AutoSize = true;
            this.apptStartLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptStartLbl.Location = new System.Drawing.Point(75, 188);
            this.apptStartLbl.Name = "apptStartLbl";
            this.apptStartLbl.Size = new System.Drawing.Size(102, 25);
            this.apptStartLbl.TabIndex = 19;
            this.apptStartLbl.Text = "Start Time";
            // 
            // apptEndLbl
            // 
            this.apptEndLbl.AutoSize = true;
            this.apptEndLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apptEndLbl.Location = new System.Drawing.Point(82, 230);
            this.apptEndLbl.Name = "apptEndLbl";
            this.apptEndLbl.Size = new System.Drawing.Size(96, 25);
            this.apptEndLbl.TabIndex = 20;
            this.apptEndLbl.Text = "End Time";
            // 
            // cancelApptBtn
            // 
            this.cancelApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelApptBtn.Location = new System.Drawing.Point(211, 303);
            this.cancelApptBtn.Name = "cancelApptBtn";
            this.cancelApptBtn.Size = new System.Drawing.Size(117, 36);
            this.cancelApptBtn.TabIndex = 21;
            this.cancelApptBtn.Text = "Cancel";
            this.cancelApptBtn.UseVisualStyleBackColor = true;
            this.cancelApptBtn.Click += new System.EventHandler(this.cancelApptBtn_Click);
            // 
            // saveApptBtn
            // 
            this.saveApptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveApptBtn.Location = new System.Drawing.Point(333, 303);
            this.saveApptBtn.Name = "saveApptBtn";
            this.saveApptBtn.Size = new System.Drawing.Size(117, 36);
            this.saveApptBtn.TabIndex = 22;
            this.saveApptBtn.Text = "Save";
            this.saveApptBtn.UseVisualStyleBackColor = true;
            this.saveApptBtn.Click += new System.EventHandler(this.saveApptBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(12, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(228, 29);
            this.label11.TabIndex = 23;
            this.label11.Text = "Appointment Details";
            // 
            // custCB
            // 
            this.custCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custCB.FormattingEnabled = true;
            this.custCB.Location = new System.Drawing.Point(193, 110);
            this.custCB.Margin = new System.Windows.Forms.Padding(4);
            this.custCB.Name = "custCB";
            this.custCB.Size = new System.Drawing.Size(259, 28);
            this.custCB.TabIndex = 24;
            // 
            // typeCB
            // 
            this.typeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeCB.FormattingEnabled = true;
            this.typeCB.Location = new System.Drawing.Point(192, 143);
            this.typeCB.Margin = new System.Windows.Forms.Padding(4);
            this.typeCB.Name = "typeCB";
            this.typeCB.Size = new System.Drawing.Size(259, 28);
            this.typeCB.TabIndex = 25;
            // 
            // startTimePicker
            // 
            this.startTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.startTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startTimePicker.Location = new System.Drawing.Point(192, 186);
            this.startTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.startTimePicker.MinDate = new System.DateTime(2018, 12, 1, 0, 0, 0, 0);
            this.startTimePicker.Name = "startTimePicker";
            this.startTimePicker.Size = new System.Drawing.Size(259, 27);
            this.startTimePicker.TabIndex = 26;
            this.startTimePicker.Value = new System.DateTime(2022, 2, 9, 0, 0, 0, 0);
            this.startTimePicker.ValueChanged += new System.EventHandler(this.startTimePicker_ValueChanged);
            // 
            // endTimePicker
            // 
            this.endTimePicker.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            this.endTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endTimePicker.Location = new System.Drawing.Point(192, 225);
            this.endTimePicker.Margin = new System.Windows.Forms.Padding(2);
            this.endTimePicker.MinDate = new System.DateTime(2021, 12, 1, 0, 0, 0, 0);
            this.endTimePicker.Name = "endTimePicker";
            this.endTimePicker.Size = new System.Drawing.Size(259, 27);
            this.endTimePicker.TabIndex = 27;
            this.endTimePicker.Value = new System.DateTime(2022, 2, 9, 0, 0, 0, 0);
            // 
            // errorLbl
            // 
            this.errorLbl.AutoSize = true;
            this.errorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLbl.ForeColor = System.Drawing.Color.Red;
            this.errorLbl.Location = new System.Drawing.Point(21, 278);
            this.errorLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(0, 20);
            this.errorLbl.TabIndex = 28;
            // 
            // AppointmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 452);
            this.Controls.Add(this.errorLbl);
            this.Controls.Add(this.endTimePicker);
            this.Controls.Add(this.startTimePicker);
            this.Controls.Add(this.typeCB);
            this.Controls.Add(this.custCB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.saveApptBtn);
            this.Controls.Add(this.cancelApptBtn);
            this.Controls.Add(this.apptEndLbl);
            this.Controls.Add(this.apptStartLbl);
            this.Controls.Add(this.apptTypeLbl);
            this.Controls.Add(this.apptCustNameLbl);
            this.Controls.Add(this.apptEndTxt);
            this.Name = "AppointmentForm";
            this.Text = "AppointmentDetails";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox apptEndTxt;
        private System.Windows.Forms.Label apptCustNameLbl;
        private System.Windows.Forms.Label apptTypeLbl;
        private System.Windows.Forms.Label apptStartLbl;
        private System.Windows.Forms.Label apptEndLbl;
        private System.Windows.Forms.Button cancelApptBtn;
        private System.Windows.Forms.Button saveApptBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label errorLbl;
        public System.Windows.Forms.ComboBox custCB;
        public System.Windows.Forms.ComboBox typeCB;
        public System.Windows.Forms.DateTimePicker startTimePicker;
        public System.Windows.Forms.DateTimePicker endTimePicker;
    }
}
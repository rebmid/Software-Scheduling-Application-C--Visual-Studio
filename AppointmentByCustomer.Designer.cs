namespace C969Rebekah
{
    partial class AppointmentByCustomer
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
            this.apptByCustDgv = new System.Windows.Forms.DataGridView();
            this.custReportLbl = new System.Windows.Forms.Label();
            this.custCB = new System.Windows.Forms.ComboBox();
            this.custLbl = new System.Windows.Forms.Label();
            this.generateReportBtn = new System.Windows.Forms.Button();
            this.returnMainBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.apptByCustDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // apptByCustDgv
            // 
            this.apptByCustDgv.AllowUserToAddRows = false;
            this.apptByCustDgv.AllowUserToDeleteRows = false;
            this.apptByCustDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.apptByCustDgv.Location = new System.Drawing.Point(24, 110);
            this.apptByCustDgv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.apptByCustDgv.Name = "apptByCustDgv";
            this.apptByCustDgv.ReadOnly = true;
            this.apptByCustDgv.RowHeadersVisible = false;
            this.apptByCustDgv.RowHeadersWidth = 82;
            this.apptByCustDgv.RowTemplate.Height = 33;
            this.apptByCustDgv.Size = new System.Drawing.Size(543, 218);
            this.apptByCustDgv.TabIndex = 0;
            // 
            // custReportLbl
            // 
            this.custReportLbl.AutoSize = true;
            this.custReportLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custReportLbl.Location = new System.Drawing.Point(19, 33);
            this.custReportLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.custReportLbl.Name = "custReportLbl";
            this.custReportLbl.Size = new System.Drawing.Size(313, 25);
            this.custReportLbl.TabIndex = 1;
            this.custReportLbl.Text = "All Appointments Per Customer";
            // 
            // custCB
            // 
            this.custCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custCB.FormattingEnabled = true;
            this.custCB.Location = new System.Drawing.Point(349, 68);
            this.custCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.custCB.Name = "custCB";
            this.custCB.Size = new System.Drawing.Size(219, 33);
            this.custCB.TabIndex = 2;
            // 
            // custLbl
            // 
            this.custLbl.AutoSize = true;
            this.custLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custLbl.Location = new System.Drawing.Point(227, 68);
            this.custLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.custLbl.Name = "custLbl";
            this.custLbl.Size = new System.Drawing.Size(97, 25);
            this.custLbl.TabIndex = 3;
            this.custLbl.Text = "Customer";
            // 
            // generateReportBtn
            // 
            this.generateReportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateReportBtn.Location = new System.Drawing.Point(24, 332);
            this.generateReportBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.generateReportBtn.Name = "generateReportBtn";
            this.generateReportBtn.Size = new System.Drawing.Size(232, 47);
            this.generateReportBtn.TabIndex = 12;
            this.generateReportBtn.Text = "Generate Report";
            this.generateReportBtn.UseVisualStyleBackColor = true;
            this.generateReportBtn.Click += new System.EventHandler(this.generateReportBtn_Click);
            // 
            // returnMainBtn
            // 
            this.returnMainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnMainBtn.Location = new System.Drawing.Point(335, 332);
            this.returnMainBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.returnMainBtn.Name = "returnMainBtn";
            this.returnMainBtn.Size = new System.Drawing.Size(232, 47);
            this.returnMainBtn.TabIndex = 13;
            this.returnMainBtn.Text = "Return to Main Screen";
            this.returnMainBtn.UseVisualStyleBackColor = true;
            this.returnMainBtn.Click += new System.EventHandler(this.returnMainBtn_Click);
            // 
            // AppointmentByCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 486);
            this.Controls.Add(this.returnMainBtn);
            this.Controls.Add(this.generateReportBtn);
            this.Controls.Add(this.custLbl);
            this.Controls.Add(this.custCB);
            this.Controls.Add(this.custReportLbl);
            this.Controls.Add(this.apptByCustDgv);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AppointmentByCustomer";
            this.Text = "Appointments By Customer Report";
            this.Load += new System.EventHandler(this.ApptByCust_Load);
            ((System.ComponentModel.ISupportInitialize)(this.apptByCustDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView apptByCustDgv;
        private System.Windows.Forms.Label custReportLbl;
        private System.Windows.Forms.ComboBox custCB;
        private System.Windows.Forms.Label custLbl;
        private System.Windows.Forms.Button generateReportBtn;
        private System.Windows.Forms.Button returnMainBtn;
    }
}
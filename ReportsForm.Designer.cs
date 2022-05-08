namespace C969Rebekah
{
    partial class ReportsForm
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
            this.userDgv = new System.Windows.Forms.DataGridView();
            this.userSchedLbl = new System.Windows.Forms.Label();
            this.userCB = new System.Windows.Forms.ComboBox();
            this.userLbl = new System.Windows.Forms.Label();
            this.returnMainBtn = new System.Windows.Forms.Button();
            this.generateReportBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).BeginInit();
            this.SuspendLayout();
            // 
            // userDgv
            // 
            this.userDgv.AllowUserToAddRows = false;
            this.userDgv.AllowUserToDeleteRows = false;
            this.userDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userDgv.Location = new System.Drawing.Point(24, 110);
            this.userDgv.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userDgv.Name = "userDgv";
            this.userDgv.ReadOnly = true;
            this.userDgv.RowHeadersVisible = false;
            this.userDgv.RowHeadersWidth = 82;
            this.userDgv.RowTemplate.Height = 33;
            this.userDgv.Size = new System.Drawing.Size(678, 277);
            this.userDgv.TabIndex = 0;
            // 
            // userSchedLbl
            // 
            this.userSchedLbl.AutoSize = true;
            this.userSchedLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userSchedLbl.Location = new System.Drawing.Point(30, 56);
            this.userSchedLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userSchedLbl.Name = "userSchedLbl";
            this.userSchedLbl.Size = new System.Drawing.Size(154, 25);
            this.userSchedLbl.TabIndex = 1;
            this.userSchedLbl.Text = "User Schedule";
            this.userSchedLbl.Click += new System.EventHandler(this.userSchedLbl_Click);
            // 
            // userCB
            // 
            this.userCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userCB.FormattingEnabled = true;
            this.userCB.Location = new System.Drawing.Point(241, 78);
            this.userCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.userCB.Name = "userCB";
            this.userCB.Size = new System.Drawing.Size(182, 28);
            this.userCB.TabIndex = 2;
            // 
            // userLbl
            // 
            this.userLbl.AutoSize = true;
            this.userLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLbl.Location = new System.Drawing.Point(227, 51);
            this.userLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.userLbl.Name = "userLbl";
            this.userLbl.Size = new System.Drawing.Size(210, 25);
            this.userLbl.TabIndex = 3;
            this.userLbl.Text = "User Drop Down Menu";
            this.userLbl.Click += new System.EventHandler(this.userLbl_Click);
            // 
            // returnMainBtn
            // 
            this.returnMainBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.returnMainBtn.Location = new System.Drawing.Point(546, 391);
            this.returnMainBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.returnMainBtn.Name = "returnMainBtn";
            this.returnMainBtn.Size = new System.Drawing.Size(148, 47);
            this.returnMainBtn.TabIndex = 15;
            this.returnMainBtn.Text = "Exit Screen";
            this.returnMainBtn.UseVisualStyleBackColor = true;
            this.returnMainBtn.Click += new System.EventHandler(this.returnMainBtn_Click);
            // 
            // generateReportBtn
            // 
            this.generateReportBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateReportBtn.Location = new System.Drawing.Point(525, 61);
            this.generateReportBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.generateReportBtn.Name = "generateReportBtn";
            this.generateReportBtn.Size = new System.Drawing.Size(169, 47);
            this.generateReportBtn.TabIndex = 14;
            this.generateReportBtn.Text = "Create Report";
            this.generateReportBtn.UseVisualStyleBackColor = true;
            this.generateReportBtn.Click += new System.EventHandler(this.generateReportBtn_Click);
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 508);
            this.Controls.Add(this.returnMainBtn);
            this.Controls.Add(this.generateReportBtn);
            this.Controls.Add(this.userLbl);
            this.Controls.Add(this.userCB);
            this.Controls.Add(this.userSchedLbl);
            this.Controls.Add(this.userDgv);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ReportsForm";
            this.Text = "Appointments By Month Report";
            this.Load += new System.EventHandler(this.UserSchedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userDgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView userDgv;
        private System.Windows.Forms.Label userSchedLbl;
        private System.Windows.Forms.ComboBox userCB;
        private System.Windows.Forms.Label userLbl;
        private System.Windows.Forms.Button returnMainBtn;
        private System.Windows.Forms.Button generateReportBtn;
    }
}
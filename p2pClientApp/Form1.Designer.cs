namespace p2pClientApp
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
            this.btnGetPublicAddress = new System.Windows.Forms.Button();
            this.txtPublicAddress = new System.Windows.Forms.TextBox();
            this.txtPublicPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGetPublicAddress
            // 
            this.btnGetPublicAddress.Location = new System.Drawing.Point(537, 45);
            this.btnGetPublicAddress.Name = "btnGetPublicAddress";
            this.btnGetPublicAddress.Size = new System.Drawing.Size(218, 84);
            this.btnGetPublicAddress.TabIndex = 0;
            this.btnGetPublicAddress.Text = "Get My Public Address";
            this.btnGetPublicAddress.UseVisualStyleBackColor = true;
            this.btnGetPublicAddress.Click += new System.EventHandler(this.btnGetPublicAddress_Click);
            // 
            // txtPublicAddress
            // 
            this.txtPublicAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPublicAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublicAddress.Location = new System.Drawing.Point(52, 67);
            this.txtPublicAddress.Name = "txtPublicAddress";
            this.txtPublicAddress.ReadOnly = true;
            this.txtPublicAddress.Size = new System.Drawing.Size(306, 38);
            this.txtPublicAddress.TabIndex = 1;
            this.txtPublicAddress.Text = "...";
            this.txtPublicAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPublicPort
            // 
            this.txtPublicPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPublicPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublicPort.Location = new System.Drawing.Point(377, 67);
            this.txtPublicPort.Name = "txtPublicPort";
            this.txtPublicPort.ReadOnly = true;
            this.txtPublicPort.Size = new System.Drawing.Size(126, 38);
            this.txtPublicPort.TabIndex = 2;
            this.txtPublicPort.Text = "...";
            this.txtPublicPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPublicPort);
            this.Controls.Add(this.txtPublicAddress);
            this.Controls.Add(this.btnGetPublicAddress);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetPublicAddress;
        private System.Windows.Forms.TextBox txtPublicAddress;
        private System.Windows.Forms.TextBox txtPublicPort;
    }
}


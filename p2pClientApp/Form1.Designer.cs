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
            btnGetPublicAddress = new System.Windows.Forms.Button();
            txtPublicEndPoint = new System.Windows.Forms.TextBox();
            txtPublicPort = new System.Windows.Forms.TextBox();
            txtLocalEndPoint = new System.Windows.Forms.TextBox();
            txtOtherEndPoint = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // btnGetPublicAddress
            // 
            btnGetPublicAddress.Location = new System.Drawing.Point(313, 27);
            btnGetPublicAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            btnGetPublicAddress.Name = "btnGetPublicAddress";
            btnGetPublicAddress.Size = new System.Drawing.Size(127, 50);
            btnGetPublicAddress.TabIndex = 0;
            btnGetPublicAddress.Text = "Get My Public Address";
            btnGetPublicAddress.UseVisualStyleBackColor = true;
            btnGetPublicAddress.Click += btnGetPublicAddress_Click;
            // 
            // txtPublicEndPoint
            // 
            txtPublicEndPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPublicEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtPublicEndPoint.Location = new System.Drawing.Point(30, 40);
            txtPublicEndPoint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            txtPublicEndPoint.Name = "txtPublicEndPoint";
            txtPublicEndPoint.ReadOnly = true;
            txtPublicEndPoint.Size = new System.Drawing.Size(179, 23);
            txtPublicEndPoint.TabIndex = 1;
            txtPublicEndPoint.Text = "...";
            txtPublicEndPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPublicPort
            // 
            txtPublicPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPublicPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtPublicPort.Location = new System.Drawing.Point(220, 40);
            txtPublicPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            txtPublicPort.Name = "txtPublicPort";
            txtPublicPort.ReadOnly = true;
            txtPublicPort.Size = new System.Drawing.Size(74, 23);
            txtPublicPort.TabIndex = 2;
            txtPublicPort.Text = "...";
            txtPublicPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLocalEndPoint
            // 
            txtLocalEndPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLocalEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtLocalEndPoint.Location = new System.Drawing.Point(30, 76);
            txtLocalEndPoint.Margin = new System.Windows.Forms.Padding(2);
            txtLocalEndPoint.Name = "txtLocalEndPoint";
            txtLocalEndPoint.ReadOnly = true;
            txtLocalEndPoint.Size = new System.Drawing.Size(179, 23);
            txtLocalEndPoint.TabIndex = 3;
            txtLocalEndPoint.Text = "...";
            txtLocalEndPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOtherEndPoint
            // 
            txtOtherEndPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtOtherEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtOtherEndPoint.Location = new System.Drawing.Point(30, 115);
            txtOtherEndPoint.Margin = new System.Windows.Forms.Padding(2);
            txtOtherEndPoint.Name = "txtOtherEndPoint";
            txtOtherEndPoint.ReadOnly = true;
            txtOtherEndPoint.Size = new System.Drawing.Size(179, 23);
            txtOtherEndPoint.TabIndex = 4;
            txtOtherEndPoint.Text = "...";
            txtOtherEndPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(467, 270);
            Controls.Add(txtOtherEndPoint);
            Controls.Add(txtLocalEndPoint);
            Controls.Add(txtPublicPort);
            Controls.Add(txtPublicEndPoint);
            Controls.Add(btnGetPublicAddress);
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnGetPublicAddress;
        private System.Windows.Forms.TextBox txtPublicEndPoint;
        private System.Windows.Forms.TextBox txtPublicPort;
        private System.Windows.Forms.TextBox txtLocalEndPoint;
        private System.Windows.Forms.TextBox txtOtherEndPoint;
    }
}


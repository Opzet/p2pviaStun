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
            button1 = new System.Windows.Forms.Button();
            txtSTUNServerList = new System.Windows.Forms.TextBox();
            btnGetStunServerList = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnGetPublicAddress
            // 
            btnGetPublicAddress.Location = new System.Drawing.Point(580, 28);
            btnGetPublicAddress.Margin = new System.Windows.Forms.Padding(4);
            btnGetPublicAddress.Name = "btnGetPublicAddress";
            btnGetPublicAddress.Size = new System.Drawing.Size(236, 136);
            btnGetPublicAddress.TabIndex = 0;
            btnGetPublicAddress.Text = "Get My Public Address\r\nStunClient5389UDP";
            btnGetPublicAddress.UseVisualStyleBackColor = true;
            btnGetPublicAddress.Click += btnGetPublicAddress_Click;
            // 
            // txtPublicEndPoint
            // 
            txtPublicEndPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPublicEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtPublicEndPoint.Location = new System.Drawing.Point(13, 28);
            txtPublicEndPoint.Margin = new System.Windows.Forms.Padding(4);
            txtPublicEndPoint.Name = "txtPublicEndPoint";
            txtPublicEndPoint.ReadOnly = true;
            txtPublicEndPoint.Size = new System.Drawing.Size(519, 38);
            txtPublicEndPoint.TabIndex = 1;
            txtPublicEndPoint.Text = "...";
            txtPublicEndPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPublicPort
            // 
            txtPublicPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtPublicPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtPublicPort.Location = new System.Drawing.Point(396, 265);
            txtPublicPort.Margin = new System.Windows.Forms.Padding(4);
            txtPublicPort.Name = "txtPublicPort";
            txtPublicPort.ReadOnly = true;
            txtPublicPort.Size = new System.Drawing.Size(136, 38);
            txtPublicPort.TabIndex = 2;
            txtPublicPort.Text = "...";
            txtPublicPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLocalEndPoint
            // 
            txtLocalEndPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtLocalEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtLocalEndPoint.Location = new System.Drawing.Point(13, 105);
            txtLocalEndPoint.Margin = new System.Windows.Forms.Padding(4);
            txtLocalEndPoint.Name = "txtLocalEndPoint";
            txtLocalEndPoint.ReadOnly = true;
            txtLocalEndPoint.Size = new System.Drawing.Size(519, 38);
            txtLocalEndPoint.TabIndex = 3;
            txtLocalEndPoint.Text = "...";
            txtLocalEndPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOtherEndPoint
            // 
            txtOtherEndPoint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtOtherEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtOtherEndPoint.Location = new System.Drawing.Point(13, 188);
            txtOtherEndPoint.Margin = new System.Windows.Forms.Padding(4);
            txtOtherEndPoint.Name = "txtOtherEndPoint";
            txtOtherEndPoint.ReadOnly = true;
            txtOtherEndPoint.Size = new System.Drawing.Size(519, 38);
            txtOtherEndPoint.TabIndex = 4;
            txtOtherEndPoint.Text = "...";
            txtOtherEndPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(580, 215);
            button1.Margin = new System.Windows.Forms.Padding(4);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(236, 136);
            button1.TabIndex = 5;
            button1.Text = "Get My Public Address\r\nStunClient5389TCP";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtSTUNServerList
            // 
            txtSTUNServerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            txtSTUNServerList.Location = new System.Drawing.Point(37, 337);
            txtSTUNServerList.Multiline = true;
            txtSTUNServerList.Name = "txtSTUNServerList";
            txtSTUNServerList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            txtSTUNServerList.Size = new System.Drawing.Size(496, 211);
            txtSTUNServerList.TabIndex = 6;
            txtSTUNServerList.Text = "<Ready>";
            // 
            // btnGetStunServerList
            // 
            btnGetStunServerList.Location = new System.Drawing.Point(580, 412);
            btnGetStunServerList.Name = "btnGetStunServerList";
            btnGetStunServerList.Size = new System.Drawing.Size(236, 87);
            btnGetStunServerList.TabIndex = 7;
            btnGetStunServerList.Text = "Get Stun Servers";
            btnGetStunServerList.UseVisualStyleBackColor = true;
            btnGetStunServerList.Click += btnGetStunServerList_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(867, 576);
            Controls.Add(btnGetStunServerList);
            Controls.Add(txtSTUNServerList);
            Controls.Add(button1);
            Controls.Add(txtOtherEndPoint);
            Controls.Add(txtLocalEndPoint);
            Controls.Add(txtPublicPort);
            Controls.Add(txtPublicEndPoint);
            Controls.Add(btnGetPublicAddress);
            Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSTUNServerList;
        private System.Windows.Forms.Button btnGetStunServerList;
    }
}


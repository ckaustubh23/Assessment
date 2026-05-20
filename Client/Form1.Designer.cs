namespace Client
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtIP = new TextBox();
            txtPort = new TextBox();
            label1 = new Label();
            btnConnect = new Button();
            txtMessage = new TextBox();
            btnSend = new Button();
            txtLogs = new RichTextBox();
            SuspendLayout();
            // 
            // txtIP
            // 
            txtIP.Location = new Point(24, 28);
            txtIP.Name = "txtIP";
            txtIP.ReadOnly = true;
            txtIP.Size = new Size(90, 23);
            txtIP.TabIndex = 0;
            txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(131, 28);
            txtPort.Name = "txtPort";
            txtPort.ReadOnly = true;
            txtPort.Size = new Size(63, 23);
            txtPort.TabIndex = 1;
            txtPort.Text = "5000";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(117, 32);
            label1.Name = "label1";
            label1.Size = new Size(10, 15);
            label1.TabIndex = 2;
            label1.Text = ":";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(213, 28);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 3;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(24, 84);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(306, 23);
            txtMessage.TabIndex = 4;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(349, 83);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 5;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtLogs
            // 
            txtLogs.Location = new Point(0, 139);
            txtLogs.Name = "txtLogs";
            txtLogs.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLogs.Size = new Size(463, 299);
            txtLogs.TabIndex = 6;
            txtLogs.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(463, 450);
            Controls.Add(txtLogs);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(btnConnect);
            Controls.Add(label1);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIP;
        private TextBox txtPort;
        private Label label1;
        private Button btnConnect;
        private TextBox txtMessage;
        private Button btnSend;
        private RichTextBox txtLogs;
    }
}

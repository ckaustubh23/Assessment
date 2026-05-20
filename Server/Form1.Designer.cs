namespace Server
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
            btn_Start = new Button();
            txtLogs = new RichTextBox();
            SuspendLayout();
            // 
            // btn_Start
            // 
            btn_Start.Location = new Point(34, 32);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new Size(84, 27);
            btn_Start.TabIndex = 0;
            btn_Start.Text = "Start Server";
            btn_Start.UseVisualStyleBackColor = true;
            btn_Start.Click += btn_Start_Click;
            // 
            // txtLogs
            // 
            txtLogs.Location = new Point(0, 75);
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtLogs.Size = new Size(448, 288);
            txtLogs.TabIndex = 1;
            txtLogs.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 365);
            Controls.Add(txtLogs);
            Controls.Add(btn_Start);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_Start;
        private RichTextBox txtLogs;
    }
}

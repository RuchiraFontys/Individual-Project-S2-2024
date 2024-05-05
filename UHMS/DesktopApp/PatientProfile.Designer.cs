namespace DesktopApp
{
    partial class PatientProfile
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
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(-2, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(808, 459);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.AppWorkspace;
            panel2.Controls.Add(button1);
            panel2.Location = new Point(49, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(256, 223);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.AppWorkspace;
            panel3.Controls.Add(button2);
            panel3.Location = new Point(427, 97);
            panel3.Name = "panel3";
            panel3.Size = new Size(256, 223);
            panel3.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 25F);
            button1.Location = new Point(3, 3);
            button1.Name = "button1";
            button1.Size = new Size(250, 217);
            button1.TabIndex = 0;
            button1.Text = "PRESCRIBE";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 25F);
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(250, 217);
            button2.TabIndex = 0;
            button2.Text = "VIEW MEDICAL HISTORY";
            button2.UseVisualStyleBackColor = true;
            // 
            // PatientProfile
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(738, 418);
            Controls.Add(panel1);
            Name = "PatientProfile";
            Text = "PatientProfile";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Button button2;
        private Panel panel2;
        private Button button1;
    }
}
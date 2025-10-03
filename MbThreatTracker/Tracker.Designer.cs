namespace MbThreatTracker
{
    partial class Tracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tracker));
            PanelThreats = new Panel();
            SuspendLayout();
            // 
            // PanelThreats
            // 
            PanelThreats.BackColor = SystemColors.Control;
            PanelThreats.Dock = DockStyle.Fill;
            PanelThreats.Location = new Point(0, 0);
            PanelThreats.Name = "PanelThreats";
            PanelThreats.Size = new Size(556, 517);
            PanelThreats.TabIndex = 1;
            // 
            // Tracker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(556, 517);
            Controls.Add(PanelThreats);
            DoubleBuffered = true;
            Name = "Tracker";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Malwarebytes Threat Tracker";
            FormClosing += Tracker_FormClosing;
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelThreats;
    }
}

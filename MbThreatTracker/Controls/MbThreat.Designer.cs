namespace MbThreatTracker.Controls
{
    partial class MbThreat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            LabelType = new Label();
            LabelName = new Label();
            LabelPath = new Label();
            LabelThreatName = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.found_m;
            pictureBox1.Location = new Point(12, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // LabelType
            // 
            LabelType.AutoSize = true;
            LabelType.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelType.Location = new Point(74, 23);
            LabelType.Name = "LabelType";
            LabelType.Size = new Size(157, 18);
            LabelType.TabIndex = 1;
            LabelType.Text = "Malware Blocked";
            // 
            // LabelName
            // 
            LabelName.AutoSize = true;
            LabelName.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelName.Location = new Point(74, 54);
            LabelName.Name = "LabelName";
            LabelName.Size = new Size(49, 16);
            LabelName.TabIndex = 2;
            LabelName.Text = "Name:";
            // 
            // LabelPath
            // 
            LabelPath.AutoSize = true;
            LabelPath.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelPath.Location = new Point(74, 79);
            LabelPath.Name = "LabelPath";
            LabelPath.Size = new Size(43, 16);
            LabelPath.TabIndex = 3;
            LabelPath.Text = "Path:";
            // 
            // LabelThreatName
            // 
            LabelThreatName.AutoSize = true;
            LabelThreatName.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelThreatName.Location = new Point(129, 54);
            LabelThreatName.Name = "LabelThreatName";
            LabelThreatName.Size = new Size(0, 16);
            LabelThreatName.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(129, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 6;
            // 
            // MbThreat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(textBox1);
            Controls.Add(LabelThreatName);
            Controls.Add(LabelPath);
            Controls.Add(LabelName);
            Controls.Add(LabelType);
            Controls.Add(pictureBox1);
            Name = "MbThreat";
            Size = new Size(423, 148);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label LabelType;
        private Label LabelName;
        private Label LabelPath;
        private Label LabelThreatName;
        private TextBox textBox1;
    }
}

namespace MRK
{
    partial class InputStringForm
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
            label1 = new Label();
            tbPath = new TextBox();
            bGenerate = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.Font = new Font("Segoe UI Semibold", 12F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(472, 79);
            label1.TabIndex = 0;
            label1.Text = "ModelSim Instruction Memory Array Path\r\n(ex: /processor/instructionMemory/memory_arr)";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbPath
            // 
            tbPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbPath.Location = new Point(12, 229);
            tbPath.Name = "tbPath";
            tbPath.Size = new Size(472, 23);
            tbPath.TabIndex = 1;
            tbPath.Text = "/processor/instructionMemory/memory_arr";
            tbPath.TextAlign = HorizontalAlignment.Center;
            // 
            // bGenerate
            // 
            bGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bGenerate.Location = new Point(374, 266);
            bGenerate.Name = "bGenerate";
            bGenerate.Size = new Size(110, 32);
            bGenerate.TabIndex = 2;
            bGenerate.Text = "Generate";
            bGenerate.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.Screenshot_2024_04_20_183632;
            pictureBox1.Location = new Point(12, 89);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(472, 120);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // InputStringForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 310);
            Controls.Add(pictureBox1);
            Controls.Add(bGenerate);
            Controls.Add(tbPath);
            Controls.Add(label1);
            Name = "InputStringForm";
            Text = "ModelSim Instruction Memory";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbPath;
        private Button bGenerate;
        private PictureBox pictureBox1;
    }
}
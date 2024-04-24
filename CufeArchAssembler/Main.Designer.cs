namespace MRK
{
    partial class Main
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
            gbSynthesize = new GroupBox();
            cbHex = new CheckBox();
            cbUnsigned = new CheckBox();
            lSynthOutput = new Label();
            tbImm = new TextBox();
            cbRes = new ComboBox();
            label5 = new Label();
            cbDst = new ComboBox();
            label4 = new Label();
            cbSrc2 = new ComboBox();
            label3 = new Label();
            cbSrc1 = new ComboBox();
            label2 = new Label();
            label6 = new Label();
            cbOpcode = new ComboBox();
            label1 = new Label();
            tbConsole = new TextBox();
            tbCode = new TextBox();
            tbOutput = new TextBox();
            bAssemble = new Button();
            bGenerate = new Button();
            lStatus = new Label();
            cbStrict = new CheckBox();
            gbSynthesize.SuspendLayout();
            SuspendLayout();
            // 
            // gbSynthesize
            // 
            gbSynthesize.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbSynthesize.Controls.Add(cbHex);
            gbSynthesize.Controls.Add(cbUnsigned);
            gbSynthesize.Controls.Add(lSynthOutput);
            gbSynthesize.Controls.Add(tbImm);
            gbSynthesize.Controls.Add(cbRes);
            gbSynthesize.Controls.Add(label5);
            gbSynthesize.Controls.Add(cbDst);
            gbSynthesize.Controls.Add(label4);
            gbSynthesize.Controls.Add(cbSrc2);
            gbSynthesize.Controls.Add(label3);
            gbSynthesize.Controls.Add(cbSrc1);
            gbSynthesize.Controls.Add(label2);
            gbSynthesize.Controls.Add(label6);
            gbSynthesize.Controls.Add(cbOpcode);
            gbSynthesize.Controls.Add(label1);
            gbSynthesize.Location = new Point(12, 12);
            gbSynthesize.Name = "gbSynthesize";
            gbSynthesize.Size = new Size(898, 111);
            gbSynthesize.TabIndex = 0;
            gbSynthesize.TabStop = false;
            gbSynthesize.Text = "Synthesize";
            // 
            // cbHex
            // 
            cbHex.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbHex.Font = new Font("Segoe UI Semibold", 9F);
            cbHex.Location = new Point(755, 79);
            cbHex.Name = "cbHex";
            cbHex.Size = new Size(51, 19);
            cbHex.TabIndex = 4;
            cbHex.Text = "Hex";
            cbHex.UseVisualStyleBackColor = true;
            // 
            // cbUnsigned
            // 
            cbUnsigned.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cbUnsigned.Font = new Font("Segoe UI Semibold", 9F);
            cbUnsigned.Location = new Point(812, 79);
            cbUnsigned.Name = "cbUnsigned";
            cbUnsigned.Size = new Size(80, 19);
            cbUnsigned.TabIndex = 4;
            cbUnsigned.Text = "Unsigned";
            cbUnsigned.UseVisualStyleBackColor = true;
            // 
            // lSynthOutput
            // 
            lSynthOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lSynthOutput.AutoSize = true;
            lSynthOutput.Cursor = Cursors.Hand;
            lSynthOutput.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lSynthOutput.Location = new Point(10, 84);
            lSynthOutput.Name = "lSynthOutput";
            lSynthOutput.Size = new Size(57, 19);
            lSynthOutput.TabIndex = 3;
            lSynthOutput.Text = "0x0000";
            // 
            // tbImm
            // 
            tbImm.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbImm.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            tbImm.Location = new Point(637, 50);
            tbImm.Name = "tbImm";
            tbImm.Size = new Size(255, 23);
            tbImm.TabIndex = 2;
            // 
            // cbRes
            // 
            cbRes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRes.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cbRes.FormattingEnabled = true;
            cbRes.Items.AddRange(new object[] { "0", "1", "2", "3" });
            cbRes.Location = new Point(524, 50);
            cbRes.Name = "cbRes";
            cbRes.Size = new Size(107, 23);
            cbRes.TabIndex = 1;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI Semibold", 9F);
            label5.Location = new Point(524, 32);
            label5.Name = "label5";
            label5.Size = new Size(107, 15);
            label5.TabIndex = 0;
            label5.Text = "RESERVED (size)";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbDst
            // 
            cbDst.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDst.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cbDst.FormattingEnabled = true;
            cbDst.Items.AddRange(new object[] { "R0", "R1", "R2", "R3", "R4", "R5", "R6", "R7" });
            cbDst.Location = new Point(411, 50);
            cbDst.Name = "cbDst";
            cbDst.Size = new Size(107, 23);
            cbDst.TabIndex = 1;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI Semibold", 9F);
            label4.Location = new Point(411, 32);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 0;
            label4.Text = "DST";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbSrc2
            // 
            cbSrc2.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSrc2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cbSrc2.FormattingEnabled = true;
            cbSrc2.Items.AddRange(new object[] { "R0", "R1", "R2", "R3", "R4", "R5", "R6", "R7" });
            cbSrc2.Location = new Point(298, 50);
            cbSrc2.Name = "cbSrc2";
            cbSrc2.Size = new Size(107, 23);
            cbSrc2.TabIndex = 1;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Semibold", 9F);
            label3.Location = new Point(298, 32);
            label3.Name = "label3";
            label3.Size = new Size(107, 15);
            label3.TabIndex = 0;
            label3.Text = "SRC 2";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbSrc1
            // 
            cbSrc1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSrc1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cbSrc1.FormattingEnabled = true;
            cbSrc1.Items.AddRange(new object[] { "R0", "R1", "R2", "R3", "R4", "R5", "R6", "R7" });
            cbSrc1.Location = new Point(185, 50);
            cbSrc1.Name = "cbSrc1";
            cbSrc1.Size = new Size(107, 23);
            cbSrc1.TabIndex = 1;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 9F);
            label2.Location = new Point(185, 32);
            label2.Name = "label2";
            label2.Size = new Size(107, 15);
            label2.TabIndex = 0;
            label2.Text = "SRC 1";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.Font = new Font("Segoe UI Semibold", 9F);
            label6.Location = new Point(637, 32);
            label6.Name = "label6";
            label6.Size = new Size(255, 15);
            label6.TabIndex = 0;
            label6.Text = "IMMEDIATE";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbOpcode
            // 
            cbOpcode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOpcode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cbOpcode.FormattingEnabled = true;
            cbOpcode.Items.AddRange(new object[] { "0x00 - NOP", "0x01 - NOT", "0x02 - NEG", "0x03 - INC", "0x04 - DEC", "0x05 - OUT", "0x06 - IN", "0x07 - MOV", "0x08 - SWAP", "0x09 - ADD", "0x0A - ADDI", "0x0B - SUB", "0x0C - SUBI", "0x0D - AND", "0x0E - OR", "0x0F - XOR", "0x10 - CMP", "0x11 - PUSH", "0x12 - POP", "0x13 - LDM", "0x14 - LDD", "0x15 - STD", "0x16 - PROTECT", "0x17 - FREE", "0x18 - JZ", "0x19 - JMP", "0x1A - CALL", "0x1B - RET", "0x1C - RTI", "0x1D - RESET", "0x1E - INTERRUPT" });
            cbOpcode.Location = new Point(6, 50);
            cbOpcode.Name = "cbOpcode";
            cbOpcode.Size = new Size(173, 23);
            cbOpcode.TabIndex = 1;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 9F);
            label1.Location = new Point(6, 32);
            label1.Name = "label1";
            label1.Size = new Size(173, 15);
            label1.TabIndex = 0;
            label1.Text = "OPCODE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbConsole
            // 
            tbConsole.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbConsole.Font = new Font("Segoe UI", 8F);
            tbConsole.Location = new Point(12, 666);
            tbConsole.Multiline = true;
            tbConsole.Name = "tbConsole";
            tbConsole.ReadOnly = true;
            tbConsole.ScrollBars = ScrollBars.Vertical;
            tbConsole.Size = new Size(898, 132);
            tbConsole.TabIndex = 1;
            // 
            // tbCode
            // 
            tbCode.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tbCode.BackColor = Color.FromArgb(26, 26, 26);
            tbCode.Font = new Font("Consolas", 10F);
            tbCode.ForeColor = Color.White;
            tbCode.Location = new Point(12, 129);
            tbCode.Multiline = true;
            tbCode.Name = "tbCode";
            tbCode.ScrollBars = ScrollBars.Vertical;
            tbCode.Size = new Size(475, 533);
            tbCode.TabIndex = 2;
            // 
            // tbOutput
            // 
            tbOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbOutput.BackColor = Color.Black;
            tbOutput.Font = new Font("Consolas", 9F, FontStyle.Bold);
            tbOutput.ForeColor = Color.White;
            tbOutput.Location = new Point(493, 129);
            tbOutput.Multiline = true;
            tbOutput.Name = "tbOutput";
            tbOutput.ReadOnly = true;
            tbOutput.ScrollBars = ScrollBars.Vertical;
            tbOutput.Size = new Size(417, 498);
            tbOutput.TabIndex = 1;
            // 
            // bAssemble
            // 
            bAssemble.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bAssemble.Location = new Point(560, 632);
            bAssemble.Name = "bAssemble";
            bAssemble.Size = new Size(120, 29);
            bAssemble.TabIndex = 3;
            bAssemble.Text = "Assemble";
            bAssemble.UseVisualStyleBackColor = true;
            // 
            // bGenerate
            // 
            bGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bGenerate.Location = new Point(686, 632);
            bGenerate.Name = "bGenerate";
            bGenerate.Size = new Size(218, 29);
            bGenerate.TabIndex = 3;
            bGenerate.Text = "Generate ModelSim Command";
            bGenerate.UseVisualStyleBackColor = true;
            // 
            // lStatus
            // 
            lStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lStatus.BackColor = Color.Purple;
            lStatus.Font = new Font("Segoe UI Semibold", 8F);
            lStatus.ForeColor = Color.White;
            lStatus.Location = new Point(-1, 798);
            lStatus.Name = "lStatus";
            lStatus.Size = new Size(923, 29);
            lStatus.TabIndex = 4;
            lStatus.Text = "Idle";
            lStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cbStrict
            // 
            cbStrict.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cbStrict.Font = new Font("Segoe UI Semibold", 9F);
            cbStrict.Location = new Point(493, 633);
            cbStrict.Name = "cbStrict";
            cbStrict.Size = new Size(61, 28);
            cbStrict.TabIndex = 4;
            cbStrict.Text = "Strict";
            cbStrict.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(922, 825);
            Controls.Add(cbStrict);
            Controls.Add(bGenerate);
            Controls.Add(bAssemble);
            Controls.Add(tbCode);
            Controls.Add(tbOutput);
            Controls.Add(tbConsole);
            Controls.Add(lStatus);
            Controls.Add(gbSynthesize);
            Name = "Main";
            Text = "Assembler";
            gbSynthesize.ResumeLayout(false);
            gbSynthesize.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbSynthesize;
        private ComboBox cbOpcode;
        private Label label1;
        private ComboBox cbDst;
        private Label label4;
        private ComboBox cbSrc2;
        private Label label3;
        private ComboBox cbSrc1;
        private Label label2;
        private ComboBox cbRes;
        private Label label5;
        private TextBox tbImm;
        private Label label6;
        private Label lSynthOutput;
        private CheckBox cbUnsigned;
        private TextBox tbConsole;
        private TextBox tbCode;
        private TextBox tbOutput;
        private Button bAssemble;
        private Button bGenerate;
        private Label lStatus;
        private CheckBox cbStrict;
        private CheckBox cbHex;
    }
}

namespace KZ_CA_GrainGrowth
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.numericUpDownX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownY = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBoxNeighborhood = new System.Windows.Forms.ComboBox();
            this.comboBoxBoundaryCondition = new System.Windows.Forms.ComboBox();
            this.comboBoxGrainGrowthType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownAmountX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownAmountY = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSeed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountY)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(17, 16);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(100, 28);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // numericUpDownX
            // 
            this.numericUpDownX.Location = new System.Drawing.Point(125, 16);
            this.numericUpDownX.Name = "numericUpDownX";
            this.numericUpDownX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownX.TabIndex = 1;
            this.numericUpDownX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // numericUpDownY
            // 
            this.numericUpDownY.Location = new System.Drawing.Point(125, 45);
            this.numericUpDownY.Name = "numericUpDownY";
            this.numericUpDownY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownY.TabIndex = 2;
            this.numericUpDownY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox1.Location = new System.Drawing.Point(17, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1000, 500);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBoxNeighborhood
            // 
            this.comboBoxNeighborhood.FormattingEnabled = true;
            this.comboBoxNeighborhood.Location = new System.Drawing.Point(252, 41);
            this.comboBoxNeighborhood.Name = "comboBoxNeighborhood";
            this.comboBoxNeighborhood.Size = new System.Drawing.Size(121, 24);
            this.comboBoxNeighborhood.TabIndex = 4;
            // 
            // comboBoxBoundaryCondition
            // 
            this.comboBoxBoundaryCondition.FormattingEnabled = true;
            this.comboBoxBoundaryCondition.Location = new System.Drawing.Point(380, 41);
            this.comboBoxBoundaryCondition.Name = "comboBoxBoundaryCondition";
            this.comboBoxBoundaryCondition.Size = new System.Drawing.Size(121, 24);
            this.comboBoxBoundaryCondition.TabIndex = 5;
            // 
            // comboBoxGrainGrowthType
            // 
            this.comboBoxGrainGrowthType.FormattingEnabled = true;
            this.comboBoxGrainGrowthType.Location = new System.Drawing.Point(508, 41);
            this.comboBoxGrainGrowthType.Name = "comboBoxGrainGrowthType";
            this.comboBoxGrainGrowthType.Size = new System.Drawing.Size(121, 24);
            this.comboBoxGrainGrowthType.TabIndex = 6;
            this.comboBoxGrainGrowthType.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrainGrowthType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sąsiedztwo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(380, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Warunki Brzegowe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Zarodkowanie";
            // 
            // numericUpDownAmountX
            // 
            this.numericUpDownAmountX.Location = new System.Drawing.Point(636, 41);
            this.numericUpDownAmountX.Name = "numericUpDownAmountX";
            this.numericUpDownAmountX.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownAmountX.TabIndex = 10;
            this.numericUpDownAmountX.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numericUpDownAmountY
            // 
            this.numericUpDownAmountY.Location = new System.Drawing.Point(763, 41);
            this.numericUpDownAmountY.Name = "numericUpDownAmountY";
            this.numericUpDownAmountY.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownAmountY.TabIndex = 11;
            this.numericUpDownAmountY.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(636, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "IlośćX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(763, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "IlośćY";
            // 
            // buttonSeed
            // 
            this.buttonSeed.Location = new System.Drawing.Point(17, 45);
            this.buttonSeed.Name = "buttonSeed";
            this.buttonSeed.Size = new System.Drawing.Size(100, 27);
            this.buttonSeed.TabIndex = 14;
            this.buttonSeed.Text = "Seed";
            this.buttonSeed.UseVisualStyleBackColor = true;
            this.buttonSeed.Click += new System.EventHandler(this.buttonSeed_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1069, 594);
            this.Controls.Add(this.buttonSeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDownAmountY);
            this.Controls.Add(this.numericUpDownAmountX);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxGrainGrowthType);
            this.Controls.Add(this.comboBoxBoundaryCondition);
            this.Controls.Add(this.comboBoxNeighborhood);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numericUpDownY);
            this.Controls.Add(this.numericUpDownX);
            this.Controls.Add(this.buttonStart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.NumericUpDown numericUpDownX;
        private System.Windows.Forms.NumericUpDown numericUpDownY;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBoxNeighborhood;
        private System.Windows.Forms.ComboBox comboBoxBoundaryCondition;
        private System.Windows.Forms.ComboBox comboBoxGrainGrowthType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownAmountX;
        private System.Windows.Forms.NumericUpDown numericUpDownAmountY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSeed;
    }
}


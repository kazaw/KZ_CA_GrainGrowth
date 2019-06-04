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
            this.textBoxRay = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxkT = new System.Windows.Forms.TextBox();
            this.textBoxMCIteration = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonMonteCarloStart = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonNucleation = new System.Windows.Forms.Button();
            this.labelTime = new System.Windows.Forms.Label();
            this.textBoxBigPackage = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxSmallPackage = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxRecDeltaTime = new System.Windows.Forms.TextBox();
            this.textBoxRecTime = new System.Windows.Forms.TextBox();
            this.textBoxCritical = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxB = new System.Windows.Forms.TextBox();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonCannon = new System.Windows.Forms.Button();
            this.buttonStartRecrystal = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonOldUni = new System.Windows.Forms.Button();
            this.buttonDisDensityDraw = new System.Windows.Forms.Button();
            this.buttonMicro = new System.Windows.Forms.Button();
            this.buttonEnergy = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountY)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(7, 7);
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
            this.numericUpDownX.Location = new System.Drawing.Point(115, 7);
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
            this.numericUpDownY.Location = new System.Drawing.Point(115, 36);
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
            this.pictureBox1.Enabled = false;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBoxNeighborhood
            // 
            this.comboBoxNeighborhood.FormattingEnabled = true;
            this.comboBoxNeighborhood.Location = new System.Drawing.Point(242, 32);
            this.comboBoxNeighborhood.Name = "comboBoxNeighborhood";
            this.comboBoxNeighborhood.Size = new System.Drawing.Size(121, 24);
            this.comboBoxNeighborhood.TabIndex = 4;
            // 
            // comboBoxBoundaryCondition
            // 
            this.comboBoxBoundaryCondition.FormattingEnabled = true;
            this.comboBoxBoundaryCondition.Location = new System.Drawing.Point(370, 32);
            this.comboBoxBoundaryCondition.Name = "comboBoxBoundaryCondition";
            this.comboBoxBoundaryCondition.Size = new System.Drawing.Size(121, 24);
            this.comboBoxBoundaryCondition.TabIndex = 5;
            // 
            // comboBoxGrainGrowthType
            // 
            this.comboBoxGrainGrowthType.FormattingEnabled = true;
            this.comboBoxGrainGrowthType.Location = new System.Drawing.Point(498, 32);
            this.comboBoxGrainGrowthType.Name = "comboBoxGrainGrowthType";
            this.comboBoxGrainGrowthType.Size = new System.Drawing.Size(121, 24);
            this.comboBoxGrainGrowthType.TabIndex = 6;
            this.comboBoxGrainGrowthType.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrainGrowthType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(242, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sąsiedztwo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Warunki Brzegowe";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(498, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Zarodkowanie";
            // 
            // numericUpDownAmountX
            // 
            this.numericUpDownAmountX.Location = new System.Drawing.Point(626, 32);
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
            this.numericUpDownAmountY.Location = new System.Drawing.Point(753, 32);
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
            this.label4.Location = new System.Drawing.Point(626, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "IlośćX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(753, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "IlośćY";
            // 
            // buttonSeed
            // 
            this.buttonSeed.Location = new System.Drawing.Point(7, 36);
            this.buttonSeed.Name = "buttonSeed";
            this.buttonSeed.Size = new System.Drawing.Size(100, 27);
            this.buttonSeed.TabIndex = 14;
            this.buttonSeed.Text = "Seed";
            this.buttonSeed.UseVisualStyleBackColor = true;
            this.buttonSeed.Click += new System.EventHandler(this.buttonSeed_Click);
            // 
            // textBoxRay
            // 
            this.textBoxRay.Location = new System.Drawing.Point(880, 32);
            this.textBoxRay.Name = "textBoxRay";
            this.textBoxRay.Size = new System.Drawing.Size(100, 22);
            this.textBoxRay.TabIndex = 15;
            this.textBoxRay.Text = "1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(17, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1000, 105);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonStart);
            this.tabPage1.Controls.Add(this.textBoxRay);
            this.tabPage1.Controls.Add(this.numericUpDownX);
            this.tabPage1.Controls.Add(this.buttonSeed);
            this.tabPage1.Controls.Add(this.numericUpDownY);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.comboBoxNeighborhood);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.comboBoxBoundaryCondition);
            this.tabPage1.Controls.Add(this.numericUpDownAmountY);
            this.tabPage1.Controls.Add(this.comboBoxGrainGrowthType);
            this.tabPage1.Controls.Add(this.numericUpDownAmountX);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(992, 76);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Rozrost Ziaren";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBoxkT);
            this.tabPage2.Controls.Add(this.textBoxMCIteration);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.buttonMonteCarloStart);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(992, 76);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "MonteCarlo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(216, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Stała kT";
            // 
            // textBoxkT
            // 
            this.textBoxkT.Location = new System.Drawing.Point(219, 48);
            this.textBoxkT.Name = "textBoxkT";
            this.textBoxkT.Size = new System.Drawing.Size(100, 22);
            this.textBoxkT.TabIndex = 4;
            this.textBoxkT.Text = "0,1";
            // 
            // textBoxMCIteration
            // 
            this.textBoxMCIteration.Location = new System.Drawing.Point(113, 48);
            this.textBoxMCIteration.Name = "textBoxMCIteration";
            this.textBoxMCIteration.Size = new System.Drawing.Size(100, 22);
            this.textBoxMCIteration.TabIndex = 3;
            this.textBoxMCIteration.Text = "1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(113, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Iteracje";
            // 
            // buttonMonteCarloStart
            // 
            this.buttonMonteCarloStart.Location = new System.Drawing.Point(7, 42);
            this.buttonMonteCarloStart.Name = "buttonMonteCarloStart";
            this.buttonMonteCarloStart.Size = new System.Drawing.Size(100, 28);
            this.buttonMonteCarloStart.TabIndex = 0;
            this.buttonMonteCarloStart.Text = "Start";
            this.buttonMonteCarloStart.UseVisualStyleBackColor = true;
            this.buttonMonteCarloStart.Click += new System.EventHandler(this.buttonMonteCarloStart_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonNucleation);
            this.tabPage3.Controls.Add(this.labelTime);
            this.tabPage3.Controls.Add(this.textBoxBigPackage);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.textBoxSmallPackage);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.textBoxRecDeltaTime);
            this.tabPage3.Controls.Add(this.textBoxRecTime);
            this.tabPage3.Controls.Add(this.textBoxCritical);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.textBoxB);
            this.tabPage3.Controls.Add(this.textBoxA);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.buttonCannon);
            this.tabPage3.Controls.Add(this.buttonStartRecrystal);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(992, 76);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Rekrystalizacja";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonNucleation
            // 
            this.buttonNucleation.Enabled = false;
            this.buttonNucleation.Location = new System.Drawing.Point(7, 39);
            this.buttonNucleation.Name = "buttonNucleation";
            this.buttonNucleation.Size = new System.Drawing.Size(100, 28);
            this.buttonNucleation.TabIndex = 18;
            this.buttonNucleation.Text = "Zarodkowanie";
            this.buttonNucleation.UseVisualStyleBackColor = true;
            this.buttonNucleation.Click += new System.EventHandler(this.buttonNucleation_Click);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(948, 45);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(39, 17);
            this.labelTime.TabIndex = 17;
            this.labelTime.Text = "Czas";
            // 
            // textBoxBigPackage
            // 
            this.textBoxBigPackage.Location = new System.Drawing.Point(785, 41);
            this.textBoxBigPackage.Name = "textBoxBigPackage";
            this.textBoxBigPackage.Size = new System.Drawing.Size(50, 22);
            this.textBoxBigPackage.TabIndex = 16;
            this.textBoxBigPackage.Text = "0,3";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(782, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 17);
            this.label14.TabIndex = 15;
            this.label14.Text = "Paka";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(838, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "Paczuszka";
            // 
            // textBoxSmallPackage
            // 
            this.textBoxSmallPackage.Location = new System.Drawing.Point(841, 41);
            this.textBoxSmallPackage.Name = "textBoxSmallPackage";
            this.textBoxSmallPackage.Size = new System.Drawing.Size(50, 22);
            this.textBoxSmallPackage.TabIndex = 13;
            this.textBoxSmallPackage.Text = "0,1";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(678, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Częstotliwość";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(571, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 17);
            this.label11.TabIndex = 11;
            this.label11.Text = "Czas ostrzału";
            // 
            // textBoxRecDeltaTime
            // 
            this.textBoxRecDeltaTime.Location = new System.Drawing.Point(678, 41);
            this.textBoxRecDeltaTime.Name = "textBoxRecDeltaTime";
            this.textBoxRecDeltaTime.Size = new System.Drawing.Size(100, 22);
            this.textBoxRecDeltaTime.TabIndex = 10;
            this.textBoxRecDeltaTime.Text = "0,001";
            // 
            // textBoxRecTime
            // 
            this.textBoxRecTime.Location = new System.Drawing.Point(571, 41);
            this.textBoxRecTime.Name = "textBoxRecTime";
            this.textBoxRecTime.Size = new System.Drawing.Size(100, 22);
            this.textBoxRecTime.TabIndex = 9;
            this.textBoxRecTime.Text = "0,2";
            // 
            // textBoxCritical
            // 
            this.textBoxCritical.Location = new System.Drawing.Point(434, 41);
            this.textBoxCritical.Name = "textBoxCritical";
            this.textBoxCritical.Size = new System.Drawing.Size(130, 22);
            this.textBoxCritical.TabIndex = 8;
            this.textBoxCritical.Text = "4215840142323,42";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(431, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 17);
            this.label10.TabIndex = 7;
            this.label10.Text = "Wartość Kryt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "B";
            // 
            // textBoxB
            // 
            this.textBoxB.Location = new System.Drawing.Point(296, 42);
            this.textBoxB.Name = "textBoxB";
            this.textBoxB.Size = new System.Drawing.Size(130, 22);
            this.textBoxB.TabIndex = 5;
            this.textBoxB.Text = "9,41268203527779";
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(160, 42);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(130, 22);
            this.textBoxA.TabIndex = 4;
            this.textBoxA.Text = "86710969050178,5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 17);
            this.label8.TabIndex = 3;
            this.label8.Text = "A";
            // 
            // buttonCannon
            // 
            this.buttonCannon.Location = new System.Drawing.Point(7, 7);
            this.buttonCannon.Name = "buttonCannon";
            this.buttonCannon.Size = new System.Drawing.Size(100, 28);
            this.buttonCannon.TabIndex = 2;
            this.buttonCannon.Text = "Ognia!";
            this.buttonCannon.UseVisualStyleBackColor = true;
            this.buttonCannon.Click += new System.EventHandler(this.buttonCannon_Click);
            // 
            // buttonStartRecrystal
            // 
            this.buttonStartRecrystal.Enabled = false;
            this.buttonStartRecrystal.Location = new System.Drawing.Point(113, 8);
            this.buttonStartRecrystal.Name = "buttonStartRecrystal";
            this.buttonStartRecrystal.Size = new System.Drawing.Size(100, 28);
            this.buttonStartRecrystal.TabIndex = 1;
            this.buttonStartRecrystal.Text = "Start";
            this.buttonStartRecrystal.UseVisualStyleBackColor = true;
            this.buttonStartRecrystal.Click += new System.EventHandler(this.buttonStartRecrystal_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonOldUni);
            this.tabPage4.Controls.Add(this.buttonDisDensityDraw);
            this.tabPage4.Controls.Add(this.buttonMicro);
            this.tabPage4.Controls.Add(this.buttonEnergy);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(992, 76);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Wizualizacja";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonOldUni
            // 
            this.buttonOldUni.Location = new System.Drawing.Point(4, 39);
            this.buttonOldUni.Name = "buttonOldUni";
            this.buttonOldUni.Size = new System.Drawing.Size(100, 28);
            this.buttonOldUni.TabIndex = 4;
            this.buttonOldUni.Text = "Stare Uni";
            this.buttonOldUni.UseVisualStyleBackColor = true;
            this.buttonOldUni.Click += new System.EventHandler(this.buttonOldUni_Click);
            // 
            // buttonDisDensityDraw
            // 
            this.buttonDisDensityDraw.Location = new System.Drawing.Point(216, 4);
            this.buttonDisDensityDraw.Name = "buttonDisDensityDraw";
            this.buttonDisDensityDraw.Size = new System.Drawing.Size(100, 28);
            this.buttonDisDensityDraw.TabIndex = 3;
            this.buttonDisDensityDraw.Text = "Mikro1";
            this.buttonDisDensityDraw.UseVisualStyleBackColor = true;
            this.buttonDisDensityDraw.Click += new System.EventHandler(this.buttonDisDensityDraw_Click);
            // 
            // buttonMicro
            // 
            this.buttonMicro.Location = new System.Drawing.Point(4, 4);
            this.buttonMicro.Name = "buttonMicro";
            this.buttonMicro.Size = new System.Drawing.Size(100, 28);
            this.buttonMicro.TabIndex = 2;
            this.buttonMicro.Text = "Mikro";
            this.buttonMicro.UseVisualStyleBackColor = true;
            this.buttonMicro.Click += new System.EventHandler(this.buttonMicro_Click);
            // 
            // buttonEnergy
            // 
            this.buttonEnergy.Location = new System.Drawing.Point(110, 4);
            this.buttonEnergy.Name = "buttonEnergy";
            this.buttonEnergy.Size = new System.Drawing.Size(100, 28);
            this.buttonEnergy.TabIndex = 1;
            this.buttonEnergy.Text = "Energia";
            this.buttonEnergy.UseVisualStyleBackColor = true;
            this.buttonEnergy.Click += new System.EventHandler(this.buttonEnergy_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Location = new System.Drawing.Point(309, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(21, 114);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(412, 306);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1069, 594);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmountY)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.TextBox textBoxRay;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonEnergy;
        private System.Windows.Forms.Button buttonMonteCarloStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxkT;
        private System.Windows.Forms.TextBox textBoxMCIteration;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonStartRecrystal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxB;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonCannon;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxCritical;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxRecDeltaTime;
        private System.Windows.Forms.TextBox textBoxRecTime;
        private System.Windows.Forms.TextBox textBoxBigPackage;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxSmallPackage;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonDisDensityDraw;
        private System.Windows.Forms.Button buttonMicro;
        private System.Windows.Forms.Button buttonNucleation;
        private System.Windows.Forms.Button buttonOldUni;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}


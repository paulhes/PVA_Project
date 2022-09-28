
namespace PVA_Project {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.buttonStartGeneticAlgorithm = new System.Windows.Forms.Button();
            this.nUDPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nUDnumGenerations = new System.Windows.Forms.NumericUpDown();
            this.nUDnumElites = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nUDMutationRate = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nUDTournamentSize = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nUDMaxXAxis = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelFitness = new System.Windows.Forms.Label();
            this.label5SelectIndividuum = new System.Windows.Forms.Label();
            this.numericUpDownChooseIndividuum = new System.Windows.Forms.NumericUpDown();
            this.buttonPlotRight = new System.Windows.Forms.Button();
            this.numericUpDownLoops = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRunSimplex = new System.Windows.Forms.Button();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewBioprocess2 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewBioprocess1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.nUDPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDnumGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDnumElites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMutationRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTournamentSize)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMaxXAxis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChooseIndividuum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoops)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBioprocess2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBioprocess1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartGeneticAlgorithm
            // 
            this.buttonStartGeneticAlgorithm.Location = new System.Drawing.Point(8, 18);
            this.buttonStartGeneticAlgorithm.Margin = new System.Windows.Forms.Padding(2);
            this.buttonStartGeneticAlgorithm.Name = "buttonStartGeneticAlgorithm";
            this.buttonStartGeneticAlgorithm.Size = new System.Drawing.Size(100, 31);
            this.buttonStartGeneticAlgorithm.TabIndex = 0;
            this.buttonStartGeneticAlgorithm.Text = "GeneticAlgorithm";
            this.buttonStartGeneticAlgorithm.UseVisualStyleBackColor = true;
            this.buttonStartGeneticAlgorithm.Click += new System.EventHandler(this.buttonStartGeneticAlgorithm_Click);
            // 
            // nUDPopulationSize
            // 
            this.nUDPopulationSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDPopulationSize.Location = new System.Drawing.Point(145, 173);
            this.nUDPopulationSize.Margin = new System.Windows.Forms.Padding(2);
            this.nUDPopulationSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDPopulationSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDPopulationSize.Name = "nUDPopulationSize";
            this.nUDPopulationSize.Size = new System.Drawing.Size(72, 20);
            this.nUDPopulationSize.TabIndex = 2;
            this.nUDPopulationSize.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 173);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Population Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Num Generations";
            // 
            // nUDnumGenerations
            // 
            this.nUDnumGenerations.Location = new System.Drawing.Point(145, 196);
            this.nUDnumGenerations.Margin = new System.Windows.Forms.Padding(2);
            this.nUDnumGenerations.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDnumGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDnumGenerations.Name = "nUDnumGenerations";
            this.nUDnumGenerations.Size = new System.Drawing.Size(72, 20);
            this.nUDnumGenerations.TabIndex = 6;
            this.nUDnumGenerations.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nUDnumElites
            // 
            this.nUDnumElites.Location = new System.Drawing.Point(145, 219);
            this.nUDnumElites.Margin = new System.Windows.Forms.Padding(2);
            this.nUDnumElites.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDnumElites.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDnumElites.Name = "nUDnumElites";
            this.nUDnumElites.Size = new System.Drawing.Size(72, 20);
            this.nUDnumElites.TabIndex = 8;
            this.nUDnumElites.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 219);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Num Elite";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 264);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "MutationRate";
            // 
            // nUDMutationRate
            // 
            this.nUDMutationRate.DecimalPlaces = 2;
            this.nUDMutationRate.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nUDMutationRate.Location = new System.Drawing.Point(145, 264);
            this.nUDMutationRate.Margin = new System.Windows.Forms.Padding(2);
            this.nUDMutationRate.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDMutationRate.Name = "nUDMutationRate";
            this.nUDMutationRate.Size = new System.Drawing.Size(72, 20);
            this.nUDMutationRate.TabIndex = 14;
            this.nUDMutationRate.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 241);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Tournament Size";
            // 
            // nUDTournamentSize
            // 
            this.nUDTournamentSize.Location = new System.Drawing.Point(145, 241);
            this.nUDTournamentSize.Margin = new System.Windows.Forms.Padding(2);
            this.nUDTournamentSize.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDTournamentSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nUDTournamentSize.Name = "nUDTournamentSize";
            this.nUDTournamentSize.Size = new System.Drawing.Size(72, 20);
            this.nUDTournamentSize.TabIndex = 16;
            this.nUDTournamentSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nUDMaxXAxis);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelFitness);
            this.groupBox1.Controls.Add(this.label5SelectIndividuum);
            this.groupBox1.Controls.Add(this.numericUpDownChooseIndividuum);
            this.groupBox1.Controls.Add(this.buttonPlotRight);
            this.groupBox1.Controls.Add(this.numericUpDownLoops);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonRunSimplex);
            this.groupBox1.Controls.Add(this.buttonStartGeneticAlgorithm);
            this.groupBox1.Controls.Add(this.nUDPopulationSize);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nUDTournamentSize);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nUDnumGenerations);
            this.groupBox1.Controls.Add(this.nUDMutationRate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nUDnumElites);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 509);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Elements";
            // 
            // nUDMaxXAxis
            // 
            this.nUDMaxXAxis.Enabled = false;
            this.nUDMaxXAxis.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nUDMaxXAxis.Location = new System.Drawing.Point(145, 332);
            this.nUDMaxXAxis.Margin = new System.Windows.Forms.Padding(2);
            this.nUDMaxXAxis.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.nUDMaxXAxis.Name = "nUDMaxXAxis";
            this.nUDMaxXAxis.Size = new System.Drawing.Size(72, 20);
            this.nUDMaxXAxis.TabIndex = 28;
            this.nUDMaxXAxis.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 339);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "MaxXAxis";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 310);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(222, 20);
            this.label8.TabIndex = 27;
            this.label8.Text = "Genetic Algorithm Parameters";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 151);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Genetic Algorithm Parameters";
            // 
            // labelFitness
            // 
            this.labelFitness.AutoSize = true;
            this.labelFitness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFitness.Location = new System.Drawing.Point(213, 51);
            this.labelFitness.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFitness.Name = "labelFitness";
            this.labelFitness.Size = new System.Drawing.Size(65, 20);
            this.labelFitness.TabIndex = 25;
            this.labelFitness.Text = "Fitness:";
            // 
            // label5SelectIndividuum
            // 
            this.label5SelectIndividuum.AutoSize = true;
            this.label5SelectIndividuum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5SelectIndividuum.Location = new System.Drawing.Point(4, 51);
            this.label5SelectIndividuum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5SelectIndividuum.Name = "label5SelectIndividuum";
            this.label5SelectIndividuum.Size = new System.Drawing.Size(134, 20);
            this.label5SelectIndividuum.TabIndex = 24;
            this.label5SelectIndividuum.Text = "Select Individuum";
            // 
            // numericUpDownChooseIndividuum
            // 
            this.numericUpDownChooseIndividuum.Enabled = false;
            this.numericUpDownChooseIndividuum.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownChooseIndividuum.Location = new System.Drawing.Point(142, 45);
            this.numericUpDownChooseIndividuum.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownChooseIndividuum.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownChooseIndividuum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownChooseIndividuum.Name = "numericUpDownChooseIndividuum";
            this.numericUpDownChooseIndividuum.Size = new System.Drawing.Size(67, 26);
            this.numericUpDownChooseIndividuum.TabIndex = 23;
            this.numericUpDownChooseIndividuum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownChooseIndividuum.ValueChanged += new System.EventHandler(this.numericUpDownChooseIndividuum_ValueChanged);
            // 
            // buttonPlotRight
            // 
            this.buttonPlotRight.Location = new System.Drawing.Point(112, 82);
            this.buttonPlotRight.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPlotRight.Name = "buttonPlotRight";
            this.buttonPlotRight.Size = new System.Drawing.Size(100, 31);
            this.buttonPlotRight.TabIndex = 22;
            this.buttonPlotRight.Text = "CopyChart";
            this.buttonPlotRight.UseVisualStyleBackColor = true;
            this.buttonPlotRight.Click += new System.EventHandler(this.buttonCopyChart_Click);
            // 
            // numericUpDownLoops
            // 
            this.numericUpDownLoops.Location = new System.Drawing.Point(145, 288);
            this.numericUpDownLoops.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownLoops.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownLoops.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownLoops.Name = "numericUpDownLoops";
            this.numericUpDownLoops.Size = new System.Drawing.Size(72, 20);
            this.numericUpDownLoops.TabIndex = 21;
            this.numericUpDownLoops.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 288);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Loop X times";
            // 
            // buttonRunSimplex
            // 
            this.buttonRunSimplex.Location = new System.Drawing.Point(8, 82);
            this.buttonRunSimplex.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRunSimplex.Name = "buttonRunSimplex";
            this.buttonRunSimplex.Size = new System.Drawing.Size(100, 31);
            this.buttonRunSimplex.TabIndex = 18;
            this.buttonRunSimplex.Text = "Simplex";
            this.buttonRunSimplex.UseVisualStyleBackColor = true;
            this.buttonRunSimplex.Click += new System.EventHandler(this.buttonRunSimplex_Click);
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxOutput.Location = new System.Drawing.Point(3, 518);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(344, 201);
            this.textBoxOutput.TabIndex = 17;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewBioprocess2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.chart1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chart2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxOutput, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewBioprocess1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.42857F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.57143F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1507, 722);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // dataGridViewBioprocess2
            // 
            this.dataGridViewBioprocess2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBioprocess2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBioprocess2.Location = new System.Drawing.Point(931, 518);
            this.dataGridViewBioprocess2.Name = "dataGridViewBioprocess2";
            this.dataGridViewBioprocess2.Size = new System.Drawing.Size(573, 201);
            this.dataGridViewBioprocess2.TabIndex = 22;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(352, 2);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(574, 511);
            this.chart1.TabIndex = 19;
            this.chart1.Text = "chart1";
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(930, 2);
            this.chart2.Margin = new System.Windows.Forms.Padding(2);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(575, 511);
            this.chart2.TabIndex = 20;
            this.chart2.Text = "chart2";
            // 
            // dataGridViewBioprocess1
            // 
            this.dataGridViewBioprocess1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBioprocess1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBioprocess1.Location = new System.Drawing.Point(353, 518);
            this.dataGridViewBioprocess1.Name = "dataGridViewBioprocess1";
            this.dataGridViewBioprocess1.Size = new System.Drawing.Size(572, 201);
            this.dataGridViewBioprocess1.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 722);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Bioprocess Modelling";
            ((System.ComponentModel.ISupportInitialize)(this.nUDPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDnumGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDnumElites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMutationRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDTournamentSize)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDMaxXAxis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChooseIndividuum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLoops)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBioprocess2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBioprocess1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartGeneticAlgorithm;
        private System.Windows.Forms.NumericUpDown nUDPopulationSize;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nUDnumGenerations;
        private System.Windows.Forms.NumericUpDown nUDnumElites;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nUDMutationRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nUDTournamentSize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Button buttonRunSimplex;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.NumericUpDown numericUpDownLoops;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonPlotRight;
        private System.Windows.Forms.DataGridView dataGridViewBioprocess1;
        private System.Windows.Forms.DataGridView dataGridViewBioprocess2;
        private System.Windows.Forms.NumericUpDown numericUpDownChooseIndividuum;
        private System.Windows.Forms.Label label5SelectIndividuum;
        private System.Windows.Forms.Label labelFitness;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUDMaxXAxis;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}


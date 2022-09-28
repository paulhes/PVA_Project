using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data;



namespace PVA_Project {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            buttonRunSimplex.Enabled = false;
            buttonPlotRight.Enabled = false;
            //ODEValidation();
            //BioprocessTest();



        }
        private Random random = new Random();
        private double[] bioprocessOptimizedParameters = new double[6];
        private string[] seriesTitles = new string[4];
        private List<double[]> validationData = new List<double[]>();
        private List<Individual<double>> bestIndividuals = new List<Individual<double>>();
        private double cS20;
        private double cX0;
        private double cS10;

        private void MessageOutput(string msg) {
            textBoxOutput.AppendText(msg + Environment.NewLine);
        }

        private void buttonStartGeneticAlgorithm_Click(object sender, EventArgs e) {

            //Path Porbably needs to be changed
            ////
            ////
            ////
            ////
            ////
            string[] strArray; 
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\paulh\iCloudDrive\Studium\0 Life Science MASTER\Programmierung von Algorithmen aus dem Bereich Life Science\PVA_Project\Data\BioprozessDaten_Pvulgaris.csv");
            if (validationData.Count == 0) {
                for (int i = 0; i < lines.Length; i++) {
                    strArray = lines[i].Split(';');
                    if (i == 0) {
                        //Gets titles from the csv for the graph
                        for (int k = 0; k < seriesTitles.Length; k++) {
                            seriesTitles[k] = strArray[k];
                        }
                    } else {
                        try {
                            //Gets data from the CSV if possible
                            double[] values = new double[4];
                            for (int j = 0; j < strArray.Length; j++) {
                                values[j] = Convert.ToDouble(strArray[j]);
                            }
                            validationData.Add(values);
                        } catch (Exception) {
                            MessageBox.Show("csv must have 4 columns and data must be convertable to doubles");
                            return;
                        }
                    }
                }
            }

            //Get Settings from form
            int generations = (int)nUDnumGenerations.Value;
            int population = (int)nUDPopulationSize.Value;
            double mutationRate = (double)nUDMutationRate.Value;
            int eliteSize = (int)nUDnumElites.Value;
            int tournamentSize = (int)nUDTournamentSize.Value;
            int loop = (int)numericUpDownLoops.Value;


            int crossoverPoint = 3;
            double crossoverProbability = 0.5;
            //Parameters: mueMax1, mueMax2, KS1, KS2, YXS1, YXS2
            //double[] genomeLowerBound = new double[] { 0, 0, 0, 0, 0, 0 };
            //double[] genomeUpperBound = new double[] { 1, 1, 1, 1, 10, 10 };
            double[] genomeLowerBound = new double[] { 0.15, 0.15, 0.01, 0.01, 0.1, 0.1 };
            double[] genomeUpperBound = new double[] { 0.5, 0.5, 5, 5, 0.8, 0.8 };
            GABioprocess gAbioprocess = new GABioprocess(generations, population, 6, mutationRate, eliteSize, tournamentSize, crossoverPoint, crossoverProbability
                , genomeLowerBound, genomeUpperBound, validationData, random);

            bestIndividuals.Clear();
            for (int i = 0; i < loop; i++) {
                MessageOutput($"Genetic ALgorithm Loop number: {i}");
                gAbioprocess.Run(MessageOutput);
                bestIndividuals.Add(gAbioprocess.BestIndividual);
            }
            bestIndividuals.Sort();

            cS10 = validationData[0][1];
            cS20 = validationData[0][2];
            cX0 = validationData[0][3];


            //Enable buttons
            buttonRunSimplex.Enabled = true;
            buttonPlotRight.Enabled = true;
            numericUpDownChooseIndividuum.Value = 1;
            numericUpDownChooseIndividuum.Enabled = true;
            nUDMaxXAxis.Enabled = true;
            numericUpDownChooseIndividuum.Maximum = bestIndividuals.Count;
            labelFitness.Text = $"Fitness: {Math.Round(bestIndividuals[0].Fitness, 3)}";
            Array.Copy(bestIndividuals[0].Genome, bioprocessOptimizedParameters, bestIndividuals[0].Genome.Length);
            
            MessageOutput($"Genetic ALgorithm Optimized Parameters: {string.Join(";", bioprocessOptimizedParameters)}");
            PlotLeftGraph();
        }
        private void numericUpDownChooseIndividuum_ValueChanged(object sender, EventArgs e) {
            int nUDNumber = (int)numericUpDownChooseIndividuum.Value - 1;
            Array.Copy(bestIndividuals[nUDNumber].Genome, bioprocessOptimizedParameters, bestIndividuals[nUDNumber].Genome.Length);
            labelFitness.Text = $"Fitness: {Math.Round(bestIndividuals[nUDNumber].Fitness, 3)}.";
            MessageOutput($"Genome: { string.Join(";", bestIndividuals[nUDNumber].Genome)}");
            PlotLeftGraph();
        }

        private void PlotLeftGraph() {
            List<double[]> bioprocessData = EasyInputBioprocess(cS10, cS20, cX0, bioprocessOptimizedParameters);
            List<double[]> growthRateData = CalculateGrowthRate(bioprocessOptimizedParameters, bioprocessData);

            DataSet dataset = new DataSet("Bioprozess");
            DataTable datatable = new DataTable("Euler-Lösung");
            dataset.Tables.Add(datatable);
            datatable.Columns.Add("Zeit [h]", typeof(double));
            datatable.Columns.Add("S1 [kg/m³]", typeof(double));
            datatable.Columns.Add("S2 [kg/m³]", typeof(double));
            datatable.Columns.Add("X [kg/m³]", typeof(double));
            datatable.Columns.Add("Gesamt Wachstumsrate [kg/m³]", typeof(double));

            if (bioprocessData.Count != growthRateData.Count) throw new ArgumentException("bioprocessData and growthRateData have different lengths!");
            for (int i = 0; i < bioprocessData.Count; i++) datatable.Rows.Add(Math.Round(bioprocessData[i][0], 1), bioprocessData[i][1], bioprocessData[i][2], bioprocessData[i][3], growthRateData[i][1]);
            dataGridViewBioprocess1.DataSource = datatable;


            chart1.ChartAreas[0].AxisY.Title = "Konzentrationen in kg/m³";
            chart1.ChartAreas[0].AxisX.Title = "Zeit [h]";
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 5;
            chart1.ChartAreas[0].AxisY2.Title = "Gesamt-Wachstumsrate";
            System.Drawing.Color[] graphColors = new System.Drawing.Color[] { System.Drawing.Color.Red, System.Drawing.Color.Orange, System.Drawing.Color.Blue };
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY2.MinorGrid.Enabled = false;
            chart1.Series.Clear();

            //Add values from the model to the graph
            for (int i = 1; i < seriesTitles.Length; i++) {
                chart1.Series.Add(seriesTitles[i]);
                chart1.Series[seriesTitles[i]].ChartType = SeriesChartType.Point;
                chart1.Series[seriesTitles[i]].Color = graphColors[i - 1];
                for (int j = 0; j < bioprocessData.Count; j++) {
                    chart1.Series[seriesTitles[i]].Points.AddXY(Math.Round(bioprocessData[j][0], 2), bioprocessData[j][i]);
                }
            }

            //Add values from the validation data to the graph
            for (int i = 1; i < seriesTitles.Length; i++) {
                chart1.Series.Add(seriesTitles[i] + "opt.");
                chart1.Series[seriesTitles[i] + "opt."].ChartType = SeriesChartType.Line;
                chart1.Series[seriesTitles[i] + "opt."].Color = graphColors[i - 1];
                for (int j = 0; j < validationData.Count; j++) {
                    chart1.Series[seriesTitles[i] + "opt."].Points.AddXY(Math.Round(validationData[j][0], 2), validationData[j][i]);
                }
            }


            //Add Growth Rate
            chart1.Series.Add("Gesamt-Wachstumsrate");
            chart1.Series["Gesamt-Wachstumsrate"].YAxisType = AxisType.Secondary;
            chart1.Series["Gesamt-Wachstumsrate"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Gesamt-Wachstumsrate"].BorderDashStyle = ChartDashStyle.Dash;
            for (int i = 0; i < bioprocessData.Count; i++) {
                chart1.Series["Gesamt-Wachstumsrate"].Color = System.Drawing.Color.Black;
                chart1.Series["Gesamt-Wachstumsrate"].Points.AddXY(Math.Round(growthRateData[i][0], 2), growthRateData[i][1]);
            }

        }
        //same code twice, bad practice, change later for smarter solution
        private void buttonCopyChart_Click(object sender, EventArgs e) {

            List<double[]> bioprocessData = EasyInputBioprocess(cS10, cS20, cX0, bioprocessOptimizedParameters);
            List<double[]> growthRateData = CalculateGrowthRate(bioprocessOptimizedParameters, bioprocessData);

            DataSet dataset = new DataSet("Bioprozess");
            DataTable datatable = new DataTable("Euler-Lösung");
            dataset.Tables.Add(datatable);
            datatable.Columns.Add("Zeit [h]", typeof(double));
            datatable.Columns.Add("S1 [kg/m³]", typeof(double));
            datatable.Columns.Add("S2 [kg/m³]", typeof(double));
            datatable.Columns.Add("X [kg/m³]", typeof(double));
            datatable.Columns.Add("Gesamt Wachstumsrate [kg/m³]", typeof(double));

            if (bioprocessData.Count != growthRateData.Count) throw new ArgumentException("bioprocessData and growthRateData have different lengths!");
            for (int i = 0; i < bioprocessData.Count; i++) datatable.Rows.Add(Math.Round(bioprocessData[i][0], 1), bioprocessData[i][1], bioprocessData[i][2], bioprocessData[i][3], growthRateData[i][1]);
            dataGridViewBioprocess2.DataSource = datatable;


            chart2.ChartAreas[0].AxisY.Title = "Konzentrationen in kg/m³";
            chart2.ChartAreas[0].AxisX.Title = "Zeit [h]";
            chart2.ChartAreas[0].AxisX.Minimum = 0;
            chart2.ChartAreas[0].AxisX.Interval = 5;
            chart2.ChartAreas[0].AxisY2.Title = "Gesamt-Wachstumsrate";
            System.Drawing.Color[] graphColors = new System.Drawing.Color[] { System.Drawing.Color.Red, System.Drawing.Color.Orange, System.Drawing.Color.Blue };
            chart2.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chart2.ChartAreas[0].AxisY2.MinorGrid.Enabled = false;
            chart2.Series.Clear();

            //Add values from the model to the graph
            for (int i = 1; i < seriesTitles.Length; i++) {
                chart2.Series.Add(seriesTitles[i]);
                chart2.Series[seriesTitles[i]].ChartType = SeriesChartType.Point;
                chart2.Series[seriesTitles[i]].Color = graphColors[i - 1];
                for (int j = 0; j < bioprocessData.Count; j++) {
                    chart2.Series[seriesTitles[i]].Points.AddXY(Math.Round(bioprocessData[j][0], 2), bioprocessData[j][i]);
                }
            }

            //Add values from the validation data to the graph
            for (int i = 1; i < seriesTitles.Length; i++) {
                chart2.Series.Add(seriesTitles[i] + "opt.");
                chart2.Series[seriesTitles[i] + "opt."].ChartType = SeriesChartType.Line;
                chart2.Series[seriesTitles[i] + "opt."].Color = graphColors[i - 1];
                for (int j = 0; j < validationData.Count; j++) {
                    chart2.Series[seriesTitles[i] + "opt."].Points.AddXY(Math.Round(validationData[j][0], 2), validationData[j][i]);
                }
            }


            //Add Growth Rate
            chart2.Series.Add("Gesamt-Wachstumsrate");
            chart2.Series["Gesamt-Wachstumsrate"].YAxisType = AxisType.Secondary;
            chart2.Series["Gesamt-Wachstumsrate"].ChartType = SeriesChartType.FastLine;
            chart2.Series["Gesamt-Wachstumsrate"].BorderDashStyle = ChartDashStyle.Dash;
            for (int i = 0; i < bioprocessData.Count; i++) {
                chart2.Series["Gesamt-Wachstumsrate"].Color = System.Drawing.Color.Black;
                chart2.Series["Gesamt-Wachstumsrate"].Points.AddXY(Math.Round(growthRateData[i][0], 2), growthRateData[i][1]);
            }
        }



        private List<double[]> CalculateGrowthRate(double[] OptimizedParameters, List<double[]> data) {
            double mueMax1 = OptimizedParameters[0];
            double mueMax2 = OptimizedParameters[1];
            double KS1 = OptimizedParameters[2];
            double KS2 = OptimizedParameters[3];


            List<double[]> growthRate = new List<double[]>();
            for (int i = 0; i < data.Count; i++) {
                double mue1 = mueMax1 * data[i][1] / (KS1 + data[i][1]);
                double mue2 = mueMax2 * data[i][2] / (KS2 + data[i][2]);
                double[] array = new double[] { data[i][0], mue1 + mue2 };
                growthRate.Add(array);
            }
            return growthRate;
        }

        private void buttonRunSimplex_Click(object sender, EventArgs e) {
            bioprocessOptimizedParameters = Optimizer.VariableSimplex(SimplexFitnessFunction, 6, 4000, 0.1, true, bioprocessOptimizedParameters);
            PlotLeftGraph();
            MessageOutput($"Simplex Optimized Parameters: {string.Join(";", bioprocessOptimizedParameters)}");
        }

        /// <summary>
        /// This fitness function uses the MeanSquaredError of the modeled bioprocess data and the validationData. 
        /// </summary>
        /// <param name="index">Index of the Individum of the genetic algorithm Population</param>
        /// <returns></returns>
        public double SimplexFitnessFunction(double[] parameters) {
            double cS10 = validationData[0][1];
            double cS20 = validationData[0][2];
            double cX0 = validationData[0][3];
            double mueMax1 = parameters[0];
            double mueMax2 = parameters[1];
            double KS1 = parameters[2];
            double KS2 = parameters[3];
            double YXS1 = parameters[4];
            double YXS2 = parameters[5];
            BioprocessModel bioprocess = new BioprocessModel(cS10, cS20, cX0, mueMax1, mueMax2, KS1, KS2, YXS1, YXS2);

            List<double[]> DataList = bioprocess.Run();
            double[] weights = new double[] { 1, 1, 1.5 };
            double error = Error.SquaredError(DataList, validationData, true, weights);
            if (Double.IsNaN(error)) {
                error = double.PositiveInfinity;
            }
            return error;
            //return 1 / (Error.SquaredError(DataList, validationData, true, weights) + 1);
        }

        /// <summary>
        /// Takes a double[] that corresponds to the genome
        /// </summary>
        /// <param name="cS10"></param>
        /// <param name="cS20"></param>
        /// <param name="cX0"></param>
        /// <param name="OptimizedParameters"></param>
        /// <returns></returns>
        private List<double[]> EasyInputBioprocess(double cS10, double cS20, double cX0, double[] OptimizedParameters) {
            int tEND = (int)nUDMaxXAxis.Value;
            double mueMax1 = OptimizedParameters[0];
            double mueMax2 = OptimizedParameters[1];
            double KS1 = OptimizedParameters[2];
            double KS2 = OptimizedParameters[3];
            double YXS1 = OptimizedParameters[4];
            double YXS2 = OptimizedParameters[5];
            BioprocessModel bioprocess = new BioprocessModel(cS10, cS20, cX0, mueMax1, mueMax2, KS1, KS2, YXS1, YXS2, 0, 0.01, 2.5, tEND);
            return bioprocess.Run();
        }


        private void ODEValidation() {
            double x = 0;
            double y = 1;
            double z = 1;
            double t0 = 0;
            double tEnd = 12;
            double[] initialValues = { x, y, z };
            var dataList = ODESolver.RungeKutta4(initialValues, t0, tEnd, 0.001, Tests.ValidationDGL, 0.1);
            //var dataList = ODESolver.LindnerEuler(initialValues, t0, tEnd, 0.001, ValidationDGL, 0.1);
            chart1.ChartAreas[0].AxisY.Title = "Zeit [h]";
            chart1.ChartAreas[0].AxisX.Title = "Value";
            chart1.Series.Add("x");
            chart1.Series["x"].ChartType = SeriesChartType.Point;
            chart1.Series.Add("y");
            chart1.Series["y"].ChartType = SeriesChartType.Point;
            chart1.Series.Add("z");
            chart1.Series["z"].ChartType = SeriesChartType.Point;
            for (int i = 0; i < dataList.Count; i++) {
                chart1.Series["x"].Points.AddXY(Math.Round(dataList[i][0], 2), dataList[i][1]);
                chart1.Series["y"].Points.AddXY(Math.Round(dataList[i][0], 2), dataList[i][2]);
                chart1.Series["z"].Points.AddXY(Math.Round(dataList[i][0], 2), dataList[i][3]);
            }
        }

        //Probably outdated, didnt update string GA on the way
        //string targetString = textBoxTargetWord.Text;

        //GAStringTest gAStringTest= new GAStringTest(targetString, generations, population, mutationRate, eliteSize, tournamentSize, crossoverPoint, crossoverProbability, random);
        //gAStringTest.Run(MessageOutput);
    }
}

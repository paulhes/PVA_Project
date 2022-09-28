using System;
using System.Collections.Generic;

namespace PVA_Project {
    class GABioprocess {

        public Individual<double> BestIndividual { get; private set; }
        private List<double[]> dataList;
        private int Generations;
        private int PopulationSize;
        private int genomeSize;
        private double MutationRate;
        private int EliteSize;
        private int TournamentSize;
        private int CrossoverPoint;
        private double CrossoverProbability;
        private double[] genomeLowerBound;
        private double[] genomeUpperBound;
        private List<double[]> validationData;
        private GeneticAlgorithm<double> geneticAlgorithmDouble;
        private Random random;
        private double sigma = 20;

        /// <summary>
        /// Setter for the Genetic Algorithm with the Data type double. Optimizes Bioprocess data.
        /// </summary>
        /// <param name="generations"></param>
        /// <param name="populationSize"></param>
        /// <param name="genomeSize"></param>
        /// <param name="mutationRate"></param>
        /// <param name="eliteSize"></param>
        /// <param name="tournamentSize"></param>
        /// <param name="crossoverPoint"></param>
        /// <param name="crossoverProbability"></param>
        /// <param name="genomeLowerBound"></param>
        /// <param name="genomeUpperBound"></param>
        /// <param name="validationData"></param>
        /// <param name="random"></param>
        public GABioprocess(int generations, int populationSize, int genomeSize, double mutationRate, int eliteSize, int tournamentSize, int crossoverPoint, double crossoverProbability, double[] genomeLowerBound, double[] genomeUpperBound, List<double[]> validationData, Random random) {
            Generations = generations;
            PopulationSize = populationSize;
            this.genomeSize = genomeSize;
            MutationRate = mutationRate;
            EliteSize = eliteSize;
            TournamentSize = tournamentSize;
            CrossoverPoint = crossoverPoint;
            CrossoverProbability = crossoverProbability;
            this.genomeLowerBound = genomeLowerBound ?? throw new ArgumentNullException(nameof(genomeLowerBound));
            this.genomeUpperBound = genomeUpperBound ?? throw new ArgumentNullException(nameof(genomeUpperBound));
            this.validationData = validationData ?? throw new ArgumentNullException(nameof(validationData));
            this.random = random ?? throw new ArgumentNullException(nameof(random));
        }

        /// <summary>
        /// Runs the genetic algorithm.
        /// </summary>
        /// <param name="Message"></param>
        public void Run(Action<string> Message) {
            if (Message != null) Message("Start of genetic algorithm!");
            geneticAlgorithmDouble = new GeneticAlgorithm<double>(Generations, PopulationSize, genomeSize, genomeLowerBound, genomeUpperBound, random, GetRandomDouble,
                FitnessFunction, EliteSize, MutationRate, TournamentSize, CrossoverPoint, CrossoverProbability);

            while (geneticAlgorithmDouble.Iteration < geneticAlgorithmDouble.Generations) {
                geneticAlgorithmDouble.NewGeneration();
                if (Message != null) Message($"Generation: {geneticAlgorithmDouble.Iteration} von {geneticAlgorithmDouble.Generations}.");
                if (Message != null) Message($"BestFitness: {geneticAlgorithmDouble.BestIndividual.Fitness}.");
                if (Message != null) Message($"Genom: {string.Join(";", geneticAlgorithmDouble.BestIndividual.Genome)}.");
                if (geneticAlgorithmDouble.BestIndividual.Fitness == 0) break;
                sigma = 0.99 * sigma;
                this.BestIndividual = geneticAlgorithmDouble.BestIndividual;
            }

            if (Message != null) Message("Genetic algorithm finished!");
        }

        /// <summary>
        /// Gets a random double, if mue != null, generates normal distributed doubles with mue as the Median.
        /// </summary>
        /// <param name="max">max value</param>
        /// <param name="min">min value</param>
        /// <param name="mue">mue for normal distribution</param>
        /// <returns></returns>
        private double GetRandomDouble(double max, double min, double mue) {
            if (mue == 0) {
                return random.NextDouble() * (max - min) + min;
            }
            double number;
            do {
                number = myRandom.RandomNormalDistribution(mue, sigma, random);
            } while (number < min || number > max);
            return number;
        }

        /// <summary>
        /// This fitness function uses the MeanSquaredError of the modeled bioprocess data and the validationData.
        /// </summary>
        /// <param name="index">Index of the Individum of the genetic algorithm Population</param>
        /// <returns></returns>
        public double FitnessFunction(double[] genome) {
            double cS10 = validationData[0][1];
            double cS20 = validationData[0][2];
            double cX0 = validationData[0][3];

            double mueMax1 = genome[0];
            double mueMax2 = genome[1];
            double KS1 = genome[2];
            double KS2 = genome[3];
            double YXS1 = genome[4];
            double YXS2 = genome[5];
            BioprocessModel bioprocess = new BioprocessModel(cS10, cS20, cX0, mueMax1, mueMax2, KS1, KS2, YXS1, YXS2);
            dataList = bioprocess.Run();
            //CS1 = 0, CS2 = 1, CX = 2,
            double[] weights = new double[] { 1, 1, 1.5 };
            double error = Error.SquaredError(dataList, validationData, true, weights);
            if (Double.IsNaN(error)) {
                error = double.PositiveInfinity;
            }
            return error;
        }

    } //End of class
} //End of namespace
//using System;

//namespace PVA_Project {
//    class GAStringTest {

//        string TargetString = "Paul";
//        //string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
//        string AllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
//        int Generations;
//        int PopulationSize = 100;
//        double MutationRate = 0.01;
//        int EliteSize = 5;
//        int TournamentSize;
//        int CrossoverPoint;
//        double CrossoverProbability;

//        private GeneticAlgorithm<char>     geneticAlgorithmChar;
//        private Random random;

//        public GAStringTest(string targetString, int generations, int populationSize, double mutationRate, int eliteSize, int tournamentSize, int crossoverPoint, double crossoverProbability, Random random) {
//            TargetString = targetString;
//            Generations = generations;
//            PopulationSize = populationSize;
//            MutationRate = mutationRate;
//            EliteSize = eliteSize;
//            TournamentSize = tournamentSize;
//            CrossoverPoint = crossoverPoint;
//            CrossoverProbability = crossoverProbability;
//            this.random = random;
//        }



//        public void Run(Action<string> Message) {
//            if (Message != null) Message("Start of genetic algorithm!");

//            random = new Random();
//            //Workaround, not needed for string
//            char[] genomeUpperBound = new char[TargetString.Length];
//            char[] genomeLowerBound = new char[TargetString.Length];
//            for (int i = 0; i < TargetString.Length; i++) {
//                genomeLowerBound[i] = 'a';
//                genomeUpperBound[i] = 'a';
//            }
//            geneticAlgorithmChar = new GeneticAlgorithm<char>(Generations, PopulationSize, TargetString.Length, genomeLowerBound, genomeUpperBound, random, GetRandomChar,
//                FitnessFunction, EliteSize, MutationRate, TournamentSize, CrossoverPoint, CrossoverProbability);
//            while (    geneticAlgorithmChar.Iteration <     geneticAlgorithmChar.Generations) {
//                    geneticAlgorithmChar.NewGeneration();
//                if (Message != null) Message($"Generation: {geneticAlgorithmChar.Iteration} von {geneticAlgorithmChar.Generations}.");
//                if (Message != null) Message($"BestFitness: {geneticAlgorithmChar.BestIndividual.Fitness}.");
//                if (Message != null) Message($"Genom: {string.Join(";", geneticAlgorithmChar.BestIndividual.Genome)}.");
//            }

//            if (Message != null) Message("Genetic algorithm finished!");
//        }

//        private char GetRandomChar(char a, char b, char c ) {
//            int i = random.Next(AllowedCharacters.Length);
//            return AllowedCharacters[i];
//        }

//        private double FitnessFunction(int index) {
//            Individual<char> individual =     geneticAlgorithmChar.Population[index];
//            double score = StringSimilarity.LevenshteinDistance(TargetString, new string(individual.Genome));
//            score = 1.0 / (score + 1);
//            return score;
//        }

//    } //End of class
//} //End of namespace

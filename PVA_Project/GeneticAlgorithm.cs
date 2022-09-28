using System;
using System.Collections.Generic;

namespace PVA_Project {

    /// <summary>
    /// Provides Constructor and methods for a generic genetic algorithm.
    /// </summary>
    public class GeneticAlgorithm<T> {
        public List<Individual<T>> Population { get; private set; }
        public int Generations { get; private set; }
        public int Iteration { get; private set; }
        public Individual<T> BestIndividual { get; private set; }

        private int eliteSize;
        private double mutationRate;
        private int tournamentSize;
        private int crossoverPoint;
        private double crossoverProbability;
        private List<Individual<T>> newPopulation;
        private List<Individual<T>> tournamentList;
        private Random random;

        /// <summary>
        /// Constructor for the genetic algorithm
        /// </summary>
        /// <param name="numGenerations">Number of generations</param>
        /// <param name="populationSize">Size of the Population</param>
        /// <param name="genomeSize"></param>
        /// <param name="random"></param>
        /// <param name="getRandomGene"></param>
        /// <param name="fitnessFunction"></param>
        /// <param name="eliteSize"></param>
        /// <param name="mutationRate"></param>
        /// <param name="tournamentSize"></param>
        /// <param name="crossoverPoint"></param>
        /// <param name="crossoverProbability"></param>
        public GeneticAlgorithm(int numGenerations, int populationSize, int genomeSize, T[] genomeLowerBound, T[] genomeUpperBound, Random random,
            Func<T,T,T,T> getRandomGene, Func<T[], double> fitnessFunction, int eliteSize, double mutationRate, int tournamentSize,
            int crossoverPoint, double crossoverProbability) {
            Iteration = 0;
            Generations = numGenerations;
            this.eliteSize = eliteSize;
            this.mutationRate = mutationRate;
            this.tournamentSize = tournamentSize;
            this.crossoverPoint = crossoverPoint;
            this.crossoverProbability = crossoverProbability;
            Population = new List<Individual<T>>();
            newPopulation = new List<Individual<T>>();
            tournamentList = new List<Individual<T>>();
            this.random = random;

            //creates new Generation by adding to the List
            for (int i = 0; i < populationSize; i++) {
                Population.Add(new Individual<T>(genomeSize, genomeLowerBound, genomeUpperBound, random, getRandomGene, fitnessFunction, initialiseGenome: true));
            }
        }

        /// <summary>
        /// Creates a new Generation from the old Generation via Selection, Crossover & Mutation
        /// </summary>
        public void NewGeneration() {
            if (Population.Count == 0) return; //failsafe
            if (Iteration == 0) {
                ComputeFitness();
                Population.Sort();
            }

            newPopulation.Clear();

            for (int i = 0; i < Population.Count; i++) {
                if (i < eliteSize) {
                    newPopulation.Add(new Individual<T>(Population[i]));
                } else {
                    Individual<T> individual1 = TournamentSelection(tournamentSize);
                    Individual<T> individual2 = TournamentSelection(tournamentSize);
                    Individual<T> newIndividual = new Individual<T>(individual1.OnePointCrossover(individual2, crossoverPoint, crossoverProbability));

                    newIndividual.Mutation(mutationRate);

                    newPopulation.Add(newIndividual);
                }
            }
            
            //reuse List instead of instatiating new one every time
            List<Individual<T>> temporaryList = Population;
            Population = newPopulation;
            newPopulation = temporaryList; //needed, otherwise Population and newPopulation contain the same pointer

            ComputeFitness();
            Population.Sort();
            this.BestIndividual = new Individual<T>(Population[0]); //saves current best individual
            //Console.WriteLine($"BestFitness = {BestIndividual.Fitness}");
            Iteration++;
        }
        /// <summary>
        /// Computes the fitness for each Individual
        /// </summary>
        private void ComputeFitness() {

            for (int i = 0; i < Population.Count; i++) {
                Population[i].ComputeFitness();
            }
        }

        /// <summary>
        /// Performs a tournament selection by comparing a number of randomly selected Individuals from the population
        /// and selecting the best one
        /// </summary>
        /// <param name="tournamentSize"></param>
        /// <returns>Individual with the highest fitness from the current tournament</returns>
        private Individual<T> TournamentSelection(int tournamentSize) {
            tournamentList.Clear();
            for (int i = 0; i < Population.Count; i++) { //selection sampling
                if (tournamentSize == 0) { break; }
                if ((double)tournamentSize / (Population.Count - i) >= random.NextDouble()) {
                    tournamentSize--;
                    tournamentList.Add(Population[i]);
                }
            }
            tournamentList.Sort();
            return tournamentList[0];
        }



    }//end of class
}//end of namespace

using System;

namespace PVA_Project {

    //DNA = Individual, Genome = Genes

    /// <summary>
    /// Class <c>Individual</c> provides a generic Individual for use in a Genetic algorithm.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// 
    public class Individual<T> : IComparable<Individual<T>> {

        public T[] Genome { get; private set; }
        public double Fitness { get; private set; }
        private Random random;
        private T[] genomeLowerBound;    
        private T[] genomeUpperBound;
        private Func<T, T, T, T> getRandomGene;
        private Func<T[], double> fitnessFunction;
        /// <summary>
        /// Constructor for an Individual
        /// </summary>
        /// <param name="genomeSize">Size of the Genome Array</param>
        /// <param name="genomeLowerBound">Lower bounds for genome generation</param>
        /// <param name="genomeUpperBound">// upper bounds for genome generation</param>
        /// <param name="random">random object</param>
        /// <param name="getRandomGene">Function for generating random gene</param>
        /// <param name="fitnessFunction">Function for calculating fitness</param>
        /// <param name="initialiseGenome">Should Genome be randomly initilized</param>
        public Individual(int genomeSize, T[] genomeLowerBound, T[] genomeUpperBound, Random random, Func<T, T, T, T> getRandomGene, Func<T[], double> fitnessFunction, bool initialiseGenome) {
            Genome = new T[genomeSize];
            this.random = random;
            this.getRandomGene = getRandomGene;
            this.fitnessFunction = fitnessFunction;
            this.genomeLowerBound = genomeLowerBound;
            this.genomeUpperBound = genomeUpperBound;

            if (initialiseGenome) { //Genome will only be initialised if true
                for (int i = 0; i < Genome.Length; i++) {
                    Genome[i] = getRandomGene(genomeUpperBound[i], genomeLowerBound[i], Genome[i]);
                }
            }
        }

        ///https://levelup.gitconnected.com/5-ways-to-clone-an-object-in-c-d1374ec28efa
        /// <summary>
        /// Another constructor for copying an individual
        /// </summary>
        /// <param name="individual"></param>
        public Individual(Individual<T> individual) {
            this.Genome = new T[individual.Genome.Length]; //this is important, otherwise some arrays have the same pointers, which creates unpredictable problems
            Array.Copy(individual.Genome, this.Genome, Genome.Length);
            Fitness = individual.Fitness;
            this.random = individual.random;
            this.genomeLowerBound = individual.genomeLowerBound;
            this.genomeUpperBound = individual.genomeUpperBound;
            this.getRandomGene = individual.getRandomGene;
            this.fitnessFunction = individual.fitnessFunction;
        }



        /// <summary>
        /// This Functiion defines that Individuals get sorted by their fitness
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Individual<T> other) {
            return Fitness.CompareTo(other.Fitness); //ascending
            //return other.Fitness.CompareTo(Fitness); //descending
        }

        /// <summary>
        /// Computes the Fitness of the Individual.
        /// </summary>
        /// <returns>The Fitness value.</returns>
        public double ComputeFitness() {
            Fitness = fitnessFunction(this.Genome);
            return Fitness;
        }

        /// <summary>
        /// Performs a Crossover Operation for two Individuals
        /// </summary>
        /// <param name="otherIndividual">The other Individual (parent) for Crossover</param>
        /// <returns>a new Individual</returns>
        public Individual<T> Crossover(Individual<T> otherIndividual) {

            Individual<T> newIndividual = new Individual<T>(Genome.Length, genomeLowerBound, genomeUpperBound, random, getRandomGene, fitnessFunction, initialiseGenome: false);

            for (int i = 0; i < Genome.Length; i++) {
                if (random.NextDouble() < 0.5) { //50/50 chance of getting value from one or other Individual
                    newIndividual.Genome[i] = Genome[i];
                } else {
                    newIndividual.Genome[i] = otherIndividual.Genome[i];
                }
            }

            return newIndividual;
        }
        /// <summary>
        /// Performs a one Point Crossover. The point of Crossover and the probability can be defined.
        /// </summary>
        /// <param name="otherIndividual">other Individual partaking in the crossover</param>
        /// <param name="crossoverPoint">location of the crossover</param>
        /// <param name="crossoverProbability">probability of the crossover happening</param>
        /// <returns>new Individual with possibly new genome</returns>
        public Individual<T> OnePointCrossover(Individual<T> otherIndividual, int crossoverPoint, double crossoverProbability) {

            Individual<T> newIndividual = new Individual<T>(Genome.Length, genomeLowerBound, genomeUpperBound, random, getRandomGene, fitnessFunction, initialiseGenome: false);
            if (random.NextDouble() < crossoverProbability) { //Chance of crossover
                Array.Copy(Genome, newIndividual.Genome, crossoverPoint);
                Array.Copy(Genome, crossoverPoint, otherIndividual.Genome, crossoverPoint, Genome.Length - crossoverPoint);
            } else Genome.CopyTo(newIndividual.Genome, 0); //no crossover
            return newIndividual;
        }

        /// <summary>
        /// Performs a mutation for the Individual if the random number that is generated is bigger then the mutation Rate.
        /// </summary>
        /// <param name="mutationRate">Defines how likely Mutation occurs</param>
        public void Mutation(double mutationRate) {
            for (int i = 0; i < Genome.Length; i++) {
                if (random.NextDouble() < mutationRate) {
                    Genome[i] = getRandomGene(genomeUpperBound[i], genomeLowerBound[i], Genome[i]);
                }
            }
        }



    }// end of class


}// end of namespace

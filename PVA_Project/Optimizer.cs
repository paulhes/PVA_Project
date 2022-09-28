using System;

namespace PVA_Project {
    //https://towardsdatascience.com/the-art-of-effective-visualization-of-multi-dimensional-data-6c7202990c57 //implement someday
    public class Optimizer {
        //Variables for normal, reflected, expanding and contracting simplex
        private static double alpha = 1;
        private static double gamma = 1.5;
        private static double rho = 0.5;
        private static double sigma = 0.5;

        /// <summary>
        /// Performs a variable simplex algorithm according to Nelder-Mead (also Downhill Simplex, Nelder Mead method). It is an iterative algorithm for linear and non-linear Optimization problems.
        /// </summary>
        /// <param name="targetFunction">Target function to evaluate the points</param>
        /// <param name="dimensions">Dimensions of the array for the target function</param>
        /// <param name="MaxIterations">(optional) Maximum Iterations after which the Simplex Stops</param>
        /// <param name="distance">(optional) Distance for the Start Simplex</param>
        /// <param name="convergence">(optional) If true, stops when simplex is converging</param>
        /// <param name="initialValues">(optional) Initial values as a starting point</param>
        /// <returns>optimized double[]</returns>
        public static double[] VariableSimplex(Func<double[], double> targetFunction, int dimensions, int MaxIterations = 1000, double distance = 0.1, bool convergence = true, double[] initialValues = null) {
            Random rnd = new Random();
            double[][] simplex = new double[dimensions + 1][];
            int counter = -1;
            // generate initial arrays dim + 1
            for (int array = 0; array < dimensions + 1; array++) {
                simplex[array] = new double[dimensions];
                for (int index = 0; index < dimensions; index++) {
                    if (initialValues == null) { //generate random values if no initial values are given
                        simplex[array][index] = rnd.NextDouble() * 20 - 10; //random value between -10 and 10
                    } else {
                        simplex[array][index] = initialValues[index]; //generate start simplex by adding the distance to the points
                        if (counter >= 0) {
                            initialValues[index] += distance;
                        }
                        counter++;
                    }
                }
            }
            counter = 0;
            // Loop until the simplex is convergeing or the Maximum iterations are reached
            while (counter < MaxIterations) {
                // Evaluate
                double[] functionValues = new double[dimensions + 1];
                int[] indices = new int[dimensions + 1];
                for (int vertex = 0; vertex < dimensions + 1; vertex++) {
                    functionValues[vertex] = targetFunction(simplex[vertex]);
                    indices[vertex] = vertex;
                }
                for (int i = 0; i < functionValues.Length; i++) {
                    if (Double.IsNaN(functionValues[i])) {
                        Console.WriteLine($"NaN, Retry, function not defined for negatives?");
                        return simplex[0];
                    }
                }

                // Sort
                Array.Sort(functionValues, indices); //minimize
                //Array.Sort(indices, functionValues); //maximize
                Console.WriteLine($"Error values: {string.Join(";", functionValues)}");

                // Find geometric center of the simplex excluding the vertex/edge with highest function value.
                double[] geometricCenter = new double[dimensions];

                for (int index = 0; index < dimensions; index++) {
                    geometricCenter[index] = 0;
                    for (int vertex = 0; vertex < dimensions + 1; vertex++) {
                        if (vertex != indices[dimensions]) {
                            geometricCenter[index] += simplex[vertex][index] / dimensions;
                        }
                    }
                }

                // convergence?
                if (convergence) {
                    if (Math.Abs(targetFunction(geometricCenter) - functionValues[0]) < 1e-13) break;
                }

                //Reflect
                double[] reflectionPoint = new double[dimensions];
                for (int index = 0; index < dimensions; index++) {
                    reflectionPoint[index] = geometricCenter[index] + alpha * (geometricCenter[index] - simplex[indices[dimensions]][index]);
                }

                double reflectionValue = targetFunction(reflectionPoint);

                if (reflectionValue >= functionValues[0] & reflectionValue < functionValues[dimensions - 1]) {
                    simplex[indices[dimensions]] = reflectionPoint;
                    counter++;
                    continue;
                }


                // Expand
                if (reflectionValue < functionValues[0]) {
                    double[] expansionPoint = new double[dimensions];
                    for (int index = 0; index < dimensions; index++) {
                        expansionPoint[index] = geometricCenter[index] + gamma * (reflectionPoint[index] - geometricCenter[index]);
                    }
                    double expansionValue = targetFunction(expansionPoint);

                    if (expansionValue < reflectionValue) {
                        simplex[indices[dimensions]] = expansionPoint;
                    } else {
                        simplex[indices[dimensions]] = reflectionPoint;
                    }
                    counter++;
                    continue;
                }

                // Contract
                double[] contractionPoint = new double[dimensions];
                for (int index = 0; index < dimensions; index++) {
                    contractionPoint[index] = geometricCenter[index] + rho * (simplex[indices[dimensions]][index] - geometricCenter[index]);
                }

                double contractionValue = targetFunction(contractionPoint);

                if (contractionValue < functionValues[dimensions]) {
                    simplex[indices[dimensions]] = contractionPoint;
                    counter++;
                    continue;
                }

                //Shrink
                double[] bestPoint = simplex[indices[0]];
                for (int vertex = 0; vertex <= dimensions; vertex++) {
                    for (int index = 0; index < dimensions; index++) {

                        simplex[vertex][index] = bestPoint[index] + sigma * (simplex[vertex][index] - bestPoint[index]);

                    }
                }
                counter++;
            }

            return simplex[0];
        }

    }
}

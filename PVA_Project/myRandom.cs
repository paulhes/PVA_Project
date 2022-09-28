using System;

namespace PVA_Project {
    /// <summary>
    /// This class contains methods for the creating random numbers.
    /// </summary>
    public static class myRandom {

        /// <summary>
        /// This function returns normally distributed random numbers.
        /// </summary>
        /// <param name="mue">mean of the distribution of the random numbers</param>
        /// <param name="sigma">standard deviation of the random numbers</param>
        /// <param name="random"></param>
        /// <returns></returns>
        public static double RandomNormalDistribution(double mue, double sigma, Random random) {
            double u, v, s;
            do { // creates random number [-1, 1] mit 0 < u² + v² < 1
                u = random.NextDouble() * 2 - 1; //  -1 < Random number < 1
                v = random.NextDouble() * 2 - 1;
                s = u * u + v * v;
            } while (0 == s || s >= 1);
            s = Math.Sqrt(-2 * Math.Log(s) / s);
            return mue + sigma * u * s;
        }
    } //end class
} //end namespace

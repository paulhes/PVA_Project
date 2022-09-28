using System;

namespace PVA_Project {
    public static class StringSimilarity {
        /// <summary> This function computes the Levenshtein distance of 2 strings. (String similarity)
        /// Equal strings - Distance = 0.
        /// One letter difference - Distance = 1.
        /// </summary>
        /// <param name="first">First string.</param> 
        /// <param name="second">Second string.</param> 
        /// <returns>The Levenshtein Distance of the input strings.</returns>
        public static int LevenshteinDistance(string first, string second) {
            int n = first.Length;
            int m = second.Length;
            if (n == 0) return m;
            if (m == 0) return n;
            int[,] d = new int[n + 1, m + 1]; //creates a matrix

            for (int i = 0; i <= n; i++) {
                d[i, 0] = i;
            }
            for (int i = 0; i <= m; i++) {
                d[0, i] = i;
            }

            for (int i = 1; i <= n; i++) {
                for (int j = 1; j <= m; j++) {
                    int cost;
                    if (second.Substring(j - 1, 1) == first.Substring(i - 1, 1)) {
                        cost = 0;
                    } else {
                        cost = 1;
                    }

                    //int cost = (second.Substring(j - 1, 1) == first.Substring(i - 1, 1) ? 0 : 1); //? = Ersatz für if Bedingung

                    d[i, j] = Math.Min(Math.Min(
                        d[i - 1, j] + 1,
                        d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }
            return d[n, m];
        }
    }//End of class
}//End of namespace

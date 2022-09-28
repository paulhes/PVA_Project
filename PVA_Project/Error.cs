using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVA_Project {
    class Error {

        /// <summary>
        ///Calculates the squared Error of a data and validation data pair. Both datasets must have the same length and width. 
        ///The first column must be the time and the rest data points.
        /// Optionally weights the differents parameters with given values
        /// </summary>
        /// <param name="data"></param>
        /// <param name="validationData"></param>
        /// <param name="useWeights">(optional) use weights or not</param>
        /// <param name="weights">must be the same size as the double arrays of the data lists</param>
        /// <returns></returns>
        public static double SquaredError(List<double[]> data, List<double[]> validationData, bool useWeights = false, double[] weights = null) {
            if (data == null || validationData == null) throw new ArgumentNullException("Lists may not be null");
            if (data.Count != validationData.Count) throw new ArgumentException("Input Lists must have same lengths");
            if (data[0].Length != validationData[0].Length) throw new ArgumentException("Double Arrays of the Input Lists must be of the same size");
            if (useWeights && weights.Length != data[0].Length - 1) throw new ArgumentException("Double Array of weight bust be of the same size as double arrays in the lists");
            int arrayLength = data[0].Length;
            double[] sum = new double[arrayLength-1];
            for (int i = 0; i < sum.Length; i++) sum[i] = 0;
            double difference;
            for (int k = 0; k < data.Count; k++) {
                for (int i = 1; i < arrayLength; i++) { //skips time
                    difference = data[k][i] - validationData[k][i];
                    sum[i-1] += difference * difference;
                }
            }
            double total = 0;
            for (int i = 0; i < sum.Length; i++) {
                if (useWeights) sum[i] *= weights[i];
                total += sum[i];
            }
            return total;
        }



    }
}

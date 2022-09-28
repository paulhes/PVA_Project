using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVA_Project {
    class Tests {

        /// <summary>
        /// Runs tests for:
        /// 
        /// </summary>
        public void Run() {
            SimplexTest();
            CopyTests();
        }



        private static int numberOfFunctionCalls = 0;
        private void SimplexTest() {
            double[] initial = new double[] { -3, -4 };
            double[] result = new double[2];
            result = Optimizer.VariableSimplex(RosenBrock, 2, 100, 0.1, true, initial);
            Console.WriteLine("RosenBrock formula:");
            Console.WriteLine("Solution: {0}, {1}", result[0], result[1]);
            Console.WriteLine("Function value: {0}", RosenBrock(result));
            Console.WriteLine("Number of functioncalls: {0}", numberOfFunctionCalls);
            numberOfFunctionCalls = 0;

            result = Optimizer.VariableSimplex(HimmelBlau, 2);
            Console.WriteLine("HimmelBlau formula:");
            Console.WriteLine("Solution: {0}, {1}", result[0], result[1]);
            Console.WriteLine("Function value: {0}", HimmelBlau(result));
            Console.WriteLine("Number of functioncalls: {0}", numberOfFunctionCalls);
            numberOfFunctionCalls = 0;
        }

        private static double HimmelBlau(double[] x) {
            numberOfFunctionCalls++;
            return Math.Pow(Math.Pow(x[0], 2) + x[1] - 11, 2) + Math.Pow(x[0] + Math.Pow(x[1], 2) - 7, 2);
        }

        private static double RosenBrock(double[] x) {
            numberOfFunctionCalls++;
            return Math.Pow(1 - x[0], 2) + 100 * Math.Pow(x[1] - Math.Pow(x[0], 2), 2);
        }

        private void CopyTests() {
            double[] a = new double[] { 11, 12, 13, 14, 15, 16 };
            double[] b = new double[] { 1, 2, 3, 4, 5, 6 };
            double[] c = new double[6];

            Array.Copy(a, c, 3);
            Array.Copy(b, 3, c, 3, b.Length - 3);
        }

        public static double[] ValidationDGL(double[] x, double t) {
            //dx/dt = y* z
            //dy/dt = -x* z
            //dz/dt = -0.51*x* y
            //Anfangsbedingungen: x(0) = 0, y(0) = 1, z(0) = 1, t0 = 0, tende = 12
            double[] dxdt = new double[3];

            dxdt[0] = x[1] * x[2];
            dxdt[1] = -x[0] * x[2];
            dxdt[2] = -0.51 * x[0] * x[1];
            return dxdt;
        }





    }
}

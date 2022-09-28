using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PVA_Project {
    public class ODESolver {

        /// <summary>Delegate of an ODE.</summary>
        /// <param name="x">Current values of all process variables.</param>
        /// <param name="t">Current time.</param>
        /// <returns>The derivative of all process variables.</returns>
        public delegate double[] ODE(double[] x, double t);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="InitialValues"></param>
        /// <param name="t0"></param>
        /// <param name="tEnd"></param>
        /// <param name="deltaT"></param>
        /// <param name="equations"></param>
        /// <param name="dta"></param>
        /// <returns></returns>
        public static List<Double[]> myEuler(double[] InitialValues, double t0, double tEnd, double deltaT, ODE equations, double dta) {
            List<Double[]> dlist = new List<Double[]>();

            double[] p = new double[InitialValues.Length]; //aktuelle Prozessgroessen
            p = InitialValues;
            double t = 0; //aktuelle Zeit


            //while (t <= tEnd)
            while (p[1] >= 0.002) //S(t) >= S(t)Min
            {
                if (t >= t0) {
                    double[] pZeit = new double[InitialValues.Length + 1];
                    Array.Copy(p, pZeit, p.Length);
                    pZeit[p.Length] = t;
                    dlist.Add(pZeit);
                    t0 += dta;
                }
                double[] derivative = equations(p, t);
                for (int i = 0; i < derivative.Length; i++) {
                    p[i] = p[i] + derivative[i] * deltaT;
                }
                t += deltaT;
            }
            return dlist;
        }


        /// <summary>Numerically solve the system of ordinary differential equations given in equations using the Euler method.</summary>
        /// <param name="InitialValues">Initial values for all process variables.</param>
        /// <param name="time0">Start time.</param>
        /// <param name="timeEnd">End time.</param>
        /// <param name="TimeStepsize">Time step (must be a positive and small value).</param
        /// <param name="equations">The equation system. See <see cref="ODE"/>.</param>
        /// <param name="dtOutput" >Time step for output value generation. Positive and for many applications much larger than dt.</param>
        /// <param name="LowerBounds">(Optional) One lower bound for each process variable. If at any time the current value drops below
        /// a bound, the solver stops early.</param>
        /// <param name="UpperBounds">(Optional) One upper bound for each process variable. If at any time the current value exceeds
        /// a bound, the solver stops early.</param>
        /// <returns>A list of arrays (time and values of process variables) for each output time point.</returns>
        public static List<double[]> LindnerEuler(double[] InitialValues, double time0, double timeEnd, double deltaT, ODE equations,
        double dtOutput, double[] LowerBounds = null, double[] UpperBounds = null) {
            #region Check Inputs
            if (InitialValues == null) throw new ArgumentNullException("initialValues may not be null!");
            if (timeEnd < time0) throw new ArgumentException("tend must be greater than t0.");
            if (deltaT < 0) throw new ArgumentException("dt must be a positive (and small) value.");
            if (dtOutput < 0) throw new ArgumentException("dtOutput must be a positive value");
            if (equations == null) throw new ArgumentNullException("equations may not be null!");
            if (LowerBounds != null && InitialValues.Length != LowerBounds.Length)
                throw new ArgumentException("LowerBounds were given, but it does not contain the same amount of values as InititalValues.");
            if (UpperBounds != null && InitialValues.Length != UpperBounds.Length)
                throw new ArgumentException("UpperBounds were given but it does not contain the same amount of calues as InitialVaules.");
            //test ode System
            double[] test = equations(InitialValues, time0);
            if (test == null) throw new ArgumentException("The equation system may not return a null array");
            if (test.Length != InitialValues.Length)
                throw new ArgumentException($"The equation system returned {test.Length} values, but {InitialValues.Length} were expected.");
            #endregion

            #region Initialize
            //Array of process variables of ode System
            double[] x = new double[InitialValues.Length];
            Array.Copy(InitialValues, x, x.Length);
            //Create output list
            List<double[]> OutputList = new List<double[]>();
            //Output time
            double tOutput = time0;
            #endregion

            #region Euler Method
            bool Stop = false;
            for (double t = time0; t <= timeEnd; t += deltaT) {
                if (t >= tOutput) {
                    //Output time reached: create copy of x and add to list
                    double[] xout = new double[x.Length + 1];
                    xout[0] = t;
                    Array.Copy(x, 0, xout, 1, x.Length);
                    OutputList.Add(xout);
                    tOutput += dtOutput;
                }
                // get derivatives and compute new process variables
                double[] dxdt = equations(x, t);
                for (int i = 0; i < x.Length; i++) x[i] += dxdt[i] * deltaT;
                // check additional stopping criteria (upper/lower bounds for the process variables)
                if (LowerBounds != null) {
                    for (int i = 0; i < x.Length; i++) {
                        if (x[i] < LowerBounds[i]) { Stop = true; break; }
                    }
                }
                if (UpperBounds != null) {
                    for (int i = 0; i < x.Length; i++) {
                        if (x[i] > UpperBounds[i]) { Stop = true; break; }
                    }
                }
                if (Stop) break;
            }
            #endregion
            return OutputList;
        }

        /// <summary>Numerically solve the system of ordinary differential equations given in equations using the Runge Kutta method of the 4th degree.</summary>
        /// <param name="InitialValues">Initial values for all process variables.</param>
        /// <param name="t0">Start time.</param>
        /// <param name="tEnd">End time.</param>
        /// <param name="deltaT">Time step (must be a positive and small value).</param
        /// <param name="equations">The equation system. See <see cref="ODE"/>.</param>
        /// <param name="dtOutput" >Time step for output value generation. Positive and for many applications much larger than dt.</param>
        /// <param name="LowerBounds">(Optional) One lower bound for each process variable. If at any time the current value drops below
        /// a bound, the solver stops early.</param>
        /// <param name="UpperBounds">(Optional) One upper bound for each process variable. If at any time the current value exceeds
        /// a bound, the solver stops early.</param>
        /// <returns>A list of arrays (time and values of process variables) for each output time point.</returns>
        public static List<double[]> RungeKutta4(double[] InitialValues, double t0, double tEnd, double deltaT, ODE equations,
        double dtOutput, double[] LowerBounds = null, double[] UpperBounds = null) {
            #region Check Inputs
            if (InitialValues == null) throw new ArgumentNullException("initialValues may not be null!");
            if (tEnd < t0) throw new ArgumentException("tend must be greater than t0.");
            if (deltaT < 0) throw new ArgumentException("dt must be a positive (and small) value.");
            if (dtOutput < 0) throw new ArgumentException("dtOutput must be a positive value");
            if (equations == null) throw new ArgumentNullException("equations may not be null!");
            //test ode System
            double[] test = equations(InitialValues, t0);
            if (test == null) throw new ArgumentException("The equation system may not return a null array");
            if (test.Length != InitialValues.Length)
                throw new ArgumentException($"The equation system returned {test.Length} values, but {InitialValues.Length} were expected.");
            #endregion

            #region Initialize
            //Array of process variables of ode System
            double[] x = new double[InitialValues.Length];
            Array.Copy(InitialValues, x, x.Length);
            //Create output list
            List<double[]> OutputList = new List<double[]>();

            //Output time
            double tOutput = t0;

            //initialize help gradients
            double[] k1 = new double[x.Length];
            double[] k2 = new double[x.Length];
            double[] k3 = new double[x.Length];
            double[] k4 = new double[x.Length];
            
            #endregion
            //Iteration
            #region Runge Kutta 4
            bool Stop = false;
            for (double t = t0; t <= tEnd + dtOutput/2; t += deltaT) {
                if (t >= tOutput) {
                    //Output time reached: create copy of x and add to list
                    double[] xOut = new double[x.Length + 1];
                    xOut[0] = t;
                    Array.Copy(x, 0, xOut, 1, x.Length);
                    OutputList.Add(xOut);
                    tOutput += dtOutput;
                }
                // get derivatives
                double[] dxdt = equations(x, t);
                //Runge Kutta 4 Algorithm
                for (int i = 0; i < x.Length; i++) {
                    k1[i] = deltaT * dxdt[i];
                    k2[i] = deltaT * (dxdt[i] + 0.5 * k1[i]);
                    k3[i] = deltaT * (dxdt[i] + 0.5 * k2[i]);
                    k4[i] = deltaT * (dxdt[i] + k3[i]);
                    x[i] += (1.0 / 6.0) * (k1[i] + 2 * k2[i] + 2 * k3[i] + k4[i]);
                }
                // check additional stopping criteria (upper/lower bounds for the process variables)
                if (LowerBounds != null) {
                    for (int i = 0; i < x.Length; i++) {
                        if (x[i] < LowerBounds[i]) { Stop = true; break; }
                    }
                }
                if (UpperBounds != null) {
                    for (int i = 0; i < x.Length; i++) {
                        if (x[i] > UpperBounds[i]) { Stop = true; break; }
                    }
                }
                if (Stop) break;
            }
            #endregion
            return OutputList;
        }
    } // end class
} //end namespace

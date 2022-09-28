using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PVA_Project {
    public class BioprocessModel {

        private double cS1;
        private double cS2;
        private double cX;      
        private double mueMax1;
        private double mueMax2;
        private double kS1;
        private double kS2;
        private double yXS1;
        private double yXS2;
        private double t0;
        private double deltaT;
        private double deltaTa;
        private double tEnd;

        /// <summary>
        /// Constructor for the bioprocess model.
        /// </summary>
        /// <param name="cS1">c substrate 1</param>
        /// <param name="cS2">c substrate 2</param>
        /// <param name="cX"> c product</param>
        /// <param name="mueMax1">max growtth rate 1</param>
        /// <param name="mueMax2">max growth rate 2</param>
        /// <param name="kS1"></param>
        /// <param name="kS2"></param>
        /// <param name="yXS1"></param>
        /// <param name="yXS2"></param>
        /// <param name="t0">(optional) Start time</param>
        /// <param name="deltaT">(optional) Stepsize for numerical solver </param>
        /// <param name="deltaTa">(optional)Output times for numerical solver </param>
        public BioprocessModel(double cS1, double cS2, double cX, double mueMax1, double mueMax2, double kS1, double kS2, double yXS1, double yXS2, double t0 = 0, double deltaT = 0.01, double deltaTa = 2.5, double tEnd = 40) {
            this.cS1 = cS1;
            this.cS2 = cS2;
            this.cX = cX;
            this.mueMax1 = mueMax1;
            this.mueMax2 = mueMax2;
            this.kS1 = kS1;
            this.kS2 = kS2;
            this.yXS1 = yXS1;
            this.yXS2 = yXS2;
            this.t0 = t0;
            this.deltaT = deltaT;
            this.deltaTa = deltaTa;
            this.tEnd = tEnd;
        }


        /// <summary>
        /// Differential Equation System that models the bioprocess
        /// </summary>
        /// <param name="x">double with process parameters</param>
        /// <param name="t">time if needed</param>
        /// <returns></returns>
        private double[] ODESystem(double[] x, double t) {
            double[] dxdt = new double[3];
            ///  CS1 = 0, CS2 = 1, CX = 2,
            double mue1 = mueMax1 * x[0] / (kS1 + x[0]);
            double mue2 = mueMax2 * x[1] / (kS2 + x[1]);
            dxdt[0] = -(mue1 * x[2]) / yXS1;
            dxdt[1] = -(mue2 * x[2]) / yXS2;
            dxdt[2] = (mue1 + mue2) * x[2];
            return dxdt;
        }

        /// <summary>
        /// Runs the bioprocess
        /// </summary>
        /// <returns>List with double[3] containing cS1, cS2, cX </returns>
        public List<double[]> Run() {
            double[] initialValues = { cS1, cS2, cX};
            return ODESolver.RungeKutta4(initialValues, t0, tEnd, deltaT, ODESystem, deltaTa);
        }

    } // end class
} //end namespace

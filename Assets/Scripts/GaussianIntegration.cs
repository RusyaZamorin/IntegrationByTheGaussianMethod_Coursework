using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.Functions;
using System;

namespace Application
{
    public static class GaussianIntegration
    {
        public static double Execute(int n, Function f, float a, float b)
        {
            double p = (b - a) / 2;
            double q = (b + a) / 2;            
                        
            double result = 0f;
            for (int i = 1; i <= n; i++)
            {
                double ai = A(i, n);
                double xi = LegendrePolynomials.X(i, n, n);
                result += ai * f.Execute(p * xi + q);
            }
            return p * result;
        }

        private static double A(int i, int n)
        {
            double xi = LegendrePolynomials.X(i, n, n);
            double xipow2 = xi * xi;

            double Pderiv = LegendrePolynomials.PDerivative(xi, n);

            return 2f / ((1f - xipow2) * (Pderiv * Pderiv));
        }

        public static class LegendrePolynomials
        {
            // recurrent formula
            public static double P(double x, int n)
            {
                if (n == 0)
                    return 1f;

                if (n == 1)
                    return x;

                double calc1 = 2f * (n - 1f) + 1f;
                double calc2 = calc1 / (double)n;
                double calc3 = calc2 * x * P(x, n - 1);

                double calc4 = ((double)n - 1f) / (double)n;
                double calc5 = calc4 * P(x, n - 2);

                double result = calc3 - calc5;

                return result;
            }

            public static double PDerivative(double x, int n)
            {
                double calc1 = (double)n / (1f - x * x);
                double calc2 = P(x, n - 1) - x * P(x,n);

                return calc1 * calc2; ;
            }

            public static double X(int i, int k, int n)
            {
                if (k == 0)
                {
                    return Math.Cos((Mathf.PI * (4f * i - 1f)) / (4f * n + 2f));
                }

                double xk = X(i, k - 1, n);

                double result = xk - (P(xk, n) / PDerivative(xk, n));

                return result;
            }
        }
    }
}


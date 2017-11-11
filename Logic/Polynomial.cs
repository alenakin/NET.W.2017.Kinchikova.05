using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Class for working with polynomials
    /// </summary>
    public sealed class Polynomial
    {
        #region Fields
        private static double epsilon;
        #endregion

        #region Properties
        /// <summary>
        /// Coefficients of polynomial in the form: a0, a1, ... an
        /// </summary>
        public double[] Coefficients { get; private set; } = { 0 };

        /// <summary>
        /// Polynomial degree
        /// </summary>
        public int Degree { get { return Coefficients.Length - 1; } }
        #endregion

        #region Methods

        #region Public methods

        #region Constructors
        static Polynomial()
        {
            try
            {
                epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"]);
            }
            catch (Exception)
            {
                epsilon = 0.00001;
            }
        }

        /// <summary>
        /// Constructor for class Polynomial
        /// </summary>
        /// <param name="coefficients">Coefficients of polynomial (a0, a1, ... an)</param>
        public Polynomial(params double[] coefficients)
        {
            if (coefficients.Length != 0)
                Coefficients = CutTheTail(coefficients);
        }
        #endregion

        #region Arithmetical methods
        /// <summary>
        /// Adds two specified Polynomial.
        /// </summary>
        /// <param name="lhs">The first value to add.</param>
        /// <param name="rhs">The second value to add.</param>
        /// <exception cref="ArgumentNullException">lhs or rhs is null</exception>
        /// <returns>The sum of lhs and rhs.</returns>
        public static Polynomial Add(Polynomial lhs, Polynomial rhs)
        {
            return AddSub(lhs, rhs);
        }

        /// <summary>
        /// Subtracts one specified Polynomial from another.
        /// </summary>
        /// <param name="lhs">The minuend.</param>
        /// <param name="rhs">The subtrahend.</param>
        /// <exception cref="ArgumentNullException">lhs or rhs is null</exception>
        /// <returns>The result of subtracting lhs from rhs.</returns>
        public static Polynomial Subtract(Polynomial lhs, Polynomial rhs)
        {
            return AddSub(lhs, -rhs);
        }

        /// <summary>
        /// Multiplies two specified Polynomial values.
        /// </summary>
        /// <param name="lhs">The multiplicand.</param>
        /// <param name="rhs">The multiplier.</param>
        /// <exception cref="ArgumentNullException">lhs or rhs is null</exception>
        /// <returns>The result of multiplying lhs and rhs.</returns>
        public static Polynomial Multiply(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            double[] newCoefficients = new double[lhs.Degree + rhs.Degree + 1];

            for (int i = 0; i < lhs.Coefficients.Length; i++)
                for (int j = 0; j < rhs.Coefficients.Length; j++)
                    newCoefficients[i + j] += lhs[i] * rhs[j];

            return new Polynomial(CutTheTail(newCoefficients));
        }

        /// <summary>
        /// Multiplies specified Polynomial and double values.
        /// </summary>
        /// <param name="p">The multiplicand.</param>
        /// <param name="value">The multiplier.</param>
        /// <exception cref="ArgumentNullException">p is null</exception>
        /// <returns>The result of multiplying p and value.</returns>
        public static Polynomial Multiply(Polynomial p, double value)
        {
            if (ReferenceEquals(p, null))
                throw new ArgumentNullException();

            var coefficients = new double[p.Coefficients.Length];
            Array.Copy(p.Coefficients, coefficients, p.Coefficients.Length);
            for (int i = 0; i < coefficients.Length; i++)
                coefficients[i] *= value;
            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Returns the result of multiplying the specified Polynomial value by negative one.
        /// </summary>
        /// <param name="p">The value to negate.</param>
        /// <exception cref="ArgumentNullException">p is null</exception>
        /// <returns>A Polynomial with the coefficients of the opposite sign.</returns>
        public static Polynomial Negate(Polynomial p)
        {
            return Multiply(p, -1);
        }
        #endregion

        #region Operators

        /// <summary>
        /// Returns the result of multiplying the specified Polynomial value by negative one.
        /// </summary>
        /// <param name="p">The value to negate.</param>
        /// <exception cref="ArgumentNullException">p is null</exception>
        /// <returns>A Polynomial with the coefficients of the opposite sign.</returns>
        public static Polynomial operator -(Polynomial p)
        {
            return Negate(p);
        }

        /// <summary>
        /// Adds two specified Polynomial.
        /// </summary>
        /// <param name="lhs">The first value to add.</param>
        /// <param name="rhs">The second value to add.</param>
        /// <exception cref="ArgumentNullException">lhs or rhs is null</exception>
        /// <returns>The sum of lhs and rhs.</returns>
        public static Polynomial operator +(Polynomial lhs, Polynomial rhs)
        {
            return AddSub(lhs, rhs);
        }

        /// <summary>
        /// Subtracts one specified Polynomial from another.
        /// </summary>
        /// <param name="lhs">The minuend.</param>
        /// <param name="rhs">The subtrahend.</param>
        /// <exception cref="ArgumentNullException">lhs or rhs is null</exception>
        /// <returns>The result of subtracting lhs from rhs.</returns>
        public static Polynomial operator -(Polynomial lhs, Polynomial rhs)
        {
            return AddSub(lhs, -rhs);
        }

        /// <summary>
        /// Multiplies two specified Polynomial values.
        /// </summary>
        /// <param name="lhs">The multiplicand.</param>
        /// <param name="rhs">The multiplier.</param>
        /// <exception cref="ArgumentNullException">lhs or rhs is null</exception>
        /// <returns>The result of multiplying lhs and rhs.</returns>
        public static Polynomial operator *(Polynomial lhs, Polynomial rhs)
        {
            return Multiply(lhs, rhs);
        }

        /// <summary>
        /// Multiplies specified Polynomial and double values.
        /// </summary>
        /// <param name="p">The multiplicand.</param>
        /// <param name="value">The multiplier.</param>
        /// <exception cref="ArgumentNullException">p is null</exception>
        /// <returns>The result of multiplying p and value.</returns>
        public static Polynomial operator *(Polynomial p, double value)
        {
            return Multiply(p, value);
        }

        /// <summary>
        /// Multiplies specified Polynomial and double values.
        /// </summary>
        /// <param name="value">The multiplicand.</param>
        /// <param name="p">The multiplier.</param>
        /// <exception cref="ArgumentNullException">p is null</exception>
        /// <returns>The result of multiplying p and value.</returns>
        public static Polynomial operator *(double value, Polynomial p)
        {
            return Multiply(p, value);
        }

        /// <summary>
        /// Returns a value indicating whether two specified instances of Polynomial represent the same value.
        /// </summary>
        /// <param name="lhs">The first value to compare.</param>
        /// <param name="rhs">The second value to compare.</param>
        /// <returns>true if lhs and rhs are equal; otherwise, false.</returns>
        public static bool operator ==(Polynomial lhs, Polynomial rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Returns a value indicating whether two specified instances of Polynomial represent different values.
        /// </summary>
        /// <param name="lhs">The first value to compare.</param>
        /// <param name="rhs">The second value to compare.</param>
        /// <returns>true if lhs and rhs are not equal; otherwise, false.</returns>
        public static bool operator !=(Polynomial lhs, Polynomial rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <summary>
        /// Gets the coefficient at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the coefficient to get.</param>
        /// <returns>The coefficient at the specified index.</returns>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Coefficients.Length)
                    throw new ArgumentOutOfRangeException();
                return Coefficients[index];
            }
            private set
            {
                if (index < 0 || index >= Coefficients.Length)
                    throw new ArgumentOutOfRangeException();
                Coefficients[index] = value;
            }
        }

        #endregion

        #region Overrided methods
        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            foreach(double i in Coefficients)
                result = 37 * result + (int)i;
            return result;
        }

        /// <summary>
        /// Returns a value indicating whether this instance and a specified Polynomial object represent the same value.
        /// </summary>
        /// <param name="value">An object to compare to this instance.</param>
        /// <returns>true if value is equal to this instance; otherwise, false.</returns>
        public bool Equals(Polynomial value)
        {
            if (ReferenceEquals(value, null))
                return false;
            if (ReferenceEquals(this, value))
                return true;

            return Coefficients.SequenceEqual(value.Coefficients);
        }

        /// <summary>
        /// Returns a value indicating whether this instance and a specified Object represent the same type and value.
        /// </summary>
        /// <param name="value">The object to compare with this instance.</param>
        /// <returns>true if value is a Polynomial and equal to this instance; otherwise, false.</returns>
        public override bool Equals(object value)
        {
            if (ReferenceEquals(value, null))
                return false;
            if (ReferenceEquals(this, value))
                return true;
            if (!(value is Polynomial))
                return false;
    
            Polynomial p = (Polynomial)value;
            return p.Equals(value);
        }

        /// <summary>
        /// Converts this instance to its equivalent string representation.
        /// </summary>
        /// <returns>A string that represents the value of this instance.</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder("");
            if (Coefficients[0] != 0)
                result.Append(Coefficients[0]);
            for (int i = 1; i < Coefficients.Length; i++)
            {
                if (Coefficients[i] != 0)
                {
                    if (Coefficients[i] > 0)
                        result.Append("+");
                    result.Append(Coefficients[i] + "*x^" + i);
                }                    
            }
            return result.ToString();
        }
        #endregion 
        #endregion

        #region Private methods
        private static Polynomial AddSub(Polynomial lhs, Polynomial rhs)
        {
            if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
                throw new ArgumentNullException();

            double[] newCoefficients = new double[Math.Max(lhs.Degree, rhs.Degree) + 1];
            int i = 0;
            for (; i <= lhs.Degree && i <= rhs.Degree; i++)
                newCoefficients[i] += lhs[i] + rhs[i];

            while (i <= lhs.Degree)
            {
                newCoefficients[i] += lhs[i];
                i++;
            }
            while (i <= rhs.Degree)
            {
                newCoefficients[i] += rhs[i];
                i++;
            }
            
            double[] cuttedCoefficients = CutTheTail(newCoefficients);
            return new Polynomial(cuttedCoefficients);
        }

        private static void Show(double[] coef)
        {
            foreach (double c in coef)
                Console.Write(c + " ");
            Console.WriteLine();
        }

        private static double[] CutTheTail(double[] coefficients)
        {
            int i = 0, j = coefficients.Length - 1;
            //while (coefficients[i] < epsilon)
            //    i++;
            while (Math.Abs(coefficients[j]) < epsilon && j >= 0)
                j--;
            double[] newCoefficients = new double[j - i + 1];
            Array.Copy(coefficients, i, newCoefficients, 0, j - i + 1);
            return newCoefficients;
        }
        #endregion 
        #endregion
    }
}

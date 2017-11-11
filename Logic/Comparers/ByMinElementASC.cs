using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Comparers
{
    /// <summary>
    /// Comparer for comparing arrays on the min element.
    /// </summary>
    public class ByMinElementASC : IComparer<int[]>
    {
        /// <summary>
        /// Compares arrays on min element in the direct order.
        /// </summary>
        /// <param name="x">The first array to compare.</param>
        /// <param name="y">The second array to compare.</param>
        /// <returns>-1: x is less than y; 0: x equals y; 1: x is greater than y.</returns>
        public int Compare(int[] x, int[] y)
        {
            return x.Min().CompareTo(y.Min());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Comparers
{
    /// <summary>
    /// Comparer for comparing arrays on the max element.
    /// </summary>
    public class ByMaxElementDESC : IComparer<int[]>
    {
        /// <summary>
        /// Compares arrays on max element in the reverse order.
        /// </summary>
        /// <param name="x">The first array to compare.</param>
        /// <param name="y">The second array to compare.</param>
        /// <returns>-1: x is greater than y; 0: x equals y; 1: x is less than y.</returns>
        public int Compare(int[] x, int[] y)
        {
            return -x.Max().CompareTo(y.Max());
        }
    }
}

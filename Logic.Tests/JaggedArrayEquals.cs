using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    public static class JaggedArrayEquals
    {
        /// <summary>
        /// Extension method for int[][] to determine whether two arrays are equal
        /// </summary>
        /// <param name="rhs">Array to compare</param>
        /// <returns>true if two arrays are equal; otherwise, false</returns>
        public static bool EqualTo(this int[][] lhs, int[][] rhs)
        {
            if (lhs == null || rhs == null)
                return false;
            if (lhs == rhs)
                return true;
            if (lhs.Length != rhs.Length)
                return false;

            for (int i = 0; i < lhs.Length; i++)
            {
                if (lhs[i] == rhs[i])
                    continue;
                if (lhs[i] == null || rhs[i] == null)
                    return false;
                if (lhs[i].Length != rhs[i].Length)
                    return false;
                for (int j = 0; j < lhs[i].Length; j++)
                    if (lhs[i][j] != rhs[i][j])
                        return false;
            }
            return true;
        }
    }
}

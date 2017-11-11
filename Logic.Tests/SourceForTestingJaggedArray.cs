using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    class SourceForTestingJaggedArray
    {
        #region Testing arrays
        static int[][] s1 =
        {
            new int[] {1, 3, 5, 7, 9},
            new int[] {25, 2, 4, 6},
            new int[] {11, 22}
        };

        static int[][] s2 =
        {
            new int[] {-2, 3, -5, 0, 9},
            new int[] {-1, 10, -10, 1},
            new int[] {20},
            new int[] {-20}
        };

        static int[][] s3 =
        {
            new int[] {1, 3, 5, 7, 9},
            new int[] {25, 2, 4, 6},
            null,
            new int[] {11, 22}
        };
        #endregion

        #region Expected results for testing arrays
        static int[][] s1SumASC =
        {
            new int[] {1, 3, 5, 7, 9},
            new int[] {11, 22},
            new int[] {25, 2, 4, 6},
        };

        static int[][] s1MaxASC =
        {
            new int[] {1, 3, 5, 7, 9},
            new int[] {11, 22},
            new int[] {25, 2, 4, 6},
        };

        static int[][] s1MinASC =
        {
            new int[] {1, 3, 5, 7, 9},
            new int[] {25, 2, 4, 6},
            new int[] {11, 22},
        };

        static int[][] s1SumDESC = Reverse(s1SumASC), s1MaxDESC = Reverse(s1MaxASC),
           s1MinDESC = Reverse(s1MinASC);

        static int[][] s2SumASC =
        {
            new int[] {-20},
            new int[] {-1, 10, -10, 1},
            new int[] {-2, 3, -5, 0, 9},
            new int[] {20},
        };

        static int[][] s2MaxASC =
        {
            new int[] {-20},
            new int[] {-2, 3, -5, 0, 9},
            new int[] {-1, 10, -10, 1},
            new int[] {20},
        };

        static int[][] s2MinASC =
        {
            new int[] {-20},
            new int[] {-1, 10, -10, 1},
            new int[] {-2, 3, -5, 0, 9},
            new int[] {20},
        };

        static int[][] s2SumDESC = Reverse(s2SumASC), s2MaxDESC = Reverse(s2MaxASC),
            s2MinDESC = Reverse(s2MinASC);

        static int[][] s3SumASC =
        {
            null,
            new int[] {1, 3, 5, 7, 9},
            new int[] {11, 22},
            new int[] {25, 2, 4, 6},
        };

        #endregion

        #region Cases
        static object[] SumASCCases =
        {
            new object[] { s1, s1SumASC },
            new object[] { s2, s2SumASC}
        };

        static object[] SumDESCCases =
        {
            new object[] { s1, s1SumDESC },
            new object[] { s2, s2SumDESC}
        };

        static object[] MaxASCCases =
        {
            new object[] { s1, s1MaxASC },
            new object[] { s2, s2MaxASC}
        };

        static object[] MaxDESCCases =
        {
            new object[] { s1, s1MaxDESC },
            new object[] { s2, s2MaxDESC}
        };

        static object[] MinASCCases =
        {
            new object[] { s1, s1MinASC },
            new object[] { s2, s2MinASC}
        };

        static object[] MinDESCCases =
        {
            new object[] { s1, s1MinDESC },
            new object[] { s2, s2MinDESC}
        };

        static object[] NullCases =
        {
            new object[] { s3, s3SumASC}
        };

        #endregion

        #region Help method
        private static int[][] Reverse(int[][] array)
        {
            int[][] result = new int[array.Length][];
            for (int i = array.Length - 1, j = 0; i >= 0; i--, j++)
                result[j] = array[i];
            return result;
        }
        #endregion
    }
}

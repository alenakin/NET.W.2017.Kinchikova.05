using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Logic.Comparers;

namespace Logic.Tests
{
    [TestFixture]
    public class JaggedArraySortTests
    {
        [TestCaseSource(typeof(SourceForTestingJaggedArray), "SumASCCases")]
        public void BubbleSort_ComparerBySumASC_EqualToResult(int[][] array, int[][] result)
        {
            JaggedArraySort.BubbleSort(array, new BySumElementsASC());
            Assert.True(array.EqualTo(result));
        }

        [TestCaseSource(typeof(SourceForTestingJaggedArray), "SumDESCCases")]
        public void BubbleSort_ComparerBySumDESC_EqualToResult(int[][] array, int[][] result)
        {
            JaggedArraySort.BubbleSort(array, new BySumElementsDESC());
            Assert.True(array.EqualTo(result));
        }

        [TestCaseSource(typeof(SourceForTestingJaggedArray), "MinASCCases")]
        public void BubbleSort_ComparerByMinASC_EqualToResult(int[][] array, int[][] result)
        {
            JaggedArraySort.BubbleSort(array, new ByMinElementASC());
            Assert.True(array.EqualTo(result));
        }

        [TestCaseSource(typeof(SourceForTestingJaggedArray), "MinDESCCases")]
        public void BubbleSort_ComparerByMinDESC_EqualToResult(int[][] array, int[][] result)
        {
            JaggedArraySort.BubbleSort(array, new ByMinElementDESC());
            Assert.True(array.EqualTo(result));
        }

        [TestCaseSource(typeof(SourceForTestingJaggedArray), "MaxASCCases")]
        public void BubbleSort_ComparerByMaxASC_EqualToResult(int[][] array, int[][] result)
        {
            JaggedArraySort.BubbleSort(array, new ByMaxElementASC());
            Assert.True(array.EqualTo(result));
        }

        [TestCaseSource(typeof(SourceForTestingJaggedArray), "MaxDESCCases")]
        public void BubbleSort_ComparerByMaxDESC_EqualToResult(int[][] array, int[][] result)
        {
            JaggedArraySort.BubbleSort(array, new ByMaxElementDESC());
            Assert.True(array.EqualTo(result));
        }

        [TestCaseSource(typeof(SourceForTestingJaggedArray), "NullCases")]
        public void BubbleSort_JaggedArrayWithNullArray_EqualToResult(int[][] array, int[][] result)
        {
            JaggedArraySort.BubbleSort(array, new BySumElementsASC());
            Assert.True(array.EqualTo(result));
            array.Equals(result);
        }
        
        [Test]
        public void BubbleSort_NullReferenceArray_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArraySort.BubbleSort(null, new ByMaxElementDESC()));
        }

        [Test]
        public void BubbleSort_NullReferenceComparer_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedArraySort.BubbleSort(new int[][] { }, null));
        }
    }
}

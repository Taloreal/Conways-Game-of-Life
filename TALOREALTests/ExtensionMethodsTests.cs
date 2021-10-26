using Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Utilities.Tests
{

    public class ExtensionMethodsTests
    {
        [Theory]
        [InlineData(new int[] { 1, 2, 3 }, -3, 3, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 1, 2, 3 }, -3, 2, new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 2, 3 }, -3, 1, new int[] { 1 })]
        [InlineData(new int[] { 1, 2, 3 }, 0, 0, new int[] { })]
        [InlineData(new int[] { 1, 2, 3 }, 0, 2, new int[] { 1, 2 })]
        [InlineData(new int[] { 1, 2, 3 }, 1, 2, new int[] { 2, 3 })]
        [InlineData(new int[] { 1, 2, 3 }, 2, 2, new int[] { 3 })]
        [InlineData(new int[] { 1, 2, 3 }, 3, 2, new int[] { })]
        [InlineData(new int[] { 1, 2, 3 }, 4, 0, new int[] { })]
        public void SubArrayTest(int[] arr, int start, int count, int[] expected)
        {
            int[] sub = arr.SubArray(start, count);
            if (sub.Length != expected.Length) { Assert.True(false); return; }
            for (int i = 0; i < sub.Length; i++) {
                if (sub[i] != expected[i]) { Assert.True(false); return; }
            }
            Assert.True(true);
        }
    }
}
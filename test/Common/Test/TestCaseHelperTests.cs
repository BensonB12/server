using Bit.Test.Common.Helpers;
using Xunit;

namespace Bit.Test.Common.Test;

public class TestCaseHelperTests
{
    public static IEnumerable<object[]> GetCombinationsData()
    {
        yield return new object[] { Array.Empty<int>(), new[] { Array.Empty<int>() } };
        yield return new object[] { new[] { 1 }, new[] { Array.Empty<int>(), new[] { 1 } } };
        yield return new object[] { new[] { 1, 2 }, new[] { Array.Empty<int>(), new[] { 2 }, new[] { 1 }, new[] { 1, 2 } } };
    }

    [Theory]
    [MemberData(nameof(GetCombinationsData))]
    public void GetCombinations(int[] input, int[][] expected)
    {
        Assert.Equal(expected, TestCaseHelper.GetCombinations(input).ToArray());
    }

    public static IEnumerable<object[]> GetCombinationsOfMultipleListsData()
    {
        yield return new object[] { new object[] { 1 }, new object[] { "1" }, new object[] { new object[] { 1, "1" } } };
        yield return new object[] { new object[] { 1 }, new object[] { "1", "2" }, new object[] { new object[] { 1, "1" }, new object[] { 1, "2" } } };
        yield return new object[] { new object[] { 1, 2 }, new object[] { "1" }, new object[] { new object[] { 1, "1" }, new object[] { 2, "1" } } };
        yield return new object[] { new object[] { 1, 2 }, new object[] { "1", "2" }, new object[] { new object[] { 1, "1" }, new object[] { 1, "2" }, new object[] { 2, "1" }, new object[] { 2, "2" } } };
    }

    [Theory]
    [MemberData(nameof(GetCombinationsOfMultipleListsData))]
    public void GetCombinationsOfMultipleLists(object[] list1, object[] list2, object[] expected)
    {
        Assert.Equal(expected, TestCaseHelper.GetCombinationsOfMultipleLists(list1, list2));
    }

}

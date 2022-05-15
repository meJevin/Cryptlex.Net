using Cryptlex.Net.Util;
using System;
using Xunit;

namespace Cryptlex.Net.Tests.Util
{
    public class UtilsTests
    {
        [Theory]
        [InlineData("path1", "path2", "path3")]
        [InlineData("path1", "path2")]
        [InlineData("path1")]
        public void CombinePaths_Produces_Correct_Results(params string[] strings)
        {
            // Arrange
            var expected = string.Join("/", strings);

            // Act
            var actual = Utils.CombinePaths(strings);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("uri", "queryStr")]
        [InlineData("uri", "")]
        [InlineData("uri", null)]
        public void AppendQueryString_Produces_Correct_Results(string uri, string queryStr)
        {
            // Arrange
            var expected = uri + (string.IsNullOrEmpty(queryStr) ? "" : "?" + queryStr);

            // Act
            var actual = Utils.AppendQueryString(uri, queryStr);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}

using Cryptlex.Net.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cryptlex.Net.Tests.Util
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ToQueryString_Ignores_Null_Fields()
        {
            // Arrange
            var obj = new { field1 = "value1", something = (string)null };

            var expected = "field1=value1";

            // Act
            var actual = obj.ToQueryString(true);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToQueryString_Preserves_Null_Fields()
        {
            // Arrange
            var obj = new { field1 = "value1", something = (string)null };

            var expected = "field1=value1&something=null";

            // Act
            var actual = obj.ToQueryString(false);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToQueryString_Escapes_Strings()
        {
            // Arrange
            var obj = new { field1 = "value1", something = "hello&" };

            var expected = "field1=value1&something=hello%26";

            // Act
            var actual = obj.ToQueryString();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToQueryString_Serializes_Arrays()
        {
            // Arrange
            var obj = new { arr = new[] { 1, 2, 3, 4 } };

            var expected = "arr=%5B1%2C2%2C3%2C4%5D";

            // Act
            var actual = obj.ToQueryString();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}

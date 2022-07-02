using Cryptlex.Net.Entities;
using Cryptlex.Net.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Cryptlex.Net.Tests.Util
{
    public class HttpContentExtensionsTests
    {
        [Fact]
        public async Task ReadCryptlexErrorAsync_Parses_Error()
        {
            // Arrange
            var expectedError = new Error() { Code = "123", Message = "some message" };
            var stringContent = new StringContent(JsonSerializer.Serialize(expectedError));

            // Act
            var actualError = await stringContent.ReadCryptlexErrorAsync();

            // Assert
            Assert.NotNull(actualError);
            Assert.Equal(expectedError.Message, actualError!.Message);
            Assert.Equal(expectedError.Code, actualError!.Code);
        }

        [Fact]
        public async Task ReadCryptlexErrorAsync_No_Error_Returns_Null()
        {
            // Arrange
            var stringContent = new StringContent("something");

            // Act
            var actualError = await stringContent.ReadCryptlexErrorAsync();

            // Assert
            Assert.Null(actualError);
        }
    }
}

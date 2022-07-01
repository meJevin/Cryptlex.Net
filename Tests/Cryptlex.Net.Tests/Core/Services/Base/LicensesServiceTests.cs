using Cryptlex.Net.Core;
using Cryptlex.Net.Core.Services;
using Cryptlex.Net.Licenses;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Cryptlex.Net.Tests.Core.Services.Base
{
    public class LicensesServiceTests
    {
        private const string AccessToken = "AccessToken";

        private class Mocks
        {
            public readonly Mock<IHttpClientFactory> HttpClientFactory = new();
            public readonly Mock<IOptions<CryptlexClientSettings>> CryptlexSettings = new();
            public readonly Mock<HttpMessageHandler> HttpMessageHandler = new();

            public Mocks()
            {
                var httpClient = new HttpClient(HttpMessageHandler.Object);
                HttpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

                CryptlexSettings.SetupGet(_ => _.Value).Returns(new CryptlexClientSettings { AccessToken = AccessToken });
            }
        }

        private readonly Mocks _mocks = new();
        private readonly LicensesService _licenseService;
        private readonly ITestOutputHelper _output;

        public LicensesServiceTests(ITestOutputHelper output)
        {
            _licenseService = new(_mocks.HttpClientFactory.Object, _mocks.CryptlexSettings.Object);
            _output = output;
        }

        [Fact]
        public async Task ListAsync_Includes_Page()
        {
            // Arrange
            var pageNumber = 10;

            _mocks.HttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync((HttpRequestMessage message, CancellationToken cancellationToken) =>
                {
                    _output.WriteLine(message.RequestUri!.AbsoluteUri);
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent("[]"),
                    };
                });

            // Act
            var answer = await _licenseService.ListAsync(new ListLicensesData { page = pageNumber });

            // Assert
            _mocks.HttpMessageHandler.Protected()
                .Verify<Task<HttpResponseMessage>>("SendAsync", Times.Once(), ItExpr.Is<HttpRequestMessage>(t1
                    => t1.Headers.Authorization!.Scheme == "Bearer"
                    && t1.Headers.Authorization!.Parameter == AccessToken
                    && t1.RequestUri!.Query == $"?page={pageNumber}"),
                    ItExpr.IsAny<CancellationToken>()
                );
        }
    }
}

using CryptlexDotNet.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleAppExample
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //var token = "YOUR TOKEN HERE";
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJhY2NvdW50OnJlYWQiLCJhY2NvdW50OndyaXRlIiwiYWN0aXZhd" +
                "GlvbjpyZWFkIiwiaW52b2ljZTpyZWFkIiwibGljZW5zZTpyZWFkIiwibGljZW5zZTp3cml0ZSIsInJlbGVhc2U6cmVhZCIsInJlbGVhc2U6d3J" +
                "pdGUiLCJ0cmlhbEFjdGl2YXRpb246cmVhZCIsInRyaWFsQWN0aXZhdGlvbjp3cml0ZSIsIndlYmhvb2s6cmVhZCIsIndlYmhvb2s6d3JpdGUiX" +
                "Swic3ViIjoiMmFhZTQ0ODAtNDM1Yy00YmZiLWIxN2YtNzAxNzBkOWI5MmE4IiwiZW1haWwiOiJtZWpldmluQGdtYWlsLmNvbSIsImp0aSI6ImN" +
                "iNjk5YzFiLTI4MWQtNDI0NC1iNzU3LTQ0YmI5MmRhY2Y2NCIsImlhdCI6MTYzNTUwNjEzOCwidG9rZW5fdXNhZ2UiOiJwZXJzb25hbF9hY2Nlc3" +
                "NfdG9rZW4iLCJ0ZW5hbnRpZCI6ImUyNDczYTM3LWQwN2QtNDc1ZS04ZTRiLTA4NDc1ZmIyNmQ5YiIsImV4cCI6MTY2OTg0MjAwMCwiYXVkIjoi" +
                "aHR0cHM6Ly9hcGkuY3J5cHRsZXguY29tIn0.ddW8Col9DryrYXpOewy4MNDn4x2ddewNAR8gaiHixMM6D7TFx9QzWab4I-ppd9p72H0ju_9YAZ" +
                "KNNfcISlCvT7PJ5SGWs01vhdMUWjquD4s2NgZzHAupQib8ylSBM3i-PhfDL36M9aqak9aZ47wBKrBHHqRqLhyYnL-KVV-RFPZpm67fj9yryWBX" +
                "v_TN1RElP5muOShqi2tWSh8CQX4xnbTs0Fcxgn7GzwHFlgYwOGlW5RG80UFzdwLD-7igYX9Dm917rMkNv10cS-RBgU7HzlkZDqAU7vFZ45ZLv1r" +
                "FdDNKf9yAYlyrhvZTiR_KP-cf6Wkl52YSCbeNY-Z4Zc8lWQ";

            try
            {
                var builder = Host.CreateDefaultBuilder(args)
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddCryptlexClient(a => a.AccessToken = token);

                        services.AddSingleton<HostedMain>();
                        services.AddHostedService(provider => provider.GetService<HostedMain>());
                    });

                await builder.RunConsoleAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
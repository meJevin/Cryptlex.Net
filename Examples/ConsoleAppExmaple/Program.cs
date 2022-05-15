using Cryptlex.Net.Util;
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
            var token = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY29wZSI6WyJhY2NvdW50OnJlYWQiLCJhY2NvdW50OndyaXRlIiwiYWN0aXZhdGlvbjpyZWFkIiwiYW5hbHl0aWNzOnJlYWQiLCJlbWFpbFRlbXBsYXRlOnJlYWQiLCJlbWFpbFRlbXBsYXRlOndyaXRlIiwiZXZlbnRMb2c6cmVhZ" +
                "CIsImZlYXR1cmVGbGFnOnJlYWQiLCJmZWF0dXJlRmxhZzp3cml0ZSIsImludm9pY2U6cmVhZCIsImxpY2Vuc2U6cmVhZCIsImxpY2Vuc2U6d3JpdGUiLCJsaWNlbnNlUG9saWN5OnJlYWQiLCJsaWNlbnNlUG9saWN5OndyaXRlIiwicGF5bWVudE1ldGhvZDpyZWFkIiwicGF5bWVudE1ldGhvZDp" +
                "3cml0ZSIsInBlcnNvbmFsQWNjZXNzVG9rZW46d3JpdGUiLCJwcm9kdWN0OnJlYWQiLCJwcm9kdWN0OndyaXRlIiwicHJvZHVjdFZlcnNpb246cmVhZCIsInByb2R1Y3RWZXJzaW9uOndyaXRlIiwicmVsZWFzZTpyZWFkIiwicmVsZWFzZTp3cml0ZSIsInJvbGU6cmVhZCIsInJvbGU6d3JpdGUiL" +
                "CJzZW5kaW5nRG9tYWluOnJlYWQiLCJzZW5kaW5nRG9tYWluOndyaXRlIiwidGFnOnJlYWQiLCJ0YWc6d3JpdGUiLCJ0cmlhbEFjdGl2YXRpb246cmVhZCIsInRyaWFsQWN0aXZhdGlvbjp3cml0ZSIsInRyaWFsUG9saWN5OnJlYWQiLCJ0cmlhbFBvbGljeTp3cml0ZSIsInVzZXI6cmVhZCIsInV" +
                "zZXI6d3JpdGUiLCJ3ZWJob29rOnJlYWQiLCJ3ZWJob29rOndyaXRlIl0sInN1YiI6IjJhYWU0NDgwLTQzNWMtNGJmYi1iMTdmLTcwMTcwZDliOTJhOCIsImVtYWlsIjoibWVqZXZpbkBnbWFpbC5jb20iLCJqdGkiOiJiZWI2ZDljMi1kNjg5LTQwZDMtOTczOC0wODA5MWE1YmE0MmEiLCJpYXQiOj" +
                "E2NTI1MDAzNDQsInRva2VuX3VzYWdlIjoicGVyc29uYWxfYWNjZXNzX3Rva2VuIiwidGVuYW50aWQiOiJlMjQ3M2EzNy1kMDdkLTQ3NWUtOGU0Yi0wODQ3NWZiMjZkOWIiLCJleHAiOjIwODU4NTgwMDAsImF1ZCI6Imh0dHBzOi8vYXBpLmNyeXB0bGV4LmNvbSJ9.IdKwrkgArdPxhOmPZJpBy-IQ" +
                "7FrAMPopO9CSzoKda96DpvO53aO5M-WDZwGcKPKuEUwb7PT1VqGgGIMlU-Ty4L-pmuOoy1VVa0ZfKehe-QTJYvyX7WnMAd96SBHXd2mV_uaZfY7ozV4l-j457E7z3BSgZpYKTJQC8HXNXWMt0tboAyL_cqzdXMAex7htRC9KiZ40lEWw8GDUQUlLAL8BZxUkTVqyb5jAwG5PlODYxbb8JNIlJdn7ge" +
                "AHQaBfVwEuvQeu1muWfnt-ZIOezB7przkkHzIKDaibPcDnAZUkBHy4uhJzEzWNH51PA4CFoXNR_2KXtEU-KJKQoGts_jzi6g";

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
                Console.WriteLine("\n\nCritical error!\n\n");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
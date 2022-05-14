# Cryptlex.Net

[![NuGet](https://img.shields.io/nuget/v/stripe.net.svg)](https://www.nuget.org/packages/Stripe.net/)
[![Build Status](https://ci.appveyor.com/api/projects/status/rg0pg5tlr1a6f8tf/branch/master?svg=true)](https://ci.appveyor.com/project/stripe/stripe-dotnet)
[![Coverage Status](https://coveralls.io/repos/github/stripe/stripe-dotnet/badge.svg?branch=master)](https://coveralls.io/github/stripe/stripe-dotnet?branch=master)

Cryptlex web API .NET Library written in .NET 6.0

## Installation

Using the [.NET Core command-line interface (CLI) tools][dotnet-core-cli-tools]:

```sh
dotnet add package Cryptlex.Net
```

Using the [NuGet Command Line Interface (CLI)][nuget-cli]:

```sh
nuget install Cryptlex.Net
```

Using the [Package Manager Console][package-manager-console]:

```powershell
Install-Package Cryptlex.Net
```

From within Visual Studio:

1. Open the Solution Explorer.
2. Right-click on a project within your solution.
3. Click on *Manage NuGet Packages...*
4. Click on the *Browse* tab and search for "Cryptlex.Net".
5. Click on the Cryptlex.Net package, select the appropriate version in the
   right-tab and click *Install*.

## Documentation

For a comprehensive list of examples, check out the provided [examples][usage-examples].

## Quickstart

### Prerequisites

In order to use this library, you need to obtain a [personal access token][cryptlex-personal-access-token] from cryptlex.

### Configuration

A call to `AddCryptlexClient` is used on `IServiceCollection` which configures the cryptlex client. 
Here you will be able to specify the access token you obtained earlier.

```c#
var token = "SOME TOKEN"
services.AddCryptlexClient(a => a.AccessToken = token);
```

### Usage

You inject the `ICryptlexClient` interface, wherever you need it. This interface contains all the possible
cryptlex entities you may be able to interact with.

Here's an example of how you may do so:

```c#
public class TestClass
{
    private readonly ICryptlexClient _cryptlexClient;

    public TestClass(ICryptlexClient cryptlexClient)
    {
        _cryptlexClient = cryptlexClient;
    }

    public async Task SomeMethod()
    {
		var data = new GetAllActivationsData() { page = 2 };
		
        await _cryptlexClient.Activations.GetAllAsync(data);
    }
}
```

[usage-examples]: https://github.com/meJevin/CryptlexDotNet/tree/main/Examples/
[dotnet-core-cli-tools]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[dotnet-format]: https://github.com/dotnet/format
[nuget-cli]: https://docs.microsoft.com/en-us/nuget/tools/nuget-exe-cli-reference
[package-manager-console]: https://docs.microsoft.com/en-us/nuget/tools/package-manager-console
[cryptlex-personal-access-token]: https://docs.cryptlex.com/web-integration/personal-access-tokens
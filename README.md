[![](https://img.shields.io/nuget/v/soenneker.sixtyfour.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sixtyfour.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sixtyfour.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.sixtyfour.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.sixtyfour.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.sixtyfour.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.sixtyfour.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.sixtyfour.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Sixtyfour.OpenApiClientUtil

Provides a lazily initialized Sixtyfour client for finding and reversing emails and phone numbers, enriching people and companies, running bulk jobs and workflows, and checking account balance.

## Installation

```bash
dotnet add package Soenneker.Sixtyfour.OpenApiClientUtil
```

## Configuration

```json
{
  "Sixtyfour": {
    "ApiKey": "your-sixtyfour-api-key"
  }
}
```

## Usage

```csharp
using Soenneker.Sixtyfour.OpenApiClientUtil.Abstract;
using Soenneker.Sixtyfour.OpenApiClientUtil.Registrars;

services.AddSixtyfourOpenApiClientUtilAsSingleton();

public sealed class SixtyfourBalanceReader
{
    private readonly ISixtyfourOpenApiClientUtil _sixtyfour;

    public SixtyfourBalanceReader(ISixtyfourOpenApiClientUtil sixtyfour)
    {
        _sixtyfour = sixtyfour;
    }

    public async Task GetBalance(CancellationToken cancellationToken)
    {
        var client = await _sixtyfour.Get(cancellationToken);
        var balance = await client.CheckBalance.GetAsync(
            cancellationToken: cancellationToken);
    }
}
```

Use `AddSixtyfourOpenApiClientUtilAsScoped()` when each scope should have its own generated client wrapper. Both registrations reuse the singleton authenticated HTTP client provider; disposing a scoped utility does not remove that provider's client.

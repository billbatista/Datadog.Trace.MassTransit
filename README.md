![Banner](Images/Banner.png)

# Datadog Trace MassTransit

[![GitHub Actions Status](https://github.com/billbatista/Datadog.Trace.MassTransit/workflows/Build/badge.svg?branch=main)](https://github.com/billbatista/Datadog.Trace.MassTransit/actions)

[![Datadog.Trace.MassTransit NuGet Package Downloads](https://img.shields.io/nuget/dt/Datadog.Trace.MassTransit)](https://www.nuget.org/packages/APM.Datadog.MassTransit)

[![GitHub Actions Build History](https://buildstats.info/github/chart/billbatista/Datadog.Trace.MassTransit?branch=main&includeBuildsFromPullRequest=false)](https://github.com/billbatista/Datadog.Trace.MassTransit/actions)


Adds MassTransit instrumentation to Datadog APM

## Usage

### Dependency injection

Add it to your MassTransit broker configuration with the `UseDatadogTracePropagationFilters()` extension method:

```c#
services.AddMassTransit(x =>
{
    x.UsingAzureServiceBus((context, cfg) =>
    {
        cfg.UseDatadogTracePropagationFilters();
    });
});
```

# Important ❗

This library is currently using the __Datadog.Tracer version 2.17.0__, so if you're doing automatic and custom instrumentation, make sure to have the same version of the [Datadog Tracer ](https://github.com/DataDog/dd-trace-dotnet/releases) binary installed on your system, as mentioned by the [documentation](https://docs.datadoghq.com/tracing/setup_overview/setup/dotnet-core/?tab=windows#custom-instrumentation). Speaking of the Datadog APM documentation, I recommend reading it fully to avoid any gotchas.

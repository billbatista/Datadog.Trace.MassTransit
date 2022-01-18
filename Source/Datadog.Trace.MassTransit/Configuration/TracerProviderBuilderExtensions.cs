using Datadog.Trace.MassTransit.Configuration;
using MassTransit;

// ReSharper disable once CheckNamespace
namespace Datadog.Trace.MassTransit
{
    /// <summary>
    /// Builder extensions.
    /// </summary>
    public static class TracerProviderBuilderExtensions
    {
        /// <summary>
        /// Adds the MassTransit's Datadog tracing filters.
        /// </summary>
        /// <param name="configurator"></param>
        public static void UseDatadogTracePropagationFilters(this IBusFactoryConfigurator configurator)
        {
            configurator.ConfigurePublish(cfg => cfg.AddPipeSpecification(new DatadogTracingPipeSpecification()));
            configurator.ConfigureSend(cfg => cfg.AddPipeSpecification(new DatadogTracingPipeSpecification()));
            configurator.AddPipeSpecification(new DatadogTracingPipeSpecification());
        }
    }
}

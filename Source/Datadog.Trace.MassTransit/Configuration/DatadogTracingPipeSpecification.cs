using Datadog.Trace.MassTransit.Filters;
using MassTransit;
using MassTransit.Configuration;

namespace Datadog.Trace.MassTransit.Configuration
{
    internal class DatadogTracingPipeSpecification : IPipeSpecification<ConsumeContext>, IPipeSpecification<PublishContext>,
        IPipeSpecification<SendContext>
    {
        public IEnumerable<ValidationResult> Validate()
        {
            return Enumerable.Empty<ValidationResult>();
        }

        public void Apply(IPipeBuilder<ConsumeContext> builder)
        {
            builder.AddFilter(new DatadogTraceConsumeFilter());
        }

        public void Apply(IPipeBuilder<PublishContext> builder)
        {
            builder.AddFilter(new DatadogTracePublishFilter());
        }

        public void Apply(IPipeBuilder<SendContext> builder)
        {
            builder.AddFilter(new DatadogTracePublishFilter());
        }
    }
}

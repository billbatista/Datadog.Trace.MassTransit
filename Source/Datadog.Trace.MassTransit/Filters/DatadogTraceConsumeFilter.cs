using MassTransit;

namespace Datadog.Trace.MassTransit.Filters
{
    internal class DatadogTraceConsumeFilter : IFilter<ConsumeContext>
    {
        public void Probe(ProbeContext context)
        {
            context.CreateFilterScope("datadog-trace");
        }

        public async Task Send(ConsumeContext context, IPipe<ConsumeContext> next)
        {
            ulong? parentSpanId = null;
            ulong? traceId = null;
            ISpanContext? propagatedContext = null;

            if (context.Headers.TryGetHeader(MassTransitMessageHeader.TraceId, out var traceString))
            {
                traceId = Convert.ToUInt64(traceString);
            }

            if (context.Headers.TryGetHeader(MassTransitMessageHeader.ParentSpanId, out var parentSpanIdString))
            {
                parentSpanId = Convert.ToUInt64(parentSpanIdString);
            }

            if (parentSpanId.HasValue && traceId.HasValue)
            {
                propagatedContext = new SpanContext(traceId, parentSpanId.Value);
            }

            var spanCreationSettings = new SpanCreationSettings
            {
                Parent = propagatedContext
            };
            using (var scope = Tracer.Instance.StartActive(MassTransitOperationName.Transport.Receive, spanCreationSettings))
            {
                DatadogTraceSpanHelper.SetSpanTags(context, scope);
                await next.Send(context);
            }
        }
    }
}

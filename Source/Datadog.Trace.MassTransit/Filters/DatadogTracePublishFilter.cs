using MassTransit;

namespace Datadog.Trace.MassTransit.Filters
{
    internal class DatadogTracePublishFilter : IFilter<PublishContext>, IFilter<SendContext>
    {
        public void Probe(ProbeContext context)
        {
            context.CreateFilterScope("datadog-trace");
        }

        public async Task Send(PublishContext context, IPipe<PublishContext> next)
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
                propagatedContext = new SpanContext(traceId.Value, parentSpanId.Value);
            }

            var spanCreationSettings = new SpanCreationSettings
            {
                Parent = propagatedContext
            };
            using (var scope = Tracer.Instance.StartActive(MassTransitOperationName.Transport.Send, spanCreationSettings))
            {
                if (propagatedContext == null)
                {
                    traceId = scope.Span.TraceId;
                    parentSpanId = scope.Span.SpanId;
                }

                DatadogTraceSpanHelper.SetSpanTags(context, scope);
                MassTransitMessageHeaderHelper.SetHeaders(context, parentSpanId, traceId);

                await next.Send(context);
            }
        }

        public async Task Send(SendContext context, IPipe<SendContext> next)
        {
            ulong? parentSpanId = null;
            ulong? traceId = null;
            ISpanContext? propagatedContext = null;

            if (context.Headers.TryGetHeader(MassTransitMessageHeader.TraceId, out var traceString))
            {
                traceId = Convert.ToUInt64(traceString);
            }

            if (context.Headers.TryGetHeader(MassTransitMessageHeader.TraceId, out var parentSpanIdString))
            {
                parentSpanId = Convert.ToUInt64(parentSpanIdString);
            }

            if (parentSpanId.HasValue && traceId.HasValue)
            {
                propagatedContext = new SpanContext(traceId.Value, parentSpanId.Value);
            }

            var spanCreationSettings = new SpanCreationSettings
            {
                Parent = propagatedContext
            };
            using (var scope = Tracer.Instance.StartActive(MassTransitOperationName.Transport.Send, spanCreationSettings))
            {
                if (propagatedContext == null)
                {
                    traceId = scope.Span.TraceId;
                    parentSpanId = scope.Span.SpanId;
                }

                DatadogTraceSpanHelper.SetSpanTags(context, scope);
                MassTransitMessageHeaderHelper.SetHeaders(context, parentSpanId, traceId);

                await next.Send(context);
            }
        }
    }
}

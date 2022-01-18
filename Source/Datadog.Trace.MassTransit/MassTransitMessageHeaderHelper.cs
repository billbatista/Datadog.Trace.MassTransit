using MassTransit;

namespace Datadog.Trace.MassTransit
{
    internal static class MassTransitMessageHeaderHelper
    {
        internal static void SetHeaders(PublishContext context, ulong? parentSpanId, ulong? traceId)
        {
            context.Headers.Set(MassTransitMessageHeader.TraceId, traceId);
            context.Headers.Set(MassTransitMessageHeader.ParentSpanId, parentSpanId);
        }

        internal static void SetHeaders(SendContext context, ulong? parentSpanId, ulong? traceId)
        {
            context.Headers.Set(MassTransitMessageHeader.TraceId, traceId);
            context.Headers.Set(MassTransitMessageHeader.ParentSpanId, parentSpanId);
        }
    }
}

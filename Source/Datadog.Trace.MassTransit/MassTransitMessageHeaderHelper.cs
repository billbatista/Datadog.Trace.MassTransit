using MassTransit;

namespace Datadog.Trace.MassTransit
{
    internal static class MassTransitMessageHeaderHelper
    {
        internal static void SetHeaders(PublishContext context, ulong? parentSpanId, ulong? traceId)
        {
            if (traceId != null)
            {
                context.Headers.Set(MassTransitMessageHeader.TraceId, traceId.ToString());
            }

            if (parentSpanId != null)
            {
                context.Headers.Set(MassTransitMessageHeader.ParentSpanId, parentSpanId.ToString());
            }
        }

        internal static void SetHeaders(SendContext context, ulong? parentSpanId, ulong? traceId)
        {
            if (traceId != null)
            {
                context.Headers.Set(MassTransitMessageHeader.TraceId, traceId.ToString());
            }

            if (parentSpanId != null)
            {
                context.Headers.Set(MassTransitMessageHeader.ParentSpanId, parentSpanId.ToString());
            }
        }
    }
}

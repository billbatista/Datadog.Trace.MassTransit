namespace Datadog.Trace.MassTransit
{
    internal static class MassTransitMessageHeader
    {
        internal const string ParentSpanId = "x-datadog-parent-id";
        internal const string TraceId = "x-datadog-trace-id";
    }
}

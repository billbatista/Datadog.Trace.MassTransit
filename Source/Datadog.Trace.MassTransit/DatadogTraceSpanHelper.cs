using MassTransit;

namespace Datadog.Trace.MassTransit
{
    internal class DatadogTraceSpanHelper
    {
        private const string ServiceName = "MassTransit";

        internal static void SetSpanTags(MessageContext context, Scope scope)
        {
            scope.Span.SetTag(DatadogSpanTag.MessageId, context.MessageId.ToString());
            scope.Span.SetTag(DatadogSpanTag.DestinationHost, context.DestinationAddress.Host);
            scope.Span.SetTag(DatadogSpanTag.DestinationEndpoint, context.DestinationAddress.AbsolutePath);
            scope.Span.SetTag(DatadogSpanTag.MessageConversationId, context.ConversationId.ToString());
            scope.Span.ResourceName = context.DestinationAddress.AbsolutePath;
            scope.Span.ServiceName = ServiceName;
        }

        internal static void SetSpanTags(SendContext context, Scope scope)
        {
            scope.Span.SetTag(DatadogSpanTag.MessageId, context.MessageId.ToString());
            scope.Span.SetTag(DatadogSpanTag.DestinationHost, context.DestinationAddress.Host);
            scope.Span.SetTag(DatadogSpanTag.DestinationEndpoint, context.DestinationAddress.AbsolutePath);
            scope.Span.SetTag(DatadogSpanTag.MessageConversationId, context.ConversationId.ToString());
            scope.Span.ResourceName = context.DestinationAddress.AbsolutePath;
            scope.Span.ServiceName = ServiceName;
        }
    }
}

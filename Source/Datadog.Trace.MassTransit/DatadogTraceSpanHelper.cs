using MassTransit;

namespace Datadog.Trace.MassTransit
{
    internal class DatadogTraceSpanHelper
    {
        private const string ServiceName = "MassTransit";

        internal static void SetSpanTags(MessageContext context, IScope scope)
        {
            scope.Span.SetTag(DatadogSpanTag.MessageId, context.MessageId.ToString());
            scope.Span.SetTag(DatadogSpanTag.MessageConversationId, context.ConversationId.ToString());
            scope.Span.ServiceName = ServiceName;

            if (context.DestinationAddress != null)
            {
                scope.Span.SetTag(DatadogSpanTag.DestinationHost, context.DestinationAddress.Host);
                scope.Span.SetTag(DatadogSpanTag.DestinationEndpoint, context.DestinationAddress.AbsolutePath);
                scope.Span.ResourceName = context.DestinationAddress.AbsolutePath;
            }
        }

        internal static void SetSpanTags(SendContext context, IScope scope)
        {
            scope.Span.SetTag(DatadogSpanTag.MessageId, context.MessageId.ToString());
            scope.Span.SetTag(DatadogSpanTag.MessageConversationId, context.ConversationId.ToString());
            scope.Span.ServiceName = ServiceName;

            if (context.DestinationAddress != null)
            {
                scope.Span.SetTag(DatadogSpanTag.DestinationHost, context.DestinationAddress.Host);
                scope.Span.SetTag(DatadogSpanTag.DestinationEndpoint, context.DestinationAddress.AbsolutePath);
                scope.Span.ResourceName = context.DestinationAddress.AbsolutePath;
            }
        }
    }
}

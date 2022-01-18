namespace Datadog.Trace.MassTransit
{
    internal static class DatadogSpanTag
    {
        public const string MessageId = "Message.Id";
        public const string MessageConversationId = "Message.ConversationId";
        public const string DestinationHost = "Destination.Host";
        public const string DestinationEndpoint = "Destination.Endpoint";
    }
}

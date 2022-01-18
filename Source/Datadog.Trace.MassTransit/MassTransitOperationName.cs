namespace Datadog.Trace.MassTransit
{
    internal static class MassTransitOperationName
    {
        /// <summary>
        /// MassTransit Transport category constants.
        /// </summary>
        internal static class Transport
        {
            /// <summary>
            /// MassTransit send diagnostic source operation name.
            /// </summary>
            internal const string Send = "MassTransit.Transport.Send";

            /// <summary>
            /// MassTransit receive diagnostic source operation name.
            /// </summary>
            internal const string Receive = "MassTransit.Transport.Receive";
        }
    }
}

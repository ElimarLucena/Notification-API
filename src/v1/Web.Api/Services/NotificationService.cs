using Grpc.Core;

namespace Web.Api.Services
{
    public class NotificationService : Notification.NotificationBase
    {
        public override Task<SendMessageReply> SendMessage(SendMessageRequest request, ServerCallContext context)
        {
            string message = string.Empty;

            message = (object)request.MessageType switch
            {
                MessageType.Welcame => $"Welcome, {request.Name}!",
                MessageType.UpdateWarming => $"Always keep your data up to date, {request.Name}!",
                _ => "Please, specify the type of message you want to send.",
            };

            return Task.FromResult(new SendMessageReply
            {
                Message = message,
            });
        }
    }
}

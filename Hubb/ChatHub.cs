using Microsoft.AspNetCore.SignalR;
using System.Globalization;
namespace DevNet.Hubb
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            var id = Guid.NewGuid().ToString();
            await Clients.All.SendAsync(
                "ReceiveMessage",
                id,
                user,
                message);
        }
        public async Task SendComment(string messageId, string user, string comment)
        {
            await Clients.All.SendAsync(
                "ReceiveComment",
                messageId,
                user,
                comment);
        }
    }
}
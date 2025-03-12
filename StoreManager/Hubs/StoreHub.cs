using Microsoft.AspNetCore.SignalR;

namespace StoreManager.Hubs
{
    public class StoreHub : Hub
    {
        public async Task SendOrder(string message)
        {
            await Clients.All.SendAsync("ReceiveOrderUpdate", message);
        }
    }
}

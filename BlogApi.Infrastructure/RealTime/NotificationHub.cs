using Microsoft.AspNetCore.SignalR;

namespace BlogApi.Infrastructure.RealTime;

public class NotificationHub : Hub
{
    public override Task OnConnectedAsync()
    {
        Console.WriteLine($"Usuário conectado: {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public async Task JoinGroup(string groupName)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        await Clients.Group(groupName).SendAsync("SystemMessage", $"Entrou no grupo: {groupName}");
    }

    public async Task LeaveGroup(string groupName)
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        await Clients.Group(groupName).SendAsync("SystemMessage", $"Saiu do grupo: {groupName}");
    }

    public async Task SendPrivateMessage(string userId, string message)
    {
        await Clients.User(userId).SendAsync("PrivateMessage", message);
    }
}

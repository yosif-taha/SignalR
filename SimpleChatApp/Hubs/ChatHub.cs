using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Client;
using SimpleChatApp.Models;
using SimpleChatApp.Models.Data;
using System.Configuration;

namespace SimpleChatApp.Hubs
{
    public class ChatHub : Hub
    {
        ChatContext _dbContext;

        public ChatHub(ChatContext chatContext)
        {
            _dbContext = chatContext;
        }

        [HubMethodName("sendmessage")]
        public  async Task SendMessage(ChatMessage chatMessage)
        {
            // Save the message to the database (if needed)
            _dbContext.ChatMessages.Add(chatMessage);
            await _dbContext.SaveChangesAsync();

            // Broadcast(Push) the message to all connected clients
            await Clients.All.SendAsync("newmessage",chatMessage);
           
        }


        [HubMethodName("jointogroup")]
        public async Task JoinToGroup(string groupname, string name)
        {
            // add the current connection to a group
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
            // broadcast a message to all members of the group that a new user has joined
            await Clients.OthersInGroup(groupname).SendAsync("newmember", name, groupname);
        }

        [HubMethodName("sendmessagetogroup")]
        public async Task SendMessageToGroup(string name,string groupname, string message)
        {


            // Broadcast the message to all members of the specified group
            await Clients.Group(groupname).SendAsync("newmessagegroup", name, groupname, message);
        }


        public override Task OnConnectedAsync()
        {
           var conId =  Context.ConnectionId; // Unique identifier for the connection
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}

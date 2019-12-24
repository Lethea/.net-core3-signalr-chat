using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using SignalRTuts.Model;

namespace SignalRTuts.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IHubContext<ChatHub> _chat;
        static HashSet<User> Users = new HashSet<User>();

        public ChatHub(IDistributedCache distributedCache, IHubContext<ChatHub> chat)
        {
            _chat = chat;
            _distributedCache = distributedCache;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            User user = Users.FirstOrDefault(user => user.ConnectionId == Context.ConnectionId);

            Users.Remove(user);
            await _chat.Groups.RemoveFromGroupAsync(user.ConnectionId, user.Room);

            ResponseMessage response = new ResponseMessage();
            response.Data = user;
            response.Type = "user_left";

            await _chat.Clients.Group(user.Room).SendAsync("ReceiveMessage", response);
        }

        public async Task JoinToRoom(User user)
        {
            user.ConnectionId = Context.ConnectionId;
            if (!Users.Contains(user))
            {
                Users.Add(user);
            }

            await _chat.Groups.AddToGroupAsync(user.ConnectionId, user.Room);

            ResponseMessage response = new ResponseMessage();
            response.Data = user;
            response.Type = "new_user_login";

            await _chat.Clients.Group(user.Room).SendAsync("ReceiveMessage", response);
        }

        private User GetUserByConnectionId(string connectionId)
        {
            return Users.FirstOrDefault(u => u.ConnectionId == connectionId);
        }

        public async Task SendMessage(string message)
        {
            /*
             *Cache
             *
             */
            //var entry = Encoding.UTF8.GetBytes(message);

            //_distributedCache.Set("SIGNAL", entry);
            /*
             *
             *Cache
             */

            var fromUser = GetUserByConnectionId(Context.ConnectionId);

            var dict = new Dictionary<string, string>();
            dict["Name"] = fromUser.Name;
            dict["Message"] = message;

            ResponseMessage response = new ResponseMessage()
            {
                Type = "get_message",
                Data = dict
            };

            await _chat.Clients.Groups(fromUser.Room).SendAsync("ReceiveMessage", response);
        }


        public async Task GetRoomUsers()
        {
            User user = GetUserByConnectionId(Context.ConnectionId);

            var userList = Users.Where(u => u.Room == user.Room).ToList();
            ResponseMessage response = new ResponseMessage();
            response.Data = userList;
            response.Type = "user_list";

            await _chat.Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", response);
        }

    }
}
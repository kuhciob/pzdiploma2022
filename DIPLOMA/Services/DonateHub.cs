using DIPLOMA.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIPLOMA.Services
{
    public class DonateHub : Hub
    {
        protected string _userID = "";
        public async Task SendMessage(DonateMsg message)
        {
            //await Clients.Group()
            await Clients.User(message.UserID).SendAsync("ReceiveMessage", message);

            //await Clients.Client(connectionId).SendAsync("ReceiveMessage", message);
        }
        //public override Task OnConnectedAsync()
        //{
        //    string name = Context.
        //    Groups.AddToGroupAsync(Context.ConnectionId, name);

        //    return base.OnConnectedAsync();
        //}
        public string GetConnectionId() => Context.ConnectionId;

        public override async Task OnConnectedAsync()
        {
            this._userID = Context.GetHttpContext().Request.Query["userid"];
            this._userID = this._userID.Replace("\"", "");
            this._userID = this._userID.Replace("\'", "");

            await Groups.AddToGroupAsync(Context.ConnectionId, this._userID);
            await base.OnConnectedAsync();
        }
    }
}

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
        public async Task SendMessage(DonateMsg message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}

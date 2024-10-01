using Microsoft.AspNetCore.SignalR;
using TestWithValue.Application.Services.Services_Interface;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.Ticket;

namespace TestWithValue.Web.HubSupport
{
    public class SupportHub :Hub
    {
        private readonly ITicketService _ticketService;

        public SupportHub(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        public override async Task OnConnectedAsync()
        {
            var user = Context.User;
            if (user.IsInRole("Agent"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Agent");
            }
            else if (user.IsInRole("User"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "User");
            }
            await base.OnConnectedAsync();
        }
        public async Task SendMessageToAgent(string userId, string message)
        {
            var ticketViewModel = new TicketViewModel
            {
                Title = "New Ticket", // عنوان تیکت
                Description = message, // پیام کاربر به عنوان توضیحات تیکت
                Status = TicketStatus.Open // وضعیت تیکت به صورت باز
            };

            // ایجاد تیکت با استفاده از مدل و دریافت شناسه آن
            var ticketId = await _ticketService.CreateTicketAsync(ticketViewModel);

            // ارسال پیام به پشتیبان
            await Clients.Group("Agent").SendAsync("ReceiveMessageFromUser", userId, message);

            // ذخیره پیام در دیتابیس و بروزرسانی وضعیت تیکت
            await _ticketService.UpdateTicketStatusAsync(ticketId, TicketStatus.InProgress);
        }

        public async Task SendMessageToUser(string agentId, string userId, int ticketId, string message)
        {
            // ارسال پیام از پشتیبان به کاربر
            await Clients.User(userId).SendAsync("ReceiveMessageFromAgent", agentId, message);

            // ذخیره پیام در دیتابیس و بروزرسانی وضعیت تیکت
            await _ticketService.UpdateTicketStatusAsync(ticketId, TicketStatus.Resolved);
        }


        public async Task CloseTicket(int ticketId)
        {
            // بستن تیکت
          await  _ticketService.UpdateTicketStatusAsync(ticketId, TicketStatus.Closed);
            await Clients.All.SendAsync("TicketClosed", ticketId);
        }
    }
}

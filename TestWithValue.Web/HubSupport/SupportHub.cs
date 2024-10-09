using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
using TestWithValue.Application.Services.Services_Interface;
using TestWithValue.Domain.ViewModels.Ticket;

//namespace TestWithValue.Web.HubSupport
//{
//    public class SupportHub : Hub
//    {
//        private readonly ITicketService _ticketService;

//        public SupportHub(ITicketService ticketService)
//        {
//            _ticketService = ticketService;
//        }

//        public override async Task OnConnectedAsync()
//        {
//            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

//            // بررسی اینکه آیا کاربر یا پشتیبان است
//            if (Context.User.IsInRole("Agent"))
//            {
//                await Groups.AddToGroupAsync(Context.ConnectionId, "Agent");
//            }
//            else if (Context.User.IsInRole("User"))
//            {
//                await Groups.AddToGroupAsync(Context.ConnectionId, "User");

//                // دریافت ticketId برای کاربر
//                var ticket = await _ticketService.GetOpenTicketForUserAsync(userId);

//                if (ticket != null)
//                {
//                    // ارسال ticketId به کاربر
//                    await Clients.Caller.SendAsync("ReceiveTicketId", ticket.Id);
//                }
//                else
//                {
//                    // اگر تیکت وجود نداشت
//                    await Clients.Caller.SendAsync("ReceiveTicketId", null);
//                }
//            }

//            await base.OnConnectedAsync();
//        }

//        public async Task SendMessageToAgent(string userId, string message)
//        {
//            // بررسی اینکه آیا تیکتی برای این کاربر وجود دارد
//            var existingTicket = await _ticketService.GetOpenTicketForUserAsync(userId);

//            int ticketId;

//            if (existingTicket == null)
//            {
//                // اگر تیکت موجود نیست، تیکت جدید ایجاد کنیم
//                var newTicketModel = new TicketViewModel
//                {
//                    Title = "New Ticket from User " + userId,
//                    Description = "User has started a new conversation.",
//                    UserId = userId
//                };
//                await _ticketService.CreateTicketAsync(newTicketModel);
//                var ticket = await _ticketService.GetOpenTicketForUserAsync(userId);
//                ticketId = ticket.Id;
//            }
//            else
//            {
//                // اگر تیکت موجود است، از آن استفاده می‌کنیم
//                ticketId = existingTicket.Id;
//            }

//            // ذخیره پیام کاربر با استفاده از ticketId
//            await _ticketService.SaveMessageAsync(ticketId, userId, message);

//            // ارسال پیام به گروه پشتیبان‌ها
//            await Clients.Group("Agent").SendAsync("ReceiveMessageFromUser", userId, message, ticketId);
//        }

//        public async Task SendMessageToUser(string userId, int ticketId, string message)
//        {
//            var agentId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

//            if (agentId == null)
//            {
//                throw new HubException("پشتیبان احراز هویت نشده است.");
//            }

//            var ticket = await _ticketService.GetOpenTicketForUserAsync(userId);

//            if (ticket == null || ticket.UserId != userId)
//            {
//                throw new HubException("تیکت یافت نشد یا متعلق به کاربر نیست.");
//            }

//            await Clients.User(userId).SendAsync("ReceiveMessageFromAgent", agentId, message);
//            await _ticketService.SaveMessageAsync(ticketId, agentId, message);
//        }
//        public async Task JoinTicketGroup(int ticketId)
//        {
//            // پیوستن به گروه تیکت بر اساس ticketId
//            await Groups.AddToGroupAsync(Context.ConnectionId, ticketId.ToString());
//        }
//    }
//}
namespace TestWithValue.Web.HubSupport
{
    public class SupportHub : Hub
    {
        private readonly ITicketService _ticketService;

        public SupportHub(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // بررسی اینکه آیا کاربر یا پشتیبان است
            if (Context.User.IsInRole("Agent"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Agent");
            }
            else if (Context.User.IsInRole("User"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "User");

                // دریافت ticketId برای کاربر
                var ticket = await _ticketService.GetOpenTicketForUserAsync(userId);

                if (ticket != null)
                {
                    // ارسال ticketId به کاربر
                    await Clients.Caller.SendAsync("ReceiveTicketId", ticket.Id);
                    // اضافه کردن کاربر به گروه مربوط به ticketId
                    await Groups.AddToGroupAsync(Context.ConnectionId, ticket.Id.ToString());
                }
                else
                {
                    // اگر تیکت وجود نداشت
                    await Clients.Caller.SendAsync("ReceiveTicketId", null);
                }
            }

            await base.OnConnectedAsync();
        }

        public async Task SendMessageToAgent(string userId, string title, string message)
        {
            // بررسی اینکه آیا تیکتی برای این کاربر با این عنوان وجود دارد
            var existingTicket = await _ticketService.GetOpenTicketForUserByTitleAsync(userId, title);
            int ticketId;

            if (existingTicket == null)
            {
                // اگر تیکت موجود نیست، تیکت جدید ایجاد کنیم
                var newTicketModel = new TicketViewModel
                {
                    Title = title,
                    Description = "User has started a new conversation.",
                    UserId = userId
                };
                await _ticketService.CreateTicketAsync(newTicketModel);
                var ticket = await _ticketService.GetOpenTicketForUserByTitleAsync(userId, title);
                ticketId = ticket.Id;

                // اضافه کردن کاربر به گروه مربوط به ticketId
                await Groups.AddToGroupAsync(Context.ConnectionId, ticketId.ToString());
            }
            else
            {
                // اگر تیکت موجود است، از آن استفاده می‌کنیم
                ticketId = existingTicket.Id;
            }

            // ذخیره پیام کاربر با استفاده از ticketId
            await _ticketService.SaveMessageAsync(ticketId, userId, message);

            // ارسال پیام به گروه پشتیبان‌ها
            await Clients.Group("Agent").SendAsync("ReceiveMessageFromUser", userId, message, ticketId,title);
        }

        public async Task SendMessageToUser(string userId, string ticketId, string message, string ticketTitle)
        {
            var agentId = Context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (agentId == null)
            {
                throw new HubException("پشتیبان احراز هویت نشده است.");
            }

            var ticket = await _ticketService.GetOpenTicketForUserByTitleAsync(userId, ticketTitle);

            if (ticket == null || ticket.UserId != userId)
            {
                throw new HubException("تیکت یافت نشد یا متعلق به کاربر نیست.");
            }

            // ارسال پیام به گروه مربوط به ticketId
            await Clients.User(userId).SendAsync("ReceiveMessageFromAgent", agentId, message, ticketId);

            // ذخیره پیام در دیتابیس
            await _ticketService.SaveMessageAsync(Convert.ToInt32( ticketId), agentId, message);
        }

        [HttpGet]
        public async Task LoadMessagesForTicket(string ticketId)
        {
            var messages = await _ticketService.GetMessagesByTicketIdAsync(Convert.ToInt32( ticketId));
            await Clients.Caller.SendAsync("ReceiveMessages", messages, ticketId);
        }

        public async Task<object> CloseTicket(string ticketId)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(Convert.ToInt32(ticketId));

            if (ticket == null)
            {
                return new { success = false, message = "تیکت پیدا نشد." };
            }

            if (ticket.IsClosed)
            {
                return new { success = false, message = "این تیکت قبلاً بسته شده است." };
            }

            // بستن تیکت
            ticket.IsClosed = true;
            await _ticketService.CloseTicketAsync(ticket.Id);

            return new { success = true, message = "تیکت با موفقیت بسته شد." };
        }
    }
}

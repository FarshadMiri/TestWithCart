using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.Ticket;

namespace TestWithValue.Application.Services.Services_Interface
{
    public interface ITicketService
    {
        Task CreateTicketAsync(TicketViewModel model); // ایجاد تیکت
        Task UpdateTicketStatusAsync(int ticketId, TicketStatus status); // بروزرسانی وضعیت تیکت
        Task SaveMessageAsync(int ticketId, string senderId, string message); // ذخیره پیام
        Task<bool> UserHasOpenTicketAsync(string userId);
        Task<TicketViewModel> GetOpenTicketForUserAsync(string userId);
    }
}

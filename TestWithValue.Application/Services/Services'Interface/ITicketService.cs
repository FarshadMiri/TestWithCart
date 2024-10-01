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
        Task<TicketViewModel> GetTicketByIdAsync(int id);
        Task<int> CreateTicketAsync(TicketViewModel ticket);
        Task UpdateTicketStatusAsync(int ticketId, TicketStatus status);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Domain.Enitities;

namespace TestWithValue.Application.Contract.Persistence
{
    public interface ITicketRepository
    {
        Task<Tbl_Ticket> GetByIdAsync(int id);
        Task AddAsync(Tbl_Ticket ticket);
        Task UpdateAsync(Tbl_Ticket ticket);
    }
}

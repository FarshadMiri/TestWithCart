using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Domain.Enitities;

namespace TestWithValue.Data.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TestWithValueDbContext _context;

        public TicketRepository(TestWithValueDbContext context)
        {
            _context = context;
        }

        public async Task<Tbl_Ticket> GetByIdAsync(int id)
        {
            return await _context.tbl_Tickets.FindAsync(id);
        }

        public async Task AddAsync(Tbl_Ticket ticket)
        {
            await _context.tbl_Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tbl_Ticket ticket)
        {
             _context.tbl_Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }
    }

}

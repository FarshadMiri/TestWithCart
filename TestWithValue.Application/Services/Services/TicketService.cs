using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Application.Services.Services_Interface;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.Ticket;

namespace TestWithValue.Application.Services.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<int> CreateTicketAsync(TicketViewModel ticketViewModel)
        {
            var ticketEntity = _mapper.Map<Tbl_Ticket>(ticketViewModel);

            await _ticketRepository.AddAsync(ticketEntity);

            // بازگشت شناسه تیکت پس از ایجاد آن
            return ticketEntity.TicketId;
        }


        public async Task<TicketViewModel> GetTicketByIdAsync(int id)
        {
            
           var ticket=  await _ticketRepository.GetByIdAsync(id);
            var ticketVM = _mapper.Map<TicketViewModel>(ticket);
            return ticketVM;
        }

        public async Task UpdateTicketStatusAsync(int ticketId, TicketStatus status)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket != null)
            {
                ticket.Status = status;
                await _ticketRepository.UpdateAsync(ticket);
            }
        }
    }
}

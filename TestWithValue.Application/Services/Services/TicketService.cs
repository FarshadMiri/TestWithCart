using AutoMapper;
using TestWithValue.Application.Contract.Persistence;
using TestWithValue.Application.Services.Services_Interface;
using TestWithValue.Domain.Enitities;
using TestWithValue.Domain.ViewModels.Ticket;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;
    private readonly IMapper _mapper;

    public TicketService(ITicketRepository ticketRepository, IMapper mapper)
    {
        _ticketRepository = ticketRepository;
        _mapper = mapper;
    }

    public async Task CreateTicketAsync(TicketViewModel model)
    {
        var ticket = new Tbl_Ticket
        {
            Title = model.Title,
            Description = model.Description,
            UserId = model.UserId,
            TicketStatusId = (int)TicketStatus.Open // وضعیت اولیه تیکت
        };

      var tickets= await  _ticketRepository.CreateTicketAsync(ticket);
        
    }

    public async Task UpdateTicketStatusAsync(int ticketId, TicketStatus status)
    {
        await _ticketRepository.UpdateTicketStatusAsync(ticketId, (int)status); // بروزرسانی وضعیت تیکت
    }

    public async Task SaveMessageAsync(int ticketId, string senderId, string message)
    {
        var ticketMessage = new Tbl_TicketMessage
        {
             TicketId= ticketId,
            SenderId = senderId,
            Message = message,
            SentAt = DateTime.Now
        };

        await _ticketRepository.SaveMessageAsync(ticketMessage); // ذخیره پیام
    }

    public async Task<TicketDetailsViewModel> GetTicketDetailsAsync(int ticketId)
    {
        var ticket = await _ticketRepository.GetTicketByIdAsync(ticketId); // دریافت اطلاعات تیکت
        if (ticket == null) return null;

        var viewModel = new TicketDetailsViewModel
        {
            Id = ticket.Id,
            Title = ticket.Title,
            Description = ticket.Description,
            UserId = ticket.UserId,
            TicketStatus = (TicketStatus)ticket.TicketStatusId,
            Messages = ticket.Messages.Select(m => new TicketMessageViewModel
            {
                SenderId = m.SenderId,
                Message = m.Message,
                SentAt = m.SentAt
            }).ToList()
        };

        return viewModel; // بازگشت ویو مدل جزئیات تیکت
    }

    public async Task<bool> UserHasOpenTicketAsync(string userId)
    {
        return await _ticketRepository.UserHasOpenTicketAsync(userId);
    }

    public async Task<TicketViewModel> GetOpenTicketForUserAsync(string userId)
    {
        var ticket= await _ticketRepository.GetOpenTicketForUserAsync(userId);
        var ticketVM=_mapper.Map<TicketViewModel>(ticket);
        return ticketVM;
    }
}
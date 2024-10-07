﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWithValue.Domain.Enitities
{
    public class Tbl_Ticket
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        [ForeignKey("TicketStatus")]
        public int TicketStatusId { get; set; }
        public Tbl_TicketStatus TicketStatus { get; set; }
        public DateTime CreatedAt { get; set; }

        public IEnumerable<Tbl_TicketMessage> Messages { get; set; }
    }
}

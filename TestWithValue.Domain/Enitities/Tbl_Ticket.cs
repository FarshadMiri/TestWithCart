using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestWithValue.Domain.Enitities
{
    public class Tbl_Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public string Customer { get; set; }
        public string SupportAgent { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

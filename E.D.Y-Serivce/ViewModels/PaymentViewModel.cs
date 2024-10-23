using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.ViewModels
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }

        public string UserId { get; set; } = null!;

        public double Money { get; set; }

        public DateTime Date { get; set; }

        public string? Title { get; set; }
    }
}

using BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.ViewModels
{
    public class NotificationViewModel
    {
        public int NotifiId { get; set; }

        public string? UserId { get; set; }

        public string? ContentNotifi { get; set; }

        public DateTime? Date { get; set; }

    }
}

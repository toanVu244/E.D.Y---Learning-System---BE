using BusinessObject.Entities;
using E.D.Y_Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Repository.Implementaions
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        private static NotificationRepository _instance;

        public static NotificationRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NotificationRepository();
                }
                return _instance;
            }
        }

        public async Task<Notification> GetNotificationByID(int id)
        {
            return await _context.Notifications.SingleOrDefaultAsync(x => x.NotifiId == id);
        }
    }
}

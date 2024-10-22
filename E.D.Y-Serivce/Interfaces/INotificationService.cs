using BusinessObject.Entities;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Interfaces
{
    public interface INotificationService
    {
        public Task<List<NotificationViewModel>> GetAllNotificationAsync();
        public Task<NotificationViewModel> GetNotificationByIdAsync(int id);
        public Task<bool> CreateNotificationAsync(NotificationViewModel Notification);
        public Task<bool> UpdateNotificationAsync(NotificationViewModel Notification);
        public Task<bool> DeleteNotificationAsync(int id);
    }
}

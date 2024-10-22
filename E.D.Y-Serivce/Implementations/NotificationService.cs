using AutoMapper;
using BusinessObject.Entities;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper mapper;
        public NotificationService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<bool> CreateNotificationAsync(NotificationViewModel Notification)
        {
            Notification mapNotification = mapper.Map<Notification>(Notification);
            return await NotificationRepository.Instance.InsertAsync(mapNotification);
        }

        public async Task<bool> DeleteNotificationAsync(int id)
        {
            return await NotificationRepository.Instance.DeleteAsync(id);
        }

        public async Task<List<NotificationViewModel>> GetAllNotificationAsync()
        {
            var notificationList = await NotificationRepository.Instance.GetAllAsync();
            List<NotificationViewModel> result = new List<NotificationViewModel>();
            foreach (var notification in notificationList)
            {
                NotificationViewModel mapNotificationViewModel = mapper.Map<NotificationViewModel>(notification);
                result.Add(mapNotificationViewModel);
            }
            return result;
        }

        public async Task<NotificationViewModel> GetNotificationByIdAsync(int id)
        {
            NotificationViewModel notificationViewModel = mapper.Map<NotificationViewModel>(await NotificationRepository.Instance.GetByIdAsync(id));
            return notificationViewModel;
        }

        public async Task<bool> UpdateNotificationAsync(NotificationViewModel Notification)
        {
            Notification mapNotification = mapper.Map<Notification>(Notification);
            return await NotificationRepository.Instance.UpdateAsync(mapNotification);
        }
    }
}

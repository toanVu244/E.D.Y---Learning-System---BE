using AutoMapper;
using BusinessObject.Entities;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E.D.Y_Serivce.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper mapper;
        public PaymentService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<bool> CreatePaymentAsync(PaymentViewModel Payment)
        {
            Payment mapPayment = mapper.Map<Payment>(Payment);
            return await PaymentRepository.Instance.InsertAsync(mapPayment);
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            return await PaymentRepository.Instance.DeleteAsync(id);
        }

        public async Task<List<PaymentViewModel>> GetAllPaymentAsync()
        {
            var PaymentList = await PaymentRepository.Instance.GetAllAsync();
            List<PaymentViewModel> result = new List<PaymentViewModel>();
            foreach (var Payment in PaymentList)
            {
                PaymentViewModel mapPaymentViewModel = mapper.Map<PaymentViewModel>(Payment);
                result.Add(mapPaymentViewModel);
            }
            return result;
        }

        public async Task<List<PaymentViewModel>> GetAllPaymentByUIDAsync(string uid)
        {
            var PaymentList = await PaymentRepository.Instance.getAllPaymentsbyUID(uid);
            List<PaymentViewModel> result = new List<PaymentViewModel>();
            foreach (var Payment in PaymentList)
            {
                PaymentViewModel mapPaymentViewModel = mapper.Map<PaymentViewModel>(Payment);
                result.Add(mapPaymentViewModel);
            }
            return result;
        }

        public async Task<PaymentViewModel> GetPaymentByIdAsync(int id)
        {
            PaymentViewModel PaymentViewModel = mapper.Map<PaymentViewModel>(await PaymentRepository.Instance.GetByIdAsync(id));
            return PaymentViewModel;
        }

        public async Task<bool> UpdatePaymentAsync(PaymentViewModel Payment)
        {
            Payment mapPayment = mapper.Map<Payment>(Payment);
            return await PaymentRepository.Instance.UpdateAsync(mapPayment);
        }

        public async Task<PaymentResponse> CreateVNPayPayment(PaymentRequest paymentRequest)
        {
            using (var transaction = await PaymentRepository.Instance.BeginTransactionAsync())
            {
                try
                {
                    var payment = new Payment()
                    {
                        PaymentMethod = "VNPay",
                        BankCode = paymentRequest.vnp_BankCode,
                        BankTranNo = paymentRequest.vnp_BankTranNo,
                        CardType = paymentRequest.vnp_CardType,
                        PaymentInfo = paymentRequest.vnp_OrderInfo,
                        Date = DateTime.ParseExact(paymentRequest.vnp_PayDate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                        TransactionNo = paymentRequest.vnp_TransactionNo,
                        TransactionStatus = int.Parse(paymentRequest.vnp_TransactionStatus),
                        Money = double.Parse(paymentRequest.vnp_Amount) / 100,
                        UserId = paymentRequest.userID
                    };
                    await PaymentRepository.Instance.InsertAsync(payment);
                    return mapper.Map<PaymentResponse>(payment);
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}

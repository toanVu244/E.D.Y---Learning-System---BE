using AutoMapper;
using BusinessObject.Entities;
using E.D.Y_Repository.Implementaions;
using E.D.Y_Serivce.Interfaces;
using E.D.Y_Serivce.Tools.VNPAY;
using E.D.Y_Serivce.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E.D.Y_Serivce.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;
        public PaymentService(IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            _configuration = configuration;
        }

        public async Task<string> CreatePaymentAsync(PaymentViewModel Payment)
        {
            using (var transaction = await PaymentRepository.Instance.BeginTransactionAsync())
            {
                try
                {
                    // create order
                    var order = new Payment
                    {
                        Money = Payment.Money,
                        UserId = Payment.UserId,
                        Title = Payment.Title,
                        Status = 0,
                        Date = DateTime.Now,
                        ExpiredDate = DateTime.Now.AddDays(1),
                    };
                    await PaymentRepository.Instance.InsertAsync(order);
                    var paymentUrl = CreateVnpayLink(order);
                    await transaction.CommitAsync();
                    return paymentUrl;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
            }
        }

        private string CreateVnpayLink(Payment order)
        {
            var paymentUrl = string.Empty;

            var vpnRequest = new VNPayRequest(_configuration["VNpay:Version"], _configuration["VNpay:tmnCode"],
                order.Date, "10.87.13.209", (decimal)order.Money, "VND", "other",
                $"Thanh toan don hang {order.PaymentId}", _configuration["VNpay:ReturnUrl"],
                $"{order.PaymentId}", order.ExpiredDate);

            paymentUrl = vpnRequest.GetLink(_configuration["VNpay:PaymentUrl"],
                _configuration["VNpay:HashSecret"]);

            return paymentUrl;
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

        public async Task<PaymentResponse> UpdateVNPayPayment(PaymentRequest paymentRequest)
        {
            using (var transaction = await PaymentRepository.Instance.BeginTransactionAsync())
            {
                try
                {
                    Payment oldPayment = await PaymentRepository.Instance.GetByIdAsync(Int32.Parse(paymentRequest.vnp_TxnRef));
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
                    oldPayment.PaymentMethod = payment.PaymentMethod;
                    oldPayment.BankCode = payment.BankCode;
                    oldPayment.BankTranNo = payment.BankTranNo;
                    oldPayment.CardType = payment.CardType;
                    oldPayment.PaymentInfo = payment.PaymentInfo;
                    oldPayment.Date = payment.Date;
                    oldPayment.TransactionNo = payment.TransactionNo;
                    oldPayment.TransactionStatus = payment.TransactionStatus;
                    var result = await PaymentRepository.Instance.UpdateAsync(oldPayment);
                    await transaction.CommitAsync();
                    return mapper.Map<PaymentResponse>(oldPayment);
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

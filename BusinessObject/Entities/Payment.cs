using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string UserId { get; set; } = null!;

    public double Money { get; set; }

    public DateTime Date { get; set; }

    public string Title { get; set; } = null!;

    public string PaymentMethod { get; set; } = null!;

    public string BankCode { get; set; } = null!;

    public string BankTranNo { get; set; } = null!;

    public string CardType { get; set; } = null!;

    public string PaymentInfo { get; set; } = null!;

    public int TransactionStatus { get; set; }

    public string TransactionNo { get; set; } = null!;
}

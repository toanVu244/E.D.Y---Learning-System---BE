using System;
using System.Collections.Generic;

namespace BusinessObject.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public string UserId { get; set; } = null!;

    public double Money { get; set; }

    public DateTime Date { get; set; }

    public string? Title { get; set; }

    public string? PaymentMethod { get; set; }

    public string? BankCode { get; set; }

    public string? BankTranNo { get; set; }

    public string? CardType { get; set; }

    public string? PaymentInfo { get; set; }

    public int? TransactionStatus { get; set; }

    public string? TransactionNo { get; set; }
}

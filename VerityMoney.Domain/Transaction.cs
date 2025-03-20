using VerityMoney.Domain.Enums;

namespace VerityMoney.Domain;

public class Transaction
{
    public int Id { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public TransactionTypeEnum Type { get; set; }
}


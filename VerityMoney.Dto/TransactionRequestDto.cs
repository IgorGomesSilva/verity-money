using VerityMoney.Domain;
using VerityMoney.Domain.Enums;

namespace VerityMoney.Dto;

public class TransactionRequestDto
{
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public TransactionTypeEnum Type { get; set; }
}



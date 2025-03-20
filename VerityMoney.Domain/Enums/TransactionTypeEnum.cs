using System.ComponentModel;
 
namespace VerityMoney.Domain.Enums;

public enum TransactionTypeEnum
{
    [Description("Credit operation")]
    Credit,
    [Description("Debit operation")]
    Debit
}

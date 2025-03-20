using VerityMoney.Dto;

namespace VerityMoney.Services.Report;

public interface IReportService
{
    Task<DailyBalanceDto> GetDailyBalanceAsync(DateTime date);
}


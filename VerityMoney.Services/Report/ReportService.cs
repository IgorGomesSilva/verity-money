using VerityMoney.Dto;
using VerityMoney.Infra.Repositories;

namespace VerityMoney.Services.Report;

public class ReportService: IReportService
{

    private readonly ITransactionRepository _repository;

    public ReportService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<DailyBalanceDto> GetDailyBalanceAsync(DateTime date)
    {
        decimal totalBalance = await _repository.GetTotalBalanceByDate(date);

        return new DailyBalanceDto(totalBalance);
    }
}

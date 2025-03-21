﻿using VerityMoney.Domain.Exceptions;
using VerityMoney.Infra.Repositories;

namespace VerityMoney.Services.Transaction;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _repository;

    public TransactionService(ITransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Dto.TransactionDto>> GetAllAsync()
    {
        var transactions = await _repository.GetAllAsync();

        return transactions.Select(s => new Dto.TransactionDto(s)).ToList();
    }


    public async Task<Dto.TransactionDto> GetByIdAsync(int id)
    {
        var transaction = await _repository.GetByIdAsync(id);

        if (transaction == null)
        {
            throw new TransactionNotFoundException("This transaction cannot be found");
        }

        return new Dto.TransactionDto(transaction);
    }

    public async Task CreateAsync(Dto.TransactionRequestDto transactionDto)
    {
        Domain.Transaction transaction = new()
        {
            Date = transactionDto.Date,
            Value = transactionDto.Value,
            Type = transactionDto.Type,
        };

        await _repository.CreateAsync(transaction);
    }

    public async Task UpdateAsync(Dto.TransactionRequestDto transactionDto, int id)
    {
        Domain.Transaction transaction = new()
        {
            Id = id,
            Date = transactionDto.Date,
            Value = transactionDto.Value,
            Type = transactionDto.Type,
        };

        await _repository.UpdateAsync(transaction);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}

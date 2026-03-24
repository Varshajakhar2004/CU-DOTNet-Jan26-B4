using SmartBankMiniProject.DTOs;
using SmartBankMiniProject.Exceptions;
using SmartBankMiniProject.Helpers;
using SmartBankMiniProject.Models;
using SmartBankMiniProject.Repositories;
//using SmartBankMiniProject.Service;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _repo;

    public AccountService(IAccountRepository repo)
    {
        _repo = repo;
    }

    public async Task<AccountDto> CreateAccountAsync(CreateAccountDto dto)
    {
        if (dto.InitialDeposit < 1000)
            throw new BadRequestException("Minimum deposit is ₹1000");

        var account = new Account
        {
            Name = dto.Name,
            Balance = dto.InitialDeposit
        };

        account = await _repo.AddAsync(account);

        account.AccountNumber = AccountNumberGenerator.Generate(account.Id);
        await _repo.UpdateAsync(account);

        return new AccountDto
        {
            Id = account.Id,
            AccountNumber = account.AccountNumber,
            Name = account.Name,
            Balance = account.Balance
        };
    }

    public async Task<List<AccountDto>> GetAllAsync()
    {
        var accounts = await _repo.GetAllAsync();

        return accounts.Select(a => new AccountDto
        {
            Id = a.Id,
            AccountNumber = a.AccountNumber,
            Name = a.Name,
            Balance = a.Balance
        }).ToList();
    }

    public async Task<AccountDto> GetByIdAsync(int id)
    {
        var account = await _repo.GetByIdAsync(id);

        if (account == null)
            throw new NotFoundException("Account not found");

        return new AccountDto
        {
            Id = account.Id,
            AccountNumber = account.AccountNumber,
            Name = account.Name,
            Balance = account.Balance
        };
    }

    public async Task DepositAsync(TransactionDto dto)
    {
        if (dto.Amount <= 0)
            throw new BadRequestException("Invalid amount");

        var account = await _repo.GetByIdAsync(dto.AccountId)
            ?? throw new NotFoundException("Account not found");

        account.Balance += dto.Amount;

        await _repo.UpdateAsync(account);
    }

    public async Task WithdrawAsync(TransactionDto dto)
    {
        if (dto.Amount <= 0)
            throw new BadRequestException("Invalid amount");

        var account = await _repo.GetByIdAsync(dto.AccountId)
            ?? throw new NotFoundException("Account not found");

        if (account.Balance - dto.Amount < 1000)
            throw new BadRequestException("Minimum balance must be ₹1000");

        account.Balance -= dto.Amount;

        await _repo.UpdateAsync(account);
    }
}
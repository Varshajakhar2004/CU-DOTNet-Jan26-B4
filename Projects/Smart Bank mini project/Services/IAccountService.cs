using SmartBankMiniProject.DTOs;

public interface IAccountService
{
    Task<AccountDto> CreateAccountAsync(CreateAccountDto dto);
    Task<List<AccountDto>> GetAllAsync();
    Task<AccountDto> GetByIdAsync(int id);
    Task DepositAsync(TransactionDto dto);
    Task WithdrawAsync(TransactionDto dto);
}
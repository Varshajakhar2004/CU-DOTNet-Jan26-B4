using Microsoft.AspNetCore.Mvc;
using SmartBankMiniProject.DTOs;

[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAccountDto dto)
    {
        var result = await _service.CreateAccountAsync(dto);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpPost("deposit")]
    public async Task<IActionResult> Deposit(TransactionDto dto)
    {
        await _service.DepositAsync(dto);
        return Ok("Deposit successful");
    }

    [HttpPost("withdraw")]
    public async Task<IActionResult> Withdraw(TransactionDto dto)
    {
        await _service.WithdrawAsync(dto);
        return Ok("Withdraw successful");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanAPI.Models;
using WebAPIDemo02.Data;
using WebAPIDemo02.DTOs;

namespace WebAPIDemo02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly WebAPIDemo02Context _context;

        public LoansController(WebAPIDemo02Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDto>>> GetLoans()
        {
            return await _context.Loan
                .Select(l => new LoanDto
                {
                    Id = l.Id,
                    BorrowerName = l.BorrowerName,
                    Amount = l.Amount,
                    LoanTermMonths = l.LoanTermMonths,
                    IsApproved = l.IsApproved
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDto>> GetLoanById(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            return new LoanDto
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };
        }
        [HttpPost]
        public async Task<ActionResult<LoanDto>> PostLoan(CreateLoanDto dto)
        {
            var loan = new Loan
            {
                BorrowerName = dto.BorrowerName,
                Amount = dto.Amount,
                LoanTermMonths = dto.LoanTermMonths,
                IsApproved = false
            };

            _context.Loan.Add(loan);
            await _context.SaveChangesAsync();

            var result = new LoanDto
            {
                Id = loan.Id,
                BorrowerName = loan.BorrowerName,
                Amount = loan.Amount,
                LoanTermMonths = loan.LoanTermMonths,
                IsApproved = loan.IsApproved
            };

            return CreatedAtAction(nameof(GetLoanById), new { id = loan.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoan(int id, UpdateLoanDto dto)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            loan.BorrowerName = dto.BorrowerName;
            loan.Amount = dto.Amount;
            loan.LoanTermMonths = dto.LoanTermMonths;
            loan.IsApproved = dto.IsApproved;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var loan = await _context.Loan.FindAsync(id);

            if (loan == null)
                return NotFound();

            _context.Loan.Remove(loan);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
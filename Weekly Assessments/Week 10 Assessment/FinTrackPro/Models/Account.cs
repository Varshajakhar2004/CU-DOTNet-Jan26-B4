using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FinTrackPro.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Account Number")]
        public string AccountNumber { get; set; }

        [Required]
        [Display(Name = "Account Holder Name")]
        public string AccountHolderName { get; set; }

        [Required]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        public double Balance { get; set; }

        // Navigation property
        [ValidateNever]
        public List<Transaction>? Transactions { get; set; }
    }
}

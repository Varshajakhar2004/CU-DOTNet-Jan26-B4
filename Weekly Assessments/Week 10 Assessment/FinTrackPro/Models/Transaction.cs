using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FinTrackPro.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }
        [Required]
        [RegularExpression("Credit|Debit", ErrorMessage ="Only credit or debit allowed")]

        public string Category { get; set; }

        public DateTime Date { get; set; }

        [ValidateNever]
        [Display(Name ="Account Holder Name")]
        public int AccountId { get; set; }
        [ValidateNever]
        public Account Account { get; set; }
    }
}

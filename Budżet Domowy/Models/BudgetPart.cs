using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Budżet_Domowy.Models
{
    public class CheckDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d >= DateTime.Now;
        }
    }
    public class BudgetPart
    {

        public int Id { get; set; } //
        public int BudgetId { get; set; } //

        public int Type { get; set; }

        public DateTime CreationTime 
        {
            get; set;
        } 
        
        [Required]
        [DataType(DataType.DateTime)]
        [CheckDate(ErrorMessage = "You cannot enter the date in the past!")]
        public DateTime DesiredTime
        {
            get; set;
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Amount { get; set; }

        [Required]
        public bool IsFinished { get; set; }
    }
}

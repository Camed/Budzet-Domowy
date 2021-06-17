using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Budżet_Domowy.Models
{
    public class Budget
    {
        public Budget()
        {
            CreationTime = DateTime.Now;
        }
        public List<BudgetPart> BudgetActions { get; set; }
        public int Id { get; set; }
        public string OwnerId { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime CreationTime { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public bool isShared { get; set; }

    }
}

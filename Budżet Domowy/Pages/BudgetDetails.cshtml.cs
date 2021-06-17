using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budżet_Domowy.Data;
using Budżet_Domowy.Models;
using Microsoft.AspNet.Identity;

namespace Budżet_Domowy.Pages
{
    public class BudgetDetailsModel : PageModel
    {
        private readonly Budżet_Domowy.Data.BudgetContext _context;

        public BudgetDetailsModel(Budżet_Domowy.Data.BudgetContext context)
        {
            _context = context;
        }

        public Budget Budget { get; set; }
        public double[] sums = new double[3];
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Budget = await _context.Budgets.FirstOrDefaultAsync(m => m.Id == id);
            Budget.BudgetActions = await _context.BudgetParts.Where(b => b.BudgetId == (int)id).ToListAsync();

            if (Budget == null)
            {
                return NotFound();
            }
            if (Budget.OwnerId == User.Identity.GetUserId() || Budget.isShared) return Page();
            return Unauthorized();
        }


    }
}

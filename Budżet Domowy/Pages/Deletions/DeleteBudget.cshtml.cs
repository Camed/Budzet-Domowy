using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budżet_Domowy.Data;
using Budżet_Domowy.Models;

namespace Budżet_Domowy.Pages.Deletions
{
    public class DeleteBudgetModel : PageModel
    {
        private readonly Budżet_Domowy.Data.BudgetContext _context;

        public DeleteBudgetModel(Budżet_Domowy.Data.BudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Budget Budget { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Budget = await _context.Budgets.FirstOrDefaultAsync(m => m.Id == id);

            if (Budget == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Budget = await _context.Budgets.FindAsync(id);

            if (Budget != null)
            {
                _context.Budgets.Remove(Budget);
                await _context.SaveChangesAsync();
            }
            foreach(var x in _context.BudgetParts)
            {
                if(x.BudgetId == id)
                {
                    _context.BudgetParts.Remove(x);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}

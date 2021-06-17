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
    public class DeleteBudgetPartModel : PageModel
    {
        private readonly Budżet_Domowy.Data.BudgetContext _context;

        public DeleteBudgetPartModel(Budżet_Domowy.Data.BudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BudgetPart BudgetPart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BudgetPart = await _context.BudgetParts.FirstOrDefaultAsync(m => m.Id == id);

            if (BudgetPart == null)
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

            BudgetPart = await _context.BudgetParts.FindAsync(id);

            if (BudgetPart != null)
            {
                _context.BudgetParts.Remove(BudgetPart);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

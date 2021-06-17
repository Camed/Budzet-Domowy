using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Budżet_Domowy.Data;
using Budżet_Domowy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Budżet_Domowy.Pages.Modifies
{
    [Authorize]
    public class ModifyBudgetPartModel : PageModel
    {
        private readonly Budżet_Domowy.Data.BudgetContext _context;

        public ModifyBudgetPartModel(Budżet_Domowy.Data.BudgetContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BudgetPart BudgetPart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            BudgetPart = await _context.BudgetParts.FirstOrDefaultAsync(m => m.Id == Id);
            if (BudgetPart == null)
            {
                return NotFound();
            }
            Budget b = await _context.Budgets.FirstOrDefaultAsync(m => m.OwnerId == User.Identity.GetUserId());
            if (b.Id == BudgetPart.BudgetId) return Page();
            return Unauthorized();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BudgetPart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetPartExists(BudgetPart.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../Index");
        }

        private bool BudgetPartExists(int id)
        {
            return _context.BudgetParts.Any(e => e.Id == id);
        }
    }
}

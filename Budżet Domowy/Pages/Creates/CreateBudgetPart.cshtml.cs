using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Budżet_Domowy.Data;
using Budżet_Domowy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Budżet_Domowy.Pages.Creates
{
    [Authorize]
    public class CreateBudgetPartModel : PageModel
    {
        private readonly Budżet_Domowy.Data.BudgetContext _context;
        public Budget b = new Budget();
        
        [BindProperty]
        public int veryimportantvalue { get; set; }

        public CreateBudgetPartModel(Budżet_Domowy.Data.BudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Unauthorized();
        }
        public IActionResult OnGetBudget(int budgetId)
        {
            b = _context.Budgets.FirstOrDefault(m => m.Id == budgetId);
            veryimportantvalue = b.Id;
            if (b.OwnerId == User.Identity.GetUserId())
            {
                veryimportantvalue = budgetId;
                return Page();
            }
            return Unauthorized();
        }

        [BindProperty]
        public BudgetPart BudgetPart { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            BudgetPart.CreationTime = DateTime.Now;
            BudgetPart.BudgetId = veryimportantvalue;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BudgetParts.Add(BudgetPart);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}

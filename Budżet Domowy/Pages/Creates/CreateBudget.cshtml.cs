using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Budżet_Domowy.Data;
using Budżet_Domowy.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNet.Identity;

namespace Budżet_Domowy.Pages.Creates
{
    [Authorize]
    public class CreateBudgetModel : PageModel
    {
        private readonly Budżet_Domowy.Data.BudgetContext _context;

        public CreateBudgetModel(Budżet_Domowy.Data.BudgetContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Budget Budget { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            Budget.OwnerId = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Budgets.Add(Budget);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}

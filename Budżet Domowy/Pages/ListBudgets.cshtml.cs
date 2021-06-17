using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budżet_Domowy.Data;
using Budżet_Domowy.Models;
using Microsoft.AspNetCore.Authorization;

namespace Budżet_Domowy.Pages
{
    [Authorize]
    public class ListBudgetsModel : PageModel
    {
        private readonly Budżet_Domowy.Data.BudgetContext _context;

        public ListBudgetsModel(Budżet_Domowy.Data.BudgetContext context)
        {
            _context = context;
        }

        public IList<Budget> Budget { get;set; }

        public async Task OnGetAsync()
        {
            Budget = await _context.Budgets.ToListAsync();
        }
    }
}

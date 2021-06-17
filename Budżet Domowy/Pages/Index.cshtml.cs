using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Budżet_Domowy.Data;
using Budżet_Domowy.Models;

namespace Budżet_Domowy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Budżet_Domowy.Data.BudgetContext _context;

        public IndexModel(Budżet_Domowy.Data.BudgetContext context)
        {
            _context = context;
        }


        public async Task OnGetAsync()
        {
        }
    }
}

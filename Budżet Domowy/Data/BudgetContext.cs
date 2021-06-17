using Budżet_Domowy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Budżet_Domowy.Data
{
    public class BudgetContext : DbContext
    {
        public BudgetContext(DbContextOptions options) : base(options) { }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BudgetPart> BudgetParts { get; set; }
    }
}

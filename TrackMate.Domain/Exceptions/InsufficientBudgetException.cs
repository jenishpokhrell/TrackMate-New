using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMate.Domain.Exceptions
{
    public class InsufficientBudgetException : Exception
    {
        public Guid BudgetId { get; }
        public decimal OverBy { get; }

        public InsufficientBudgetException(Guid budgetId, decimal overBy) : base($"Budget {budgetId} exceeded by {overBy:F2}.")
        {
            BudgetId = budgetId;
            OverBy = overBy;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMate.Domain.Events
{
    public class BudgetExceededEvent
    {
        public Guid BudgetId { get; }
        public Guid AccountId { get; }
        public decimal OverBy { get; }

        public BudgetExceededEvent(Guid budgetId, Guid accountId, decimal overBy)
        {
            BudgetId = budgetId;
            AccountId = accountId;
            OverBy = overBy;
        }
    }
}

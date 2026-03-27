using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMate.Domain.Events
{
    public class ExpenseCreatedEvent : BaseDomainEvent
    {
        public Guid ExpenseId { get; }
        public Guid AccountId { get; }
        public Guid UserId { get; }

        public ExpenseCreatedEvent(Guid expenseId, Guid accountId, Guid userId)
        {
            ExpenseId = expenseId;
            AccountId = accountId;
            UserId = userId;
        }
    }
}

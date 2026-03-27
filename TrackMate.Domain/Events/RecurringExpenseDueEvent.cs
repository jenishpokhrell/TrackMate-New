using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMate.Domain.Events
{
    public class RecurringExpenseDueEvent : BaseDomainEvent
    {
        public Guid RecurrenceExpenseId { get; }
        public Guid AccountId { get; }
        public DateOnly DueDate { get; }

        public RecurringExpenseDueEvent(Guid recurrenceExpenseId, Guid accountId, DateOnly dueDate)
        {
            RecurrenceExpenseId = recurrenceExpenseId;
            AccountId = accountId;
            DueDate = dueDate;
        }
    }
}

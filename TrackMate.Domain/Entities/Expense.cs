using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrackMate.Domain.Events;
using TrackMate.Domain.ValueObjects;

namespace TrackMate.Domain.Entities
{
    public class Expense : BaseEntity
    {
        public Guid AccountId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid WalletId { get; private set; }
        public Guid CategoryId { get; private set; }
        public Money Amount { get; private set; } = null!;
        public string? Description { get; private set; }
        public DateOnly Date { get; private set; }
        public string[]? Tags { get; private set; }
        public string? Notes { get; private set; }
        public string? ProjectOrTrip { get; private set; }
        public Guid? RecurringExpenseId { get; private set; }

        private Expense() { }

        public static Expense Create(Guid accountId, Guid userId, Guid walletId, Guid categoryId, Money amount, string description,  DateOnly date, string[]? tags = null, 
            string? notes = null, string? projectOrTrip = null)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new Exceptions.DomainException("Expense description is required");
            }

            var expense = new Expense
            {
                AccountId = accountId,
                UserId = userId,
                WalletId = walletId,
                CategoryId = categoryId,
                Amount = amount,
                Description = description,
                Tags = tags,
                Notes = notes,
                ProjectOrTrip = projectOrTrip
            };

            expense.AddDomainEvent(new ExpenseCreatedEvent(expense.Id, accountId, userId));

            return expense;
        }

        public void Update(Money amount, string description, Guid categoryId, DateOnly date, string[]? tags, string? notes)
        {
            Amount = amount;
            Description = description;
            CategoryId = categoryId;
            Date = date;
            Tags = tags;
            Notes = notes;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

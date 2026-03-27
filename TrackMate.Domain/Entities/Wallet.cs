using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMate.Domain.Enums;
using TrackMate.Domain.ValueObjects;

namespace TrackMate.Domain.Entities
{
    public class Wallet : BaseEntity
    {
        public Guid AccountId { get; private set; }
        public Guid UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public WalletType WalletType { get; private set; }
        public Money Balance { get; private set; } = null!;
        public string? Color { get; private set; }
        public bool IsDefault { get; private set; }

        private Wallet() { }

        public static Wallet Create(Guid accountId, Guid userId, string name, WalletType walletType, Money initialBalance, string? color = null,
            bool isDefault = false)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exceptions.DomainException("Wallet name is required.");
            }

            return new Wallet
            {
                AccountId = accountId,
                UserId = userId,
                Name = name,
                WalletType = walletType,
                Balance = initialBalance,
                Color = color,
                IsDefault = isDefault
            };
        }

        public void Credit(Money amount)
        {
            Balance = Balance.Add(amount);
            UpdatedAt = DateTime.UtcNow;
        }

        public void Debit(Money amount)
        {
            Balance = Balance.Subtract(amount);
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetAsDefault()
        {
            IsDefault = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

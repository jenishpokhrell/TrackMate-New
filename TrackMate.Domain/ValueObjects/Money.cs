using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMate.Domain.ValueObjects
{
    public sealed class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public string CurrencyCode { get; }

        public Money(decimal amount, string currencyCode)
        {
            if(amount < 0)
            {
                throw new Exceptions.DomainException("Amount cannot be negative");
            }

            if(string.IsNullOrWhiteSpace(currencyCode) || currencyCode.Length != 3)
            {
                throw new Exceptions.DomainException("Currency code must be 3 characters 'ISO 4217'.");
            }

            Amount = amount;
            CurrencyCode = currencyCode.ToUpperInvariant();
        }

        public Money Add(Money other)
        {
            if(CurrencyCode !=  other.CurrencyCode)
            {
                throw new Exceptions.DomainException("Cannot add amounts in different currencies.");
            }
            return new Money(Amount + other.Amount, CurrencyCode);
        }

        public Money Subtract(Money other)
        {
            if(CurrencyCode != other.CurrencyCode)
            {
                throw new Exceptions.DomainException("Cannot subtract amounts in different currencies.");
            }

            return new Money(Amount - other.Amount, CurrencyCode);
        }

        public bool Equals(Money? other) => 
            other is not null && 
            Amount == other.Amount && 
            CurrencyCode == other.CurrencyCode;

        public override bool Equals(object? obj) => Equals(obj as Money);
        public override int GetHashCode() => HashCode.Combine(Amount, CurrencyCode);
        public static bool operator == (Money left, Money right) => left.Equals(right);
        public static bool operator != (Money left, Money right) => !left.Equals(right);
        public override string ToString() => $"{Amount:F2} {CurrencyCode}";
    }
}

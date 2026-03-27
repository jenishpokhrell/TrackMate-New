using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public AccountType AccountType { get; private set; }
        public Guid OwnerId { get; private set; }
        public string? InviteCode { get; private set; }

        private readonly List<AccountMember> _members = new();

        public IReadOnlyCollection<AccountMember> Members => _members.AsReadOnly();

        private Account() { }

        public static Account Create(string name, AccountType accountType, Guid ownerId)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exceptions.DomainException("Account name is required");
            }

            var account = new Account
            {
                Name = name,
                AccountType = accountType,
                OwnerId = ownerId
            };

            if(accountType != AccountType.Individual)
            {
                account.InviteCode = GenerateInviteCode();
            }

            return account;
        }

        public void AddMember(Guid userId, MemberRole role)
        {
            if(AccountType == AccountType.Individual)
            {
                throw new Exceptions.DomainException("Individual accounts cannot have multiple users");
            }

            var maxMembers = AccountType == AccountType.Duo ? 2 : 6;
            if(_members.Count > maxMembers)
            {
                throw new Exceptions.DomainException($"Account has reached maximum of {maxMembers} members");
            }

            _members.Add(AccountMember.Create(Id, userId, role));
            UpdatedAt = DateTime.UtcNow;
        }

        private static string GenerateInviteCode() => Guid.NewGuid().ToString("N")[..8].ToUpperInvariant();
    }
}

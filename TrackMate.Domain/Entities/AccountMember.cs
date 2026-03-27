using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackMate.Domain.Enums;

namespace TrackMate.Domain.Entities
{
    public class AccountMember : BaseEntity
    {
        public Guid AccountId { get; private set; }
        public Guid UserId { get; private set; }
        public MemberRole Role { get; private set; }
        public DateTime JoinedAt { get; private set; }

        private AccountMember() { }

        public static AccountMember Create(Guid accountId, Guid userId, MemberRole role)
        {
            return new AccountMember()
            {
                AccountId = accountId,
                UserId = userId,
                Role = role,
                JoinedAt = DateTime.UtcNow
            };
        }

        public void ChangeRole(MemberRole newRole)
        {
            Role = newRole;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

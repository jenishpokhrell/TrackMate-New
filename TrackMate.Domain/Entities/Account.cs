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
    }
}

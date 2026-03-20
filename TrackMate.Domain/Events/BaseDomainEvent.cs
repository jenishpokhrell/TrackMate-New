using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMate.Domain.Events
{
    public abstract class BaseDomainEvent
    {
        public DateTime OccuredOn { get; } = DateTime.UtcNow;
    }
}

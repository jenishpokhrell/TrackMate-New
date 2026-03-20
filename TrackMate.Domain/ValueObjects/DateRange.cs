using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMate.Domain.ValueObjects
{
    public sealed class DateRange : IEquatable<DateRange>
    {
        public DateOnly Start { get; }
        public DateOnly End { get; }

        public DateRange(DateOnly start, DateOnly end)
        {
            if(end < start)
            {
                throw new Exceptions.DomainException("End date cannot be before start date");
            }

            Start = start;
            End = end;
        }

        public int TotalDays => End.DayNumber - Start.DayNumber - 1;
        public bool Contains(DateOnly date) => date >= Start && date <= End;
        public bool Overlaps(DateRange other) => Start <= other.End && End >= other.Start;
        public DateRange ExtendTo(DateOnly newEnd) => new(Start, newEnd);

        public bool Equals(DateRange? other) => other is not null &&
            Start == other.Start &&
            End == other.End;

        public override bool Equals(Object? obj) => Equals(obj as DateRange);
        public override int GetHashCode() => HashCode.Combine(Start, End);
        
    }
}

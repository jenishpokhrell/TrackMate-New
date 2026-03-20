using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMate.Domain.ValueObjects
{
    public sealed class RegionInfo : IEquatable<RegionInfo>
    {
        public string RegionCode { get; }
        public string DefaultCurrency { get; }

        public RegionInfo(string regionCode, string defaultCurrency)
        {
            if (string.IsNullOrWhiteSpace(regionCode))
            {
                throw new Exceptions.DomainException("Region Code is required.");
            }

            if(string.IsNullOrWhiteSpace(defaultCurrency) || defaultCurrency.Length != 3)
            {
                throw new Exceptions.DomainException("Default Currency must be 3 characters 'ISO 4217'.");
            }

            RegionCode = regionCode;
            DefaultCurrency = defaultCurrency;
        }

        public bool Equals(RegionInfo? other) =>
            other is not null &&
            RegionCode == other.RegionCode &&
            DefaultCurrency == other.DefaultCurrency;

        public override bool Equals(object? obj) => Equals(obj as RegionInfo);
        public override int GetHashCode() => HashCode.Combine(RegionCode, DefaultCurrency);

    }
}

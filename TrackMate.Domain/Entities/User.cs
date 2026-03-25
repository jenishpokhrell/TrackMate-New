using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TrackMate.Domain.ValueObjects;

namespace TrackMate.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; private set; } = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public string FullName { get; private set; } = string.Empty;
        public string? ProfilePictureUrl { get; private set; }
        public string PreferredCurrency { get; private set; } = string.Empty;
        public RegionInfo Region { get; private set; } = null!;
        public bool IsEmailVerified { get; private set; } = false;

        private User () { }

        public static User Create(string email, string passwordHash, string fullName, RegionInfo region)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exceptions.DomainException("Email is required");
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new Exceptions.DomainException("Full name is required");
            }

            return new User
            {
                Email = email.ToLowerInvariant(),
                PasswordHash = passwordHash,
                FullName = fullName,
                Region = region,
                PreferredCurrency = region.DefaultCurrency
            };
        }

        public void UpdateProfile(string fullName, string? profilePictureUrl)
        {
            FullName = fullName;
            ProfilePictureUrl = profilePictureUrl;
            UpdatedAt = DateTime.UtcNow;
        }

        public void VerifyEmail()
        {
            IsEmailVerified = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}

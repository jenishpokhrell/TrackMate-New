using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMate.Domain.Entities
{
    public class Category : BaseEntity
    {
        public Guid AccountId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string? Icon {  get; private set; }
        public string? Color { get; private set; }
        public Guid ParentCategoryId { get; private set; }
        public bool IsSystem { get; private set; }
        
        private Category () { }

        public static Category Create(Guid accountId, string name, string? icon = null, string? color = null, Guid parentCategoryId = null)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new Exceptions.DomainException("Category name is required");
            }

            return new Category
            {
                AccountId = accountId,
                Name = name,
                Icon = icon,
                Color = color,
                ParentCategoryId = parentCategoryId
                IsSystem = false
            };
        }

        public static Category CreateSystem(Guid accountId, string name, string? icon = null, string? color = null)
        {
            var category = Create(accountId, name, icon, color);
            category.IsSystem = true;
            return category;
        }
    }
}

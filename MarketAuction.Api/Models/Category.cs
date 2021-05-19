using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarketAuction.Api.Models
{
    public class Category
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public string Name { get; private set; }
        public int? ParentCategoryId { get; private set; }
        public Category ParentCategory { get; private set; }
        public IEnumerable<Category> Children { get; private set; }

        public Category(int id, string name, int? parentCategoryId = null)
        {
            Id = id > 0 ? id : throw new ArgumentException();
            Name = !string.IsNullOrEmpty(name) ? name : throw new ArgumentException(); ;
            ParentCategoryId = parentCategoryId;
        }
    }
}

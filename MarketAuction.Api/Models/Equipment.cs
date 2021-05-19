using System;
using System.ComponentModel.DataAnnotations;

namespace MarketAuction.Api.Models
{
    public class Equipment
    {
        [Key]
        public int Id { get; private set; }
        [Required]
        public int SubCategoryId { get; private set; }
        [Required]
        public int ModelId { get; private set; }

        public Category SubCategory { get; private set; }
        public Model Model { get; private set; }
        public SaleDetails SaleDetails { get; private set; }

        public Equipment(int id, int subCategoryId, int modelId)
        {
            Id = id > 0 ? id : throw new ArgumentException();
            SubCategoryId = subCategoryId > 0 ? subCategoryId : throw new ArgumentException();
            ModelId = modelId > 0 ? modelId : throw new ArgumentException();
        }

        public void AddSaleDetails(SaleDetails saleDetails)
        {
            SaleDetails = saleDetails;
        }
    }
}

using BAProject.Model.Model.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace BAProject.Model.Model.Entities.Concrete
{
    public class ProductImage : BaseEntity
    {
        [Required]
        public string ImagePath { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}

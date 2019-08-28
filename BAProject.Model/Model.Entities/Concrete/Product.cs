using BAProject.Model.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BAProject.Model.Model.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductImages = new HashSet<ProductImage>();
        }

        [Required]
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public short? UnitsInStock { get; set; }
        public string Quantity { get; set; }
        public double? Discount { get; set; }
        public bool DisplayOnWeb { get; set; }
        public bool DisplayOnMobile { get; set; }



        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}

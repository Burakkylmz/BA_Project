using BAProject.Model.Model.Entities.Abstract;
using System;


namespace BAProject.Model.Model.Entities.Concrete
{
    public class OrderDetail : BaseEntity
    {
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
        public Guid OrderID { get; set; }
        public virtual Order Order { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? Quantity { get; set; }
    }
}

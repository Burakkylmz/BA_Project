using BAProject.Model.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAProject.Model.Model.Entities.Concrete
{
    public enum OrderStatus
    {
        Ordered = 2,
        Processing = 3,
        Completed = 4,
        Cancelled = 5,
        Declined = 6,
        Incomplete = 7,
        PreOrdered = 8
    }
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
        public Guid AppUserID { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public virtual AppUser AppUser { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        [Column(TypeName = "money")]
        public decimal? TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

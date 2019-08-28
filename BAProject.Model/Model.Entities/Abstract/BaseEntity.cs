using System;
using System.ComponentModel.DataAnnotations;

namespace BAProject.Model.Model.Entities.Abstract
{
    public enum Status
    {
        Active = 1,
        Passive = 3
    }

    public abstract class BaseEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        public Status EntityStatus { get; set; }
    }
}

using BAProject.Model.Model.Entities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BAProject.Model.Model.Entities.Concrete
{
    public enum UserRole
    {
        Guest = 0,
        Admin = 1,
        Member = 3,
        Banned = 5,
        SuperAdmin = 7
    }

    public class AppUser : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string ProfileImagePath { get; set; }
        //[Column(TypeName = "datetime2")] psql için timestamp geçerlidir. Datetime tipi yoktur.
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }

    }
}
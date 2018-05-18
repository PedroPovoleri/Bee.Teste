using Model.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.POCO
{
    public class UserRoles : IEntity
    {
 
        [ForeignKey("UserId")]
        public Users _User { get; set; }

        [ForeignKey("RoleId")]
        public Roles _Roles { get; set; }

        public int UserId { get; set; }
        public int RoleId { get; set; }

        [NotMapped]
        public int id { get; set; }
    }
}

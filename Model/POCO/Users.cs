using Model.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.POCO
{
    public class Users : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        [ForeignKey("RolesId")]
        public Roles _Roles { get; set; }

        public int RolesId { get; set; }

    }
}
    
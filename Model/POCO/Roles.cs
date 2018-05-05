
using Model.Interface;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.POCO
{
    public class Roles : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("UserId")]
        public  Users  _User { get; set; }

        public int UserId { get; set; }
    }
}

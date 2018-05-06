
using Model.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.POCO
{
    public class User : IEntity
    {
        [Key]
        public int id { get; set; }
        public string Name { get; set; }

        [ForeignKey("UserId")]
        public ICollection<Users> _Users { get; set; }

        public int UserId { get; set; }
    }
}

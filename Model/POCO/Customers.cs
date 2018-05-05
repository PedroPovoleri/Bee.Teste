using Model.Interface;
using System.ComponentModel.DataAnnotations;

namespace Model.POCO
{
    public class Customers : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}

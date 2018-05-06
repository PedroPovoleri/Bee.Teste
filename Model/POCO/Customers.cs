using Model.Interface;
using System.ComponentModel.DataAnnotations;

namespace Model.POCO
{
    public class Customers : IEntity
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
    }
}

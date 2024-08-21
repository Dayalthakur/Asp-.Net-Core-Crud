using System.ComponentModel.DataAnnotations;

namespace crudtest.Models
{
    public class Studnt
    {
        [Key]
        public int StudId { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public int Age { get; set; }

    }
}

using CrudApplication.Models.Cascade;
using System.ComponentModel.DataAnnotations;

namespace CrudApplication.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public State State { get; set; }

    }
}

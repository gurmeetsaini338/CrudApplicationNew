using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace CrudApplication.Models.Cascade
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; } 
    }
}
